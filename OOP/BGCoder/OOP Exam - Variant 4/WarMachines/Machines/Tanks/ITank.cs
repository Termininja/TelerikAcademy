namespace WarMachines
{
    public interface ITank : IMachine
    {
        // Property
        bool DefenseMode { get; }

        // Method
        void ToggleDefenseMode();
    }
}
