namespace WarMachines
{
    public interface IPilot
    {
        // Property
        string Name { get; }

        // Methods
        void AddMachine(IMachine machine);
        string Report();
    }
}
