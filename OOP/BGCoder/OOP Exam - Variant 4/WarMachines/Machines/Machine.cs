using System;
using System.Collections.Generic;
using System.Text;

namespace WarMachines
{
    public abstract class Machine : IMachine
    {
        // Fields
        private string name;
        private IPilot pilot;

        // Properties
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Machine name can not be null!");
                else this.name = value;
            }
        }
        public IPilot Pilot
        {
            get { return this.pilot; }
            set
            {
                if (value != null) this.pilot = value;
            }
        }
        public double AttackPoints { get; protected set; }
        public double DefensePoints { get; protected set; }
        public double HealthPoints { get; set; }
        public IList<string> Targets { get; private set; }

        // Constructor
        public Machine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
        }

        // Methods
        public void Attack(string target)
        {
            if (target == null) throw new ArgumentNullException("Target can not be null!");
            else this.Targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("- {0}\n", this.Name);
            result.AppendFormat(" *Type: {0}\n", this.GetType().Name);
            result.AppendFormat(" *Health: {0}\n", this.HealthPoints);
            result.AppendFormat(" *Attack: {0}\n", this.AttackPoints);
            result.AppendFormat(" *Defense: {0}\n", this.DefensePoints);
            result.AppendFormat(" *Targets: {0}\n", (this.Targets.Count != 0) ? string.Join(", ", this.Targets) : "None");

            result.Append((this is Tank) ?
                " *Defense: " + (((this as Tank).DefenseMode) ? "ON" : "OFF") :
                " *Stealth: " + (((this as Fighter).StealthMode) ? "ON" : "OFF"));

            return result.ToString();
        }
    }
}
