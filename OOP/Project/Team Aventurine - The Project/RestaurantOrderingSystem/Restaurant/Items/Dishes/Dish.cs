namespace RestaurantOrderingSystem
{
    public class Dish : Item
    {
        public DishType DishType { get; set; }

        public string[] Ingredients { get; set; }

        public double TimeToCook { get; set; }
    }
}
