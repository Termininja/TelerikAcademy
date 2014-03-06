using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer
{
    public abstract class Furniture : IFurniture
    {
        // Fields
        private string model;
        private decimal price;       // in [$]
        private decimal height;      // in [m]

        // Constructor
        public Furniture(string model, MaterialType materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = materialType.ToString();
            this.Price = price;
            this.Height = height;
        }

        // Properties
        public string Model
        {
            get { return this.model; }
            protected set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentNullException("Model cannot be empty, null or with less than 3 symbols!");
                }
                this.model = value;
            }
        }
        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0m)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be less or equal to $0.00!");
                }
                this.price = value;
            }
        }
        public decimal Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0m)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be less or equal to 0.00m!");
                }
                this.height = value;
            }
        }
        public string Material { get; protected set; }
        public MaterialType MaterialType { get; private set; }
    }
}
