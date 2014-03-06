namespace FurnitureManufacturer
{
    public class AdjustableChair : Chair, IAdjustableChair
    {
        // Constructor
        public AdjustableChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs) { }

        // Method
        public void SetHeight(decimal height)
        {
            this.Height = height;
        }
    }
}
