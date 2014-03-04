namespace TradeAndTravel
{
    public class Shopkeeper : Person, IShopkeeper
    {
        // Constructor
        public Shopkeeper(string name, Location location) : base(name, location) { }

        // Methods
        public virtual int CalculateSellingPrice(Item item)
        {
            return item.Value;
        }

        public virtual int CalculateBuyingPrice(Item item)
        {
            return item.Value / 2;
        }
    }
}
