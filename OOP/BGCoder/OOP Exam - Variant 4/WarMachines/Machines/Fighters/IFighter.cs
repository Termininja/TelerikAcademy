namespace WarMachines
{
    public interface IFighter : IMachine
    {
        // Property
        bool StealthMode { get; }

        // Method
        void ToggleStealthMode();
    }
}