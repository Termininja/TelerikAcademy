using System;
using System.Collections.Generic;
using System.Threading;

namespace ParticleSystem
{
    public class Engine
    {
        #region Fields
        private IParticleOperator particleOperator;
        private List<Particle> particles;
        private IRenderer renderer;
        private int Wait;
        #endregion

        #region Constructor
        public Engine(IRenderer renderer, IParticleOperator particleOperator, List<Particle> particles = null, int wait = 1000)
        {
            this.renderer = renderer;
            this.particleOperator = particleOperator;

            if (particles != null)
            {
                this.particles = particles;
            }
            else
            {
                this.particles = new List<Particle>();
            }

            this.Wait = wait;
        }
        #endregion

        #region Methods
        public void AddParticle(Particle p)
        {
            this.particles.Add(p);
        }

        // Print all particles
        public void Run()
        {
            while (true)
            {
                renderer.RenderAll();
                renderer.ClearQueue();

                List<Particle> producedParticles = new List<Particle>();

                foreach (var particle in particles)
                {
                    producedParticles.AddRange(particleOperator.OperateOn(particle));
                }

                foreach (var particle in this.particles)
                {
                    renderer.EnqueueForRendering(particle);
                }

                // Remove all dead particles
                this.particles.RemoveAll(p => !p.Exists);

                // Add new produced particles
                this.particles.AddRange(producedParticles);

                // Mark the end of the current frame
                particleOperator.TickEnded();

                Thread.Sleep(this.Wait);
            }
        }
        #endregion
    }
}
