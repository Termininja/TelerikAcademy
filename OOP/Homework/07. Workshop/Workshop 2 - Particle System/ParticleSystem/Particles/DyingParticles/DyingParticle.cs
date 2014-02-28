using System;
using System.Collections.Generic;

namespace ParticleSystem
{
    // Particle which can die
    public class DyingParticle : Particle
    {
        // Fields
        private int lifetime = 0;

        // Constructor
        public DyingParticle(MatrixCoords position, MatrixCoords speed, int lifetime)
            : base(position, speed)
        {
            this.lifetime = lifetime;
        }

        // Methods
        public override bool Exists
        {
            get
            {
                return this.lifetime > 0;
            }
        }

        public override IEnumerable<Particle> Update()
        {
            lifetime--;
            return base.Update();
        }
    }
}
