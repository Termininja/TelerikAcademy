namespace RestaurantOrderingSystem
{
    using System;

    public class Order
    {
        public string ID { get; set; }

        public Table Table { get; set; }

        public decimal VAT { get; set; }

        public decimal TotalPrice { get; set; }

        public int CookTime { get; set; }

        public Item[] Items { get; set; }

        public bool Paid { get; set; }

        public DateTime TimeToLive { get; set; }

        public DateTime Date { get; set; }

        public OrderState OrderState { get; set; }

        public bool IsCooked()
        {
            return false;
        }

        public bool IsPaid()
        {
            return false;
        }
    }
}
