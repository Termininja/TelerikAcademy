namespace TradeAndTravel
{
    public class Traveller : Person, ITraveller
    {
        // Constructor
        public Traveller(string name, Location location) : base(name, location) { }

        // Method
        public virtual void TravelTo(Location location)
        {
            this.Location = location;
        }
    }
}
