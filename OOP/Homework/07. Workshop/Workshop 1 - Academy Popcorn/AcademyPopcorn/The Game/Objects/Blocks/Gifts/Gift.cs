using System.Collections.Generic;

namespace AcademyPopcorn
{
    class Gift : MovingObject
    {
        // Constructor
        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '♥' } }, new MatrixCoords(1, 0)) { }

        // The gift will be destroyed after collision
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        public override IEnumerable<GameObject> ProduceObjects(int col)
        {
            List<GameObject> produceObjects = new List<GameObject>();
            if (this.IsDestroyed)
            {
                produceObjects.Add(new ShootingRacket(new MatrixCoords(25, col), 6));
            }
            return produceObjects;
        }
    }
}