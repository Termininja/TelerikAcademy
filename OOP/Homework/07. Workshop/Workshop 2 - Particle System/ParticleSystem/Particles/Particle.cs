using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    // Information about some particle
    public class Particle : IRenderable, IAcceleratable
    {
        #region Properties
        public MatrixCoords Position { get; set; }
        public MatrixCoords Speed { get; set; }

        public virtual bool Exists
        {
            get { return true; }
        }
        #endregion

        #region Constructor
        public Particle(MatrixCoords position, MatrixCoords speed)
        {
            this.Position = position;
            this.Speed = speed;
        }
        #endregion

        #region Methods
        // Update the state of some particle
        public virtual IEnumerable<Particle> Update()
        {
            this.Move();
            return new List<Particle>();
        }

        // Move some particle
        public virtual void Move()
        {
            this.Position += this.Speed;
        }

        // The position of some particle
        public MatrixCoords GetTopLeft()
        {
            return this.Position;
        }

        // The image of some particle
        public virtual char[,] GetImage()
        {
            return new char[,] { { '*' } };
        }

        // Change the speed of some particle
        public void Accelerate(MatrixCoords acceleration)
        {
            this.Speed += acceleration;
        }
        #endregion
    }
}
