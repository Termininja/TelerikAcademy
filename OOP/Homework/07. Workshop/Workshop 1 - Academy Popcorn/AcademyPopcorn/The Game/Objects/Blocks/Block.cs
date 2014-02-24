namespace AcademyPopcorn
{
    public class Block : GameObject
    {
        public new const string CollisionGroupString = "block";

        // Constructor
        public Block(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '▒' } }) { }

        // The position of the block is not changed
        public override void Update() { }

        // The block can collide only with ball
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "ball";
        }

        // The block will be destroyed after collision
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return Block.CollisionGroupString;
        }
    }
}
