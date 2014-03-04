namespace AcademyRPG
{
    public class House : StaticObject
    {
        // Constructor
        public House(Point position, int owner)
            : base(position, owner)
        {
            this.HitPoints = 500;
        }
    }
}