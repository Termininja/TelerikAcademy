namespace MobilePhone.Phone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Display
    {
        private decimal? size;
        private int? numberOfColors;

        public Display(decimal? size = null, int? numberOfColors = null)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }

        public decimal? Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The size can not be negative!");
                }

                this.size = value;
            }
        }

        public int? NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The number of display colors can not be negative!");
                }

                this.numberOfColors = value;
            }
        }

        public override string ToString()
        {
            var properties = new List<string>();
            this.GetType().GetProperties().ToList().ForEach(p => properties.Add(p.Name + ": " + p.GetValue(this, null)));
            var result = "(" + string.Join(", ", properties) + ")";

            return result;
        }
    }
}
