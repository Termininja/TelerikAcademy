using System;

namespace ParticleSystem
{
    // Particle which randomly changing its movement
    public class ChaoticParticle : Particle
    {
        // Field
        protected Random randGen;

        // Constructor
        public ChaoticParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator)
            : base(position, speed)
        {
            this.randGen = randomGenerator;
        }

        // Methods
        public override void Move()
        {
            this.Speed = new MatrixCoords(this.randGen.Next(-2, 3), this.randGen.Next(-2, 3));
            base.Move();
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'x', 'o', '-', 'x', 'o' } };
        }
    }
}
