using System.Collections.Generic;

namespace WarMachines
{
    public interface IMachine
    {
        // Properties
        string Name { get; set; }
        IPilot Pilot { get; set; }
        double HealthPoints { get; set; }
        double AttackPoints { get; }
        double DefensePoints { get; }
        IList<string> Targets { get; }

        // Methods
        void Attack(string target);
        string ToString();
    }
}
