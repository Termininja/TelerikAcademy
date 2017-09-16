namespace RestaurantOrderingSystem
{
    public class InStoreClient : Client
    {
        public InStoreClient(string name) : base(name) { }

        public Table Table { get; set; }
    }
}
