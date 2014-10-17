namespace Phonebook
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class PhonebookEntryPoint
    {
        private static IPhonebookRepository repository = new Repository();

        public static void Main()
        {
            IPrinter printer = new StringBuilderPrinter();
            ISanitizer sanitizer = new PhoneSanitizer();

            while (true)
            {
                string currentCommand = Console.ReadLine();
                if (currentCommand == "End" || currentCommand == null)
                {
                    break;
                }

                int indexOfFirstOpeningBracket = currentCommand.IndexOf('(');
                if (indexOfFirstOpeningBracket == -1)
                {
                    throw new ArgumentException("Invalid command. It should have '(' for parameters!");
                }

                if (!currentCommand.EndsWith(")"))
                {
                    throw new ArgumentException("Invalid command. It should have ')' for parameters!");
                }

                string commandName = currentCommand.Substring(0, indexOfFirstOpeningBracket);

                string parameters = currentCommand.Substring(indexOfFirstOpeningBracket + 1, currentCommand.Length - indexOfFirstOpeningBracket - 2);
                var strings = parameters.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(m => m.Trim()).ToList();

                ICommand command;
                if (commandName.StartsWith("AddPhone") && strings.Count >= 2)
                {
                    command = new AddPhoneCommand(printer, repository, sanitizer);
                }
                else if (commandName == "ChangePhone" && strings.Count == 2)
                {
                    command = new ChangePhoneCommand(printer, repository, sanitizer);
                }
                else if (commandName == "List" && strings.Count == 2)
                {
                    command = new ListPhoneCommand(printer, repository);
                }
                else
                {
                    throw new InvalidOperationException("Invalid command name!");
                }

                command.Execute(strings);
            }

            Console.Write(printer.GetAllText());
        }
    }
}