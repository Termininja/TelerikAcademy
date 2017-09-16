namespace RestaurantOrderingSystem
{
    using System.Collections.Generic;

    public class Restaurant
    {
        public NameStruct Name { get; set; }

        public string Address { get; set; }

        public Corporate Corporate { get; set; }

        public List<Zone> Zones { get; set; }

        public List<Employee> Personnel { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}