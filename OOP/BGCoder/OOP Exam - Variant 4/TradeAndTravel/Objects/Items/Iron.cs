using System.Collections.Generic;

namespace TradeAndTravel
{
    public class Iron : Item
    {
        // Field
        const int GeneralIronValue = 3;

        // Constructor
        public Iron(string name, Location location = null)
            : base(name, GeneralIronValue, ItemType.Iron, location) { }
    }
}
