namespace Phonebook
{
    using System.Collections.Generic;

    public interface ICommand
    {
        void Execute(List<string> parameters);
    }
}