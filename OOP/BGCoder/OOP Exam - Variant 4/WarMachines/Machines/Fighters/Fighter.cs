namespace WarMachines
{
    public class Fighter : Machine, IFighter
    {
        // Property
        public bool StealthMode { get; private set; }

        // Constructor
        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints)
        {
            this.StealthMode = stealthMode;
            this.HealthPoints = 200;
        }

        // Method
        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }
    }
}
