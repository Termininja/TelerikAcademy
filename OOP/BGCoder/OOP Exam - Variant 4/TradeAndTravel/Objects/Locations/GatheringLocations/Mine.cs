namespace TradeAndTravel
{
    public class Mine : GatheringLocation
    {
        // Constructor
        public Mine(string name) : base(name, LocationType.Mine, ItemType.Iron, ItemType.Armor) { }

        // Method
        public override Item ProduceItem(string name)
        {
            return new Iron(name);
        }
    }
}
