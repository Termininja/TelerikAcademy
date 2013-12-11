namespace AcademyEcosystem
{
    public class Wolf : Animal, ICarnivore
    {
        // Constructor
        public Wolf(string name, Point location) : base(name, location, 4) { }

        // Method
        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && (animal.Size <= this.Size || animal.State == AnimalState.Sleeping))
            {
                return animal.GetMeatFromKillQuantity();
            }
            return 0;
        }
    }
}
