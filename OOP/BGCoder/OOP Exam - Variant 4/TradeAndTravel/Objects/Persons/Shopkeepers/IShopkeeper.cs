namespace TradeAndTravel
{
    public interface IShopkeeper
    {
        // Methods
        int CalculateSellingPrice(Item item);
        int CalculateBuyingPrice(Item item);
    }
}
