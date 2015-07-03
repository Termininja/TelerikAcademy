/* Code refactoring:
 * All classes are separated in different files.
 * The body of the if-else statements is wrapped in opening and closing curly brackets
 * The opening and closing curly brackets are placed on their own line
 * Adjacent elements are separated by a blank line
 * The closing curly bracket for statement which spans multiple lines is placed on its own line
 * A closing curly bracket is not preceded by a blank line
 * The opening curly bracket is not followed by a blank line
 * The else, catch, and finally statements are not preceded by a blank line
 * Statements or elements wrapped in curly brackets are followed by a blank line
 * The class, the method and the field have an access modifier
 * Fields are declared with private access
 * Public and internal fields start with an upper-case letter
 * All classes are placed after all fields and methods
 * If the method parameters are on separate lines, the first parameter begin on the line beneath the name of the method
 * All method parameters are placed on the same line, or each parameter is placed on a separate line
 * The parameters begin on the line after the previous parameter
 * The opening parenthesis or bracket are placed on the same line as the name of the method
 * The closing parenthesis or bracket are placed on the same line as the last parameter in the parameter list
 * All lines only contain a single statement
 * A member of the class begin with the 'this.' prefix
 * The code not contain multiple blank lines in a row
 * It's used the built-in type alias 'string' rather than String or System.String
 * It's used the string.Empty rather than ""
 * Fixed is invalid spacing around the opening generic bracket, closing parenthesis and the semicolon.
 * A field instances for the non-static classes are moved in their constructors.
 */

namespace Events
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        private static EventHolder events;

        public static void Main()
        {
            events = new EventHolder();

            while (ExecuteNextCommand())
            {
            }

            Console.WriteLine(Messages.GetMessage());
        }

        private static bool ExecuteNextCommand()
        {
            var command = Console.ReadLine();
            switch (command[0])
            {
                case 'A':
                    AddEvent(command);
                    break;
                case 'D':
                    DeleteEvents(command);
                    break;
                case 'L':
                    ListEvents(command);
                    break;
                default:
                    return false;
            }

            return true;
        }

        private static void ListEvents(string command)
        {
            var pipeIndex = command.IndexOf('|');
            var date = GetDate(command, "ListEvents");
            var countString = command.Substring(pipeIndex + 1);
            var count = int.Parse(countString);

            events.ListEvents(date, count);
        }

        private static void DeleteEvents(string command)
        {
            var title = command.Substring("DeleteEvents".Length + 1);

            events.DeleteEvents(title);
        }

        private static void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;
            GetParameters(command, "AddEvent", out date, out title, out location);
            events.AddEvent(date, title, location);
        }

        private static void GetParameters(
            string command,
            string commandType,
            out DateTime dateAndTime,
            out string eventTitle,
            out string eventLocation)
        {
            dateAndTime = GetDate(command, commandType);
            var firstIndex = command.IndexOf('|');
            var lastIndex = command.LastIndexOf('|');

            if (firstIndex == lastIndex)
            {
                eventTitle = command.Substring(firstIndex + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle = command.Substring(firstIndex + 1, lastIndex - firstIndex - 1).Trim();
                eventLocation = command.Substring(lastIndex + 1).Trim();
            }
        }

        private static DateTime GetDate(string command, string commandType)
        {
            var date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));

            return date;
        }
    }
}
