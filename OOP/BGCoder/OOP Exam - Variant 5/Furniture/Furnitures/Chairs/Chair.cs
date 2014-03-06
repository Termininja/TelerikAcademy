using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer
{
    public class Chair : Furniture, IChair
    {
        // Property
        public int NumberOfLegs { get; protected set; }

        // Constructor
        public Chair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        // Method
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs);

            return result.ToString();
        }
    }
}
