using System.Collections.Generic;

namespace AcademyPopcorn
{
    class GiftBlock : Block
    {
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = '♥';
        }

        // The gift will be destroyed after collision
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                List<GameObject> gift = new List<GameObject>();
                gift.Add(new Gift(this.topLeft));
                return gift;
            }
            return new List<GameObject>();
        }
    }
}