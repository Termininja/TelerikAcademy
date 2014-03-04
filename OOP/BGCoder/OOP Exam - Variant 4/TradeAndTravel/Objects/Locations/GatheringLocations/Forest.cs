namespace TradeAndTravel
{
    public class Forest : GatheringLocation
    {
        // Constructor
        public Forest(string name) : base(name, LocationType.Forest, ItemType.Wood, ItemType.Weapon) { }

        // Method
        public override Item ProduceItem(string name)
        {
            return new Wood(name);
        }
    }
}
