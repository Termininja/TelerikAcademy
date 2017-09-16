namespace RestaurantOrderingSystem
{
    public abstract class Item
    {
        public string Name { get; set; }

        public string ItemDescription { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }
    }
}
