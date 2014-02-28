using System;
using System.Collections.Generic;

namespace ParticleSystem
{
    // Particle which create another ChickenParticle
    public class ChickenParticle : ChaoticParticle
    {
        #region Fields
        protected const int MaxWait = 10;
        protected const int MaxVariations = 15;
        private int wait;
        private bool stop;
        #endregion

        #region Constructor
        public ChickenParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator)
            : base(position, speed, randomGenerator)
        {
            this.wait = MaxWait;
            this.stop = false;
        }
        #endregion

        #region Methods
        public override void Move()
        {
            this.Speed = new MatrixCoords(0, 0);

            if (this.stop)
            {
                if (this.wait > 0) this.wait--;
                else
                {
                    this.wait = MaxWait;
                    this.stop = false;
                }
            }
            else if (randGen.Next(0, MaxVariations) == 0) this.stop = true;
            else this.Speed = new MatrixCoords(this.randGen.Next(-2, 3), this.randGen.Next(-2, 3));

            this.Position += this.Speed;
        }

        public override IEnumerable<Particle> Update()
        {
            List<Particle> generatedObjects = new List<Particle>();
            generatedObjects.AddRange(base.Update());

            if (this.wait == 0)
            {
                generatedObjects.Add(new ChickenParticle(new MatrixCoords(this.Position.Row, this.Position.Col), new MatrixCoords(), randGen));
            }

            return generatedObjects;
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'o' } };
        }
        #endregion
    }
}
