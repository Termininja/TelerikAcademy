namespace WarMachines
{
    public class Tank : Machine, ITank
    {
        // Property
        public bool DefenseMode { get; private set; }

        // Constructor
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = 100;
            this.ToggleDefenseMode();
        }

        // Method
        public void ToggleDefenseMode()
        {
            this.DefensePoints += (this.DefenseMode) ? -30 : +30;
            this.AttackPoints += (this.DefenseMode) ? +40 : -40;
            this.DefenseMode = !this.DefenseMode;
        }
    }
}
