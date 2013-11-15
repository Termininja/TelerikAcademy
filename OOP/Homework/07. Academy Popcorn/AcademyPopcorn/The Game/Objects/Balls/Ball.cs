namespace AcademyPopcorn
{
    public class Ball : MovingObject
    {
        public new const string CollisionGroupString = "ball";

        // Constructor
        public Ball(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] { { 'o' } }, speed) { }

        // The ball can collide only with racket and block
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "block";
        }

        public override string GetCollisionGroupString()
        {
            return Ball.CollisionGroupString;
        }

        // Change direction after collision
        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0) this.Speed.Row *= -1;
            if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0) this.Speed.Col *= -1;
        }
    }
}
