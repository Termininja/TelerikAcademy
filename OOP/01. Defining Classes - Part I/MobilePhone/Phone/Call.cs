namespace MobilePhone.Phone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Call
    {
        private string dialledPhoneNumber;

        public Call(DateTime dateTime, string dialledPhoneNumber, int duration)
        {
            this.DateTime = dateTime;
            this.DialledPhoneNumber = dialledPhoneNumber;
            this.Duration = duration;
        }

        public DateTime DateTime { get; set; }

        public int Duration { get; set; }

        public string DialledPhoneNumber
        {
            get
            {
                return this.dialledPhoneNumber;
            }
            set
            {
                if (value.Length < 5 || value.Length > 15)
                {
                    throw new ArgumentOutOfRangeException("The dialled phone number has to be between 5 and 15 characters long!");
                }

                this.dialledPhoneNumber = value;
            }
        }

        public override string ToString()
        {
            var properties = new List<string>();
            this.GetType().GetProperties().ToList().ForEach(p => properties.Add(p.Name + ": " + p.GetValue(this, null)));
            var result = string.Join(", ", properties);

            return result;
        }
    }
}
