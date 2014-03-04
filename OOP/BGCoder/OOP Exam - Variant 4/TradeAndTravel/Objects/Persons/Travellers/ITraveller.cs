namespace TradeAndTravel
{
    public interface ITraveller
    {
        // Property
        Location Location { get; }

        // Method
        void TravelTo(Location location);
    }
}
