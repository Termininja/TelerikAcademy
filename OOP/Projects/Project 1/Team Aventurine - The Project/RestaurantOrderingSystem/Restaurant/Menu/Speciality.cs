namespace RestaurantOrderingSystem
{
    using System.Collections.Generic;

    public class Speciality
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public List<Item> Items { get; set; }
    }
}
