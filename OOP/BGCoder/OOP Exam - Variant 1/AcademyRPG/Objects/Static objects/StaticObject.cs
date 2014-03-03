namespace AcademyRPG
{
    public abstract class StaticObject : WorldObject
    {
        // Constructor
        public StaticObject(Point position, int owner = 0) : base(position, owner) { }
    }
}
