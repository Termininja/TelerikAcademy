using System.Collections.Generic;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {
        public new const string CollisionGroupString = "explodingBlock";

        // The symbol of the exploding block
        public const char Symbol = '☼';

        // Constructor
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = ExplodingBlock.Symbol;
        }

        // The block will be destroyed after collision
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            ProduceObjects();
        }

        public override IEnumerable<GameObject> ProduceObjects(int col = 0)
        {
            if (this.IsDestroyed == true)
            {
                List<GameObject> explode = new List<GameObject>();

                explode.Add(new Fragment(this.topLeft + new MatrixCoords(-1, -1), new MatrixCoords(-1, -1)));
                explode.Add(new Fragment(this.topLeft + new MatrixCoords(-1, 0), new MatrixCoords(-1, 0)));
                explode.Add(new Fragment(this.topLeft + new MatrixCoords(-1, 1), new MatrixCoords(-1, 1)));
                explode.Add(new Fragment(this.topLeft + new MatrixCoords(0, 1), new MatrixCoords(0, 1)));
                explode.Add(new Fragment(this.topLeft + new MatrixCoords(1, 0), new MatrixCoords(1, 0)));
                explode.Add(new Fragment(this.topLeft + new MatrixCoords(1, -1), new MatrixCoords(1, -1)));
                explode.Add(new Fragment(this.topLeft + new MatrixCoords(0, -1), new MatrixCoords(0, -1)));
                explode.Add(new Fragment(this.topLeft + new MatrixCoords(1, 1), new MatrixCoords(1, 1)));

                return explode;
            }
            else return base.ProduceObjects();
        }

        // Collision information for this block
        public override string GetCollisionGroupString()
        {
            return ExplodingBlock.CollisionGroupString;
        }
    }
}
