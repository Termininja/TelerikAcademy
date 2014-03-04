namespace TradeAndTravel
{
    public class Merchant : Shopkeeper, ITraveller
    {
        // Constructor
        public Merchant(string name, Location location) : base(name, location) { }

        // Method
        public void TravelTo(Location location)
        {
            this.Location = location;
        }
    }
}
