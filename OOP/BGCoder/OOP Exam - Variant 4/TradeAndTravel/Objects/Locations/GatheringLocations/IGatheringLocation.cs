namespace TradeAndTravel
{
    public interface IGatheringLocation
    {
        // Properties
        ItemType GatheredType { get; }
        ItemType RequiredItem { get; }

        // Methods
        Item ProduceItem(string name);
    }
}
