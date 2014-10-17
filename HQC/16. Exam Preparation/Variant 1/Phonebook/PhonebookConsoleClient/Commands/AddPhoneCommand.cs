namespace Phonebook
{
    using System.Collections.Generic;

    internal class AddPhoneCommand : ICommand
    {
        private IPrinter printer;
        private IPhonebookRepository repository;
        private ISanitizer sanitizer;

        public AddPhoneCommand(IPrinter printer, IPhonebookRepository repository, ISanitizer sanitizer)
        {
            this.printer = printer;
            this.repository = repository;
            this.sanitizer = sanitizer;
        }

        public void Execute(List<string> parameters)
        {
            string entryName = parameters[0];

            for (int i = 0; i < parameters.Count; i++)
            {
                parameters[i] = sanitizer.Sanitize(parameters[i]);
            }

            bool isNew = repository.AddPhone(entryName, parameters);

            if (isNew)
            {
                printer.Print("Phone entry created");
            }
            else
            {
                printer.Print("Phone entry merged");
            }
        }
    }
}
