namespace RestaurantOrderingSystem
{
    using System;

    public class Reservation
    {
        public string Name { get; set; }

        public int PhoneNumber { get; set; }

        public DateTime Date { get; set; }

        public byte NumberOfPeople { get; set; }

        public string Request { get; set; }
    }
}