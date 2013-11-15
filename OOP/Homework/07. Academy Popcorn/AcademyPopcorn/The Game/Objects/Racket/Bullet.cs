namespace AcademyPopcorn
{
    class Bullet : MovingObject
    {
        // Constructor
        public Bullet(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '|' } }, new MatrixCoords(-1, 0)) { }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}
