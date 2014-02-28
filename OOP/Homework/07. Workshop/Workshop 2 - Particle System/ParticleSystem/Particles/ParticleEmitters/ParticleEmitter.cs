using System;
using System.Collections.Generic;

namespace ParticleSystem
{
    // Particle which generate another particles
    public class ParticleEmitter : Particle
    {
        #region Field
        const int MaxElements = 3;
        const int MaxSpeed = 1;
        protected Random randGen;
        #endregion

        #region Constructor
        public ParticleEmitter(MatrixCoords position, MatrixCoords speed, Random randomGenerator)
            : base(position, speed)
        {
            this.randGen = randomGenerator;
        }
        #endregion

        #region Methods
        public override IEnumerable<Particle> Update()
        {
            IEnumerable<Particle> obj = base.Update();
            List<Particle> generatedObjects = new List<Particle>();

            int newObjects = this.randGen.Next(MaxElements + 1);

            for (int i = 0; i < newObjects; i++)
            {
                GetRandomParticle(generatedObjects);
            }
            generatedObjects.AddRange(obj);

            return generatedObjects;
        }

        protected virtual void GetRandomParticle(List<Particle> generatedObjects)
        {
            MatrixCoords newSpeed = GetRandomCoords();
            while (newSpeed.Row == 0 && newSpeed.Col == 0) newSpeed = GetRandomCoords();
            generatedObjects.Add(this.GetNewParticle(this.Position, newSpeed));

        }

        protected virtual Particle GetNewParticle(MatrixCoords position, MatrixCoords speed)
        {
            return new Particle(position, speed);
        }

        private MatrixCoords GetRandomCoords()
        {
            return new MatrixCoords(this.randGen.Next(-MaxSpeed, MaxSpeed + 1), this.randGen.Next(-MaxSpeed, MaxSpeed + 1));
        }

        public override char[,] GetImage()
        {
            return new char[,] { { '♦' } };
        }
        #endregion
    }
}
