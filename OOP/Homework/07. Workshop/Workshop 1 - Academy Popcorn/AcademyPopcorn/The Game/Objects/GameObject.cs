using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // The object can be renderable, collidable and produserable
    public abstract class GameObject : IRenderable, ICollidable, IObjectProducer
    {
        public const string CollisionGroupString = "object";

        // Object top-left coordinates
        protected MatrixCoords topLeft;
        public MatrixCoords TopLeft
        {
            get
            {
                return new MatrixCoords(topLeft.Row, topLeft.Col);
            }
            protected set
            {
                this.topLeft = new MatrixCoords(value.Row, value.Col);
            }
        }

        // Object's body
        protected char[,] body;

        // If the object is destroyed
        public bool IsDestroyed { get; protected set; }

        // The constructor for our object
        protected GameObject(MatrixCoords topLeft, char[,] body)
        {
            this.TopLeft = topLeft;

            int imageRows = body.GetLength(0);
            int imageCols = body.GetLength(1);

            this.body = this.CopyBodyMatrix(body);

            this.IsDestroyed = false;
        }

        // Update the object coordinates
        public abstract void Update();

        // In which parts of the object the collision can be happen
        public virtual List<MatrixCoords> GetCollisionProfile()
        {
            List<MatrixCoords> profile = new List<MatrixCoords>();

            int bodyRows = this.body.GetLength(0);
            int bodyCols = this.body.GetLength(1);

            for (int row = 0; row < bodyRows; row++)
            {
                for (int col = 0; col < bodyCols; col++)
                {
                    profile.Add(new MatrixCoords(row + this.topLeft.Row, col + this.topLeft.Col));
                }
            }

            return profile;
        }

        // What will happen after collison with some other object
        public virtual void RespondToCollision(CollisionData collisionData)
        {

        }

        // Can our obect collide with other object
        public virtual bool CanCollideWith(string otherCollisionGroupString)
        {
            return GameObject.CollisionGroupString == otherCollisionGroupString;
        }

        public virtual string GetCollisionGroupString()
        {
            return GameObject.CollisionGroupString;
        }

        // Create a new copy of the object
        char[,] CopyBodyMatrix(char[,] matrixToCopy)
        {
            int rows = matrixToCopy.GetLength(0);
            int cols = matrixToCopy.GetLength(1);

            char[,] result = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = matrixToCopy[row, col];
                }
            }

            return result;
        }

        public virtual MatrixCoords GetTopLeft()
        {
            return this.TopLeft;
        }

        // How look the object in the real world
        public virtual char[,] GetImage()
        {
            return this.CopyBodyMatrix(this.body);
        }

        public virtual IEnumerable<GameObject> ProduceObjects(int col = 0)
        {
            return new List<GameObject>();
        }
    }
}
