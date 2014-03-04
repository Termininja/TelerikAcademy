using System.Collections.Generic;

namespace WarMachines
{
    public interface ICommand
    {
        // Properties
        string Name { get; }
        IList<string> Parameters { get; }
    }
}
