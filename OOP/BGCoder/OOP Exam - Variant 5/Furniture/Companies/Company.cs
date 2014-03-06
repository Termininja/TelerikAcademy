using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer
{
    public class Company : ICompany
    {
        // Fields
        private string name;
        private string registrationNumber;

        // Constructor
        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.Furnitures = new List<IFurniture>();
        }

        // Properties
        public string Name
        {
            get { return this.name; }
            protected set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentNullException("Name cannot be empty, null or with less than 5 symbols!");
                }
                this.name = value;
            }
        }
        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            protected set
            {
                if (value.Length != 10 || !IsNumber(value))
                {
                    throw new ArgumentException("Registration number must be exactly 10 symbols and must contain only digits!");
                }
                this.registrationNumber = value;
            }
        }
        public ICollection<IFurniture> Furnitures { get; protected set; }

        // Methods
        bool IsNumber(string s)
        {
            return s.Length > 0 && s.All(c => Char.IsDigit(c));
        }

        public void Add(IFurniture furniture)
        {
            this.Furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            foreach (var furniture in this.Furnitures)
            {
                if (furniture.Model.ToLower() == model.ToLower())
                {
                    return furniture;
                }
            }
            return null;
        }

        public string Catalog()
        {
            StringBuilder result = new StringBuilder();

            int furnitures = this.Furnitures.Count;
            result.AppendFormat("{0} - {1} - {2} {3}",
                this.Name, this.RegistrationNumber,
                furnitures != 0 ? furnitures.ToString() : "no", furnitures != 1 ? "furnitures" : "furniture"
                );

            foreach (IFurniture furniture in this.Furnitures.OrderBy(m => m.Price).ThenBy(m => m.Model))
            {
                if (furniture != null)
                {
                    result.AppendFormat("\n{0}", furniture);
                }
            }

            return result.ToString();
        }
    }
}
