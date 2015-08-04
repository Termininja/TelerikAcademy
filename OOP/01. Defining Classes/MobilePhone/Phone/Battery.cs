namespace MobilePhone.Phone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Battery
    {
        private string model;
        private int? hoursIdle;
        private int? hoursTalk;

        public Battery(string model = null, int? hoursIdle = null, int? hoursTalk = null, BatteryType? batteryType = null)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
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
                    throw new ArgumentOutOfRangeException("The battery model has to be between 2 and 20 characters long!");
                }

                this.model = value;
            }
        }

        public int? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Hours idle of the battery can not be negative!");
                }

                this.hoursIdle = value;
            }
        }

        public int? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Hours talk of the battery can not be negative!");
                }

                this.hoursTalk = value;
            }
        }

        public BatteryType? BatteryType { get; set; }

        public override string ToString()
        {
            var properties = new List<string>();
            this.GetType().GetProperties().ToList().ForEach(p => properties.Add(p.Name + ": " + p.GetValue(this, null)));
            var result = "(" + string.Join(", ", properties) + ")";

            return result;
        }
    }
}
