namespace AcademyRPG
{
    public class Tree : StaticObject, IResource
    {
        // Properties
        protected int Size { get; private set; }

        public ResourceType Type
        {
            get
            {
                return ResourceType.Lumber;
            }
        }

        public int Quantity
        {
            get
            {
                return this.Size;
            }
        }

        // Constructor
        public Tree(int size, Point position)
            : base(position)
        {
            this.Size = size;
            this.HitPoints = size;
        }
    }
}
