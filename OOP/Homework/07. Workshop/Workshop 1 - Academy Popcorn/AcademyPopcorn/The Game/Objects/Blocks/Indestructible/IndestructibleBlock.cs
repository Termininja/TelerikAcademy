namespace AcademyPopcorn
{
    public class IndestructibleBlock : Block
    {
        public new const string CollisionGroupString = "indestructibleBlock";

        // The symbol of the indestructible block
        public const char Symbol = '█';

        // Constructor
        public IndestructibleBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = IndestructibleBlock.Symbol;
        }

        // Nothing will happen after collision
        public override void RespondToCollision(CollisionData collisionData) { }

        // Collision information for this block
        public override string GetCollisionGroupString()
        {
            return IndestructibleBlock.CollisionGroupString;
        }
    }
}
