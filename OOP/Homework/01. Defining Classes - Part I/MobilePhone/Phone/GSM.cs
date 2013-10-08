using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilePhone
{
    class GSM
    {
        // basic information
        private string model, manufacturer, owner;
        private decimal? price;
        private Display d;
        private Battery b;

        // hold the information about iPhone 4S
        private static GSM iphone4S = new GSM(
            "IPhone4S",
            "Apple",
            new Display(45, 6000),
            new Battery("M-45", 80, 14, BatteryType.LiIon)
            );

        // holds a list of the performed calls
        private List<Call> callHistory = new List<Call>();

        // constructors
        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null, null, null, null) { }

        public GSM(string model, string manufacturer, string owner, decimal? price)
            : this(model, manufacturer, owner, price, null, null) { }

        public GSM(string model, string manufacturer, Display d, Battery b)
            : this(model, manufacturer, null, null, d, b) { }

        public GSM(string model, string manufacturer, string owner, decimal? price, Display d, Battery b)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Owner = owner;
            this.Price = price;
            this.D = d;
            this.B = b;
        }

        // properties
        public string Model
        {
            get { return this.model; }
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("The model has to be minimum 1 symbol!");
                }
                else if (value.Length > 10)
                {
                    throw new ArgumentException("The model has to be maximum 10 symbols!");
                }
                else
                {
                    this.model = value;
                }
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("The manufacturer has to be minimum 1 symbol!");
                }
                else if (value.Length > 10)
                {
                    throw new ArgumentException("The manufacturer has to be maximum 10 symbols!");
                }
                else
                {
                    this.manufacturer = value;
                }
            }
        }

        public string Owner                             // optional parameter "owner"
        {
            get { return this.owner; }
            set
            {
                if (value != null)
                {
                    if (value.Length < 1)
                    {
                        throw new ArgumentException("The name has to be minimum 1 symbol!");
                    }
                    else if (value.Length > 20)
                    {
                        throw new ArgumentException("The name has to be maximum 10 symbols!");
                    }
                    else
                    {
                        this.owner = value;
                    }
                }
            }
        }

        public decimal? Price                           // optional parameter "price"
        {
            get { return this.price; }
            set
            {
                if (value != null)
                {
                    if (value < 0 || value > decimal.MaxValue)
                    {
                        throw new ArgumentOutOfRangeException("The price is not correct!");
                    }
                    else
                    {
                        this.price = value;
                    }
                }
            }
        }

        public Display D
        {
            get { return this.d; }
            set
            {
                if (value != null)
                {
                    this.d = value;
                }
            }
        }

        public Battery B
        {
            get { return this.b; }
            set
            {
                if (value != null)
                {
                    this.b = value;
                }
            }
        }

        public static GSM IPhone4S
        {
            get { return iphone4S; }                        // get information about IPhone 4S
        }

        public List<Call> CallHistory
        {
            get { return this.callHistory; }                // get information about call history
        }

        // methods
        public void AddCall(Call call)
        {
            this.callHistory.Add(call);                     // add some new call
        }

        public void DeleteCall(int index)
        {
            this.callHistory.RemoveAt(index);               // delete some call by position
        }

        public void DeleteCall(Call call)
        {
            this.callHistory.Remove(call);                  // delete some call by entry
        }

        public void ClearAllCalls()
        {
            this.callHistory.Clear();                       // clear whole call history
        }

        public decimal TotalPrice(decimal callPrice)        // calculates the total price for all calls
        {
            decimal totalPrice = 0;
            foreach (var call in this.callHistory)
            {
                totalPrice += (Convert.ToDecimal(call.Duration) / 60) * callPrice;
            }
            return totalPrice;
        }

        // String output for this class
        public override string ToString()
        {
            string result =
                "Basic information" +
                "\n\tModel: \t\t" + this.model +
                "\n\tManufacturer: \t" + this.manufacturer +
                "\n\tOwner: \t\t" + this.owner +
                "\n\tPrice: \t\t" + this.price;

            return (D == null && B == null) ?
                result : result + "\n" + this.D.ToString() + "\n" + this.B.ToString();
        }
    }
}
