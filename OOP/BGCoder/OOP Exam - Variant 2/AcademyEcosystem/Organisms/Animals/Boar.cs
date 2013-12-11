namespace AcademyEcosystem
{
    public class Boar : Animal, ICarnivore, IHerbivore
    {
        // Constructor
        public Boar(string name, Point position) : base(name, position, 4) { }

        // Methods
        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && animal.Size <= this.Size)
            {
                return animal.GetMeatFromKillQuantity();
            }
            return 0;
        }

        public int EatPlant(Plant plant)
        {
            if (plant != null)
            {
                this.Size++;
                return plant.GetEatenQuantity(2);
            }
            return 0;
        }
    }
}
