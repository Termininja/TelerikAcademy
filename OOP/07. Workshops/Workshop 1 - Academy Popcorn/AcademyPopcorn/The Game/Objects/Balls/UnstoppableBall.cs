namespace AcademyPopcorn
{
    // The unstopable ball only bounces off unpassable blocks and will destroy any other block it passes through
    class UnstoppableBall : Ball
    {
        public new const string CollisionGroupString = "unstoppableBall";

        // Constructor
        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            // The symbol of unstoppable ball
            this.body[0, 0] = 'O';
        }

        // The unstoppable ball can collide only with racket, block and unpassableBlock
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return
                otherCollisionGroupString == "racket" ||
                otherCollisionGroupString == "block" ||
                otherCollisionGroupString == "indestructibleBlock" ||
                otherCollisionGroupString == "unpassableBlock";
        }

        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }

        // Change direction after collision
        public override void RespondToCollision(CollisionData collisionData)
        {
            if (
                collisionData.hitObjectsCollisionGroupStrings.Contains("racket") ||
                collisionData.hitObjectsCollisionGroupStrings.Contains("unpassableBlock") ||
                collisionData.hitObjectsCollisionGroupStrings.Contains("indestructibleBlock"))
            {
                if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0) this.Speed.Row *= -1;
                if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0) this.Speed.Col *= -1;
            }
        }
    }
}