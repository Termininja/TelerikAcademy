using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer
{
    public class Table : Furniture, ITable
    {
        // Field
        private decimal area;

        // Properties
        public decimal Length { get; protected set; }       // in [m]
        public decimal Width { get; protected set; }        // in [m]
        public decimal Area
        {
            get
            {
                return this.Length * this.Width;
            }
            protected set
            {
                this.area = value;
            }
        }

        // Constructor
        public Table(string model, MaterialType materialType, decimal price, decimal height, decimal length, decimal width)
            : base(model, materialType, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        // Method
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.Length, this.Width, this.Area);

            return result.ToString();
        }
    }
}
