using System;
using System.Text;

namespace FurnitureManufacturer
{
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        // Field
        private decimal OriginalHeight;

        // Property
        public bool IsConverted { get; protected set; }     // [true: converted]; [false: normal]

        // Constructor
        public ConvertibleChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.OriginalHeight = this.Height;
        }

        // Methods
        public void Convert()
        {
            this.Height = (this.IsConverted) ? this.OriginalHeight : 0.1m;

            this.IsConverted = !this.IsConverted;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4:0.00}, Legs: {5}, State: {6}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs, this.IsConverted ? "Converted" : "Normal");

            return result.ToString();
        }
    }
}
