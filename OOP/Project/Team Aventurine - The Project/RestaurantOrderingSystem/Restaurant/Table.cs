namespace RestaurantOrderingSystem
{
    using System.Collections.Generic;

    public class Table
    {
        public Zone Zone { get; set; }

        public List<Client> Clients { get; set; }
    }
}
