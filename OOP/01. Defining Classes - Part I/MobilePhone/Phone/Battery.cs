using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilePhone
{
    public enum BatteryType { LiIon, NiMH, NiCd }       // creates a new type called "BatteryType"

    public class Battery
    {
        // Battery characteristics
        private string model;
        private uint? idle, talk;
        private BatteryType? type;                      // adds a new parameter "type"

        // constructors
        public Battery() { }                            // without parameters

        public Battery(BatteryType? type) : this(null, null, null, type) { }

        public Battery(string model, uint? idle, uint? talk, BatteryType? type)
        {
            this.Model = model;
            this.IdleTime = idle;                       // hours idle
            this.TalkTime = talk;                       // hours talk
            this.Type = type;
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

        public uint? IdleTime
        {
            get { return this.idle; }
            set
            {
                if (value > 1000)
                {
                    throw new ArgumentOutOfRangeException("Hours idle is too big!");
                }
                else
                {
                    this.idle = value;
                }
            }
        }

        public uint? TalkTime
        {
            get { return this.talk; }
            set
            {
                if (value > 100)
                {
                    throw new ArgumentOutOfRangeException("Hours talk is too big!");
                }
                else
                {
                    this.talk = value;
                }
            }
        }

        public BatteryType? Type
        {
            get { return this.type; }
            set
            {
                if (value.ToString() != "LiIon" && value.ToString() != "NiMH" && value.ToString() != "NiCd")
                {
                    throw new ArgumentException("This is not valid battery type!");
                }
                else
                {
                    this.type = value;
                }
            }
        }

        // methods
        public override string ToString()
        {
            return
                "\nBattery information" +
                "\n\tModel: \t\t" + this.model +
                "\n\tIdle time: \t" + this.idle +
                "\n\tTalk time: \t" + this.talk +
                "\n\tType: \t\t" + this.type;
        }
    }
}
