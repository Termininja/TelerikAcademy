namespace RestaurantOrderingSystem
{
    using System;
    using System.Collections.Generic;

    public class Menu
    {
        public string Name { get; set; }

        public Speciality Speciality { get; set; }

        public List<Item> Items { get; set; }

        public DateTime Date { get; set; }
    }
}
