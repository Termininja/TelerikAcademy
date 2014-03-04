using System.Collections.Generic;

namespace TradeAndTravel
{
    public class Wood : Item
    {
        // Field
        const int GeneralWoodValue = 2;

        // Constructor
        public Wood(string name, Location location = null)
            : base(name, Wood.GeneralWoodValue, ItemType.Wood, location) { }

        // Methods
        public override void UpdateWithInteraction(string interaction)
        {
            if (this.Value > 0 && interaction == "drop") this.Value--;
            base.UpdateWithInteraction(interaction);
        }
    }
}