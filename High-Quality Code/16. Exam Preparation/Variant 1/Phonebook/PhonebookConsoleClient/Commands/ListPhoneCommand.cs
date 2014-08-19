namespace Phonebook
{
    using System;
    using System.Collections.Generic;

    internal class ListPhoneCommand : ICommand
    {
        private IPrinter printer;
        private IPhonebookRepository repository;

        public ListPhoneCommand(IPrinter printer, IPhonebookRepository repository)
        {
            this.printer = printer;
            this.repository = repository;
        }

        public void Execute(List<string> parameters)
        {
            try
            {
                IEnumerable<PhoneBookEntry> entries = repository.ListEntries(int.Parse(parameters[0]), int.Parse(parameters[1]));
                foreach (var entry in entries)
                {
                    printer.Print(entry.ToString());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                printer.Print("Invalid range");
            }
        }
    }
}
