using System;
using System.Collections.Generic;

namespace ParticleSystem
{
    // Particle which attract another particles
    public class AdvancedParticleUpdater : ParticleUpdater
    {
        #region Fields
        protected const int MaxDistance = 10;
        private List<Particle> currParticles = new List<Particle>();
        private List<ParticleAttractor> currAttractors = new List<ParticleAttractor>();
        #endregion

        #region Methods
        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            if ((p as ParticleAttractor) != null) this.currAttractors.Add(p as ParticleAttractor);
            else this.currParticles.Add(p);

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var attractor in this.currAttractors)
            {
                foreach (var particle in this.currParticles)
                {
                    MatrixCoords currDiff = attractor.Position - particle.Position;
                    if (Math.Abs(currDiff.Row) + Math.Abs(currDiff.Col) <= MaxDistance)
                    {
                        particle.Accelerate(new MatrixCoords(DecreasePower(attractor, currDiff.Row), DecreasePower(attractor, currDiff.Col)));
                    }
                }
            }

            this.currParticles.Clear();
            this.currAttractors.Clear();

            base.TickEnded();
        }

        private static int DecreasePower(ParticleAttractor attractor, int coord)
        {
            if (Math.Abs(coord) > attractor.AttractionPower && coord != 0)
            {
                coord = (coord / (int)Math.Abs(coord)) * attractor.AttractionPower;
            }
            return coord;
        }
        #endregion
    }
}
