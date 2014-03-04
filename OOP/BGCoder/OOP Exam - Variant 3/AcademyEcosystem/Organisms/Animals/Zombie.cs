namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        // Constructor
        public Zombie(string name, Point location) : base(name, location, 0) { }

        // Method
        public override int GetMeatFromKillQuantity()
        {
            return 10;
        }
    }
}
