namespace AcademyRPG
{
    public abstract class Character : MovingObject, IControllable
    {
        // Property
        public string Name { get; private set; }

        // Constructor
        public Character(string name, Point position, int owner)
            : base(position, owner)
        {
            this.Name = name;
        }

        // Method
        public override string ToString()
        {
            return base.ToString() + " " + this.Name;
        }
    }
}
