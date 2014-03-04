namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore
    {
        // Constructor
        public Lion(string name, Point location) : base(name, location, 6) { }

        // Method
        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && animal.Size <= 2 * this.Size)
            {
                this.Size++;
                return animal.GetMeatFromKillQuantity();
            }
            return 0;
        }
    }
}
