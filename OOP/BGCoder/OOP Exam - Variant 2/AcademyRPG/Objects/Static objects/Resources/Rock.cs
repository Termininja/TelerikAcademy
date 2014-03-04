namespace AcademyRPG
{
    public class Rock : StaticObject, IResource
    {
        // Constructor
        public Rock(int hitPoints, Point position)
            : base(position)
        {
            this.HitPoints = hitPoints;
        }

        // Properties
        public ResourceType Type
        {
            get
            {
                return ResourceType.Stone;
            }
        }

        public int Quantity
        {
            get
            {
                return this.HitPoints / 2;
            }
        }
    }
}
