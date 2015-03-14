namespace MobilePhone.Phone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GSM
    {
        private string model;
        private string manufacturer;
        private decimal? price;

        /// <summary>
        /// Holds the information about iPhone 4S.
        /// </summary>
        private static GSM iPhone4S = new GSM(
            "IPhone4S", "Apple", 344, "Nobody",
            new Battery("M-45", 80, 14, BatteryType.LiIon),
            new Display(45, 6000)
            );

        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;

            this.CallHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, decimal? price = null, string owner = null, Battery battery = null, Display display = null)
            : this(model, manufacturer)
        {
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentOutOfRangeException("The GSM model has to be between 2 and 20 characters long!");
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentOutOfRangeException("The GSM manufacturer has to be between 2 and 20 characters long!");
                }

                this.manufacturer = value;
            }
        }

        public decimal? Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The GSM price can not be negative!");
                }

                price = value;
            }
        }

        public string Owner { get; set; }

        public Battery Battery { get; set; }

        public Display Display { get; set; }

        /// <summary>
        ///  Holds a list of the performed calls.
        /// </summary>
        public List<Call> CallHistory { get; set; }

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        /// <summary>
        /// Adds call to the call history.
        /// </summary>
        /// <param name="call">The call should be added to the call history.</param>
        public void AddCall(Call call)
        {
            this.CallHistory.Add(call);
        }

        /// <summary>
        /// Deletes call from the call history.
        /// </summary>
        /// <param name="call">The call should be deleted from the call history.</param>
        public void DeleteCall(Call call)
        {
            this.CallHistory.Remove(call);
        }

        /// <summary>
        /// Clears the whole call history.
        /// </summary>
        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }

        /// <summary>
        /// Calculates the total price of the calls in the call history.
        /// </summary>
        /// <param name="pricePerMinute">The fixed price for one minute.</param>
        /// <returns>Returns the total price of all performed calls.</returns>
        public decimal TotalPrice(decimal pricePerMinute)
        {
            var totalPrice = 0m;
            this.CallHistory.ForEach(call => totalPrice += call.Duration * pricePerMinute / 60);

            return totalPrice;
        }

        public override string ToString()
        {
            var result = new List<string>();
            var properties = this.GetType().GetProperties().ToList();
            properties.RemoveRange(properties.Count - 2, 2);
            properties.ForEach(p => result.Add(p.Name + ": " + p.GetValue(this, null)));

            return string.Join("\n", result);
        }
    }
}
