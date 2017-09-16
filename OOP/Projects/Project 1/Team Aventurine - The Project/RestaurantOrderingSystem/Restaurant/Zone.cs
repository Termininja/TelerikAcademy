namespace RestaurantOrderingSystem
{
    using System.Collections.Generic;

    public class Zone
    {
        public string Name { get; set; }

        public Restaurant Restaurant { get; set; }

        public List<Table> Tables { get; set; }
    }
}
