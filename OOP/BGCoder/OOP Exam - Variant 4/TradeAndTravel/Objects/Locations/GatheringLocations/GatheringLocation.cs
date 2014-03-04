using System;

namespace TradeAndTravel
{
    public abstract class GatheringLocation : Location, IGatheringLocation
    {
        // Constructor
        public GatheringLocation(string name, LocationType location, ItemType gatheredType, ItemType requiredItem)
            : base(name, location)
        {
            this.GatheredType = gatheredType;
            this.RequiredItem = requiredItem;
        }

        // Properties
        public ItemType GatheredType { get; protected set; }
        public ItemType RequiredItem { get; protected set; }

        // Method
        public virtual Item ProduceItem(string name)
        {
            throw new NotImplementedException();
        }
    }
}
