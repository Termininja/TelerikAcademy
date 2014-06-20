//Task 1: Refactor the following class using best practices for organizing straight-line code.

namespace Cooking
{
    using System;

    public class Chef
    {
        public void Cook()
        {
            Potato potato = GetPotato();
            Carrot carrot = GetCarrot();

            Peel(potato);
            Peel(carrot);
            Cut(potato);
            Cut(carrot);

            Bowl bowl = GetBowl();
            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private void Peel(Vegetable vegetable)
        {
            vegetable.IsPeeled = true;
            Console.WriteLine("Peeling " + vegetable.GetType().Name);
        }

        private void Cut(Vegetable vegetable)
        {
            vegetable.IsCuted = true;
            Console.WriteLine("Cutting " + vegetable.GetType().Name);
        }
    }
}