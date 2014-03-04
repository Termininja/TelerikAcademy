using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WarMachines
{
    public class Pilot : IPilot
    {
        // Fields
        private string name;
        private IList<IMachine> machines;

        // Property
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Pilot name can not be null!");
                else this.name = value;
            }
        }

        // Constructor
        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        // Methods
        public void AddMachine(IMachine machine)
        {
            if (machine == null) throw new ArgumentNullException("Machine can not be null!");
            else this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0} - ", this.Name);

            int machines = this.machines.Count;
            result.Append((machines != 0) ? (machines + ((machines == 1) ? " machine" : " machines")) : "no machines");

            if (machines != 0)
            {
                foreach (IMachine machine in this.machines.OrderBy(m => m.HealthPoints).ThenBy(m => m.Name))
                {
                    result.AppendFormat("\n{0}", machine);
                }
            }

            return result.ToString();
        }
    }
}