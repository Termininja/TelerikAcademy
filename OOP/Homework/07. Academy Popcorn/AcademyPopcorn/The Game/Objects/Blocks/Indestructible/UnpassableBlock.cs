namespace AcademyPopcorn
{
    public class UnpassableBlock : Block
    {
        public new const string CollisionGroupString = "unpassableBlock";

        // The symbol of the unpassable block
        public const char Symbol = '▓';

        // Constructor
        public UnpassableBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = UnpassableBlock.Symbol;
        }

        // Nothing will happen after collision
        public override void RespondToCollision(CollisionData collisionData) { }

        // Collision information for this block
        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }
    }
}