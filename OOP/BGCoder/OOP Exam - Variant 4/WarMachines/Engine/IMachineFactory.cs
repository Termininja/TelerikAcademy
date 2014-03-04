namespace WarMachines
{
    public interface IMachineFactory
    {
        // Methods
        IPilot HirePilot(string name);
        ITank ManufactureTank(string name, double attackPoints, double defensePoints);
        IFighter ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode);
    }
}
