namespace Phonebook
{
    using System.Collections.Generic;

    internal class ChangePhoneCommand : ICommand
    {
        private IPrinter printer;
        private IPhonebookRepository repository;
        private ISanitizer sanitizer;

        public ChangePhoneCommand(IPrinter printer, IPhonebookRepository repository, ISanitizer sanitizer)
        {
            this.printer = printer;
            this.repository = repository;
            this.sanitizer = sanitizer;
        }

        public void Execute(List<string> parameters)
        {
            var numbersChangedCount = repository.ChangePhone(sanitizer.Sanitize(parameters[0]), sanitizer.Sanitize(parameters[1]));

            printer.Print(numbersChangedCount + " numbers changed");
        }
    }
}
