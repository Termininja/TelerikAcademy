using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    // Generate particles with different lifetime
    public class VariousParticleEmitter : ParticleEmitter
    {
        // Fields
        const int MaxLifetime = 5;

        // Constructor
        public VariousParticleEmitter(MatrixCoords position, MatrixCoords speed, Random randomGenerator)
            : base(position, speed, randomGenerator) { }

        // Methods
        protected override Particle GetNewParticle(MatrixCoords position, MatrixCoords speed)
        {
            if ((this.randGen.Next() % 2) == 0)
            {
                return new DyingParticle(position, speed, this.randGen.Next(MaxLifetime));
            }
            return base.GetNewParticle(position, speed);
        }
    }
}
