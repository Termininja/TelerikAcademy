using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilePhone
{
    public class Call               // holds a call performed through each one GSM
    {
        private DateTime dateTime;
        private string dialedNumber;
        private int duration;       // in seconds

        // constructors
        public Call() { }

        public Call(DateTime dateTime, string dialedNumber, int duration)
        {
            this.DateTime = dateTime;
            this.DialedNumber = dialedNumber;
            this.Duration = duration;
        }

        // properties
        public DateTime DateTime
        {
            get { return this.dateTime; }
            set { this.dateTime = value; }
        }

        public string DialedNumber
        {
            get { return this.dialedNumber; }
            set { this.dialedNumber = value; }
        }

        public int Duration
        {
            get { return this.duration; }
            set { this.duration = value; }
        }

        // methods
        public override string ToString()
        {
            return
                "Call information" +
                "\n\tDate: \t\t" + this.dateTime +
                "\n\tDialed Number: \t" + this.dialedNumber +
                "\n\tDuration: \t" + this.duration + " sec";
        }
    }
}
