namespace AcademyRPG
{
    public abstract class MovingObject : WorldObject
    {
        // Constructor
        public MovingObject(Point position, int owner) : base(position, owner) { }

        // Method
        public void GoTo(Point destination)
        {
            this.Position = destination;
        }
    }
}
