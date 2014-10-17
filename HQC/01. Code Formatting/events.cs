/* Code refactoring:
 * 
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
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

public class Event : IComparable
{
    private DateTime date;
    private string title;
    private string location;

    public Event(DateTime date, string title, string location)
    {
        this.date = date;
        this.title = title;
        this.location = location;
    }

    public int CompareTo(object obj)
    {
        Event other = obj as Event;
        int byDate = this.date.CompareTo(other.date);
        int byTitle = this.title.CompareTo(other.title);
        int byLocation = this.location.CompareTo(other.location);

        return (byDate == 0) ?
            ((byTitle == 0) ? byLocation : byTitle) :
            byDate;
    }

    public override string ToString()
    {
        StringBuilder toString = new StringBuilder();
        toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
        toString.Append(" | " + this.title);

        if (this.location != null && this.location != string.Empty)
        {
            toString.Append(" | " + this.location);
        }

        return toString.ToString();
    }
}

public class Program
{
    private static StringBuilder output = new StringBuilder();
    private static EventHolder events = new EventHolder();

    public static void Main()
    {
        while (ExecuteNextCommand())
        {
        }

        Console.WriteLine(output);
    }

    private static bool ExecuteNextCommand()
    {
        string command = Console.ReadLine();
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
        int pipeIndex = command.IndexOf('|');
        DateTime date = GetDate(command, "ListEvents");
        string countString = command.Substring(pipeIndex + 1);
        int count = int.Parse(countString);
        events.ListEvents(date, count);
    }

    private static void DeleteEvents(string command)
    {
        string title = command.Substring("DeleteEvents".Length + 1);
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

    private static void GetParameters(string command, string commandType,
        out DateTime dateAndTime, out string eventTitle, out string eventLocation)
    {
        dateAndTime = GetDate(command, commandType);
        int firstIndex = command.IndexOf('|');
        int lastIndex = command.LastIndexOf('|');

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
        return DateTime.Parse(command.Substring(commandType.Length + 1, 20));
    }

    public static class Messages
    {
        public static void EventAdded()
        {
            output.Append("Event added\n");
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendFormat("{0} events deleted\n", x);
            }
        }

        public static void NoEventsFound()
        {
            output.Append("No events found\n");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + "\n");
            }
        }
    }

    public class EventHolder
    {
        private Dictionary<string, Event> byTitle =
              new Dictionary<string, Event>(true);

        private OrderedBag<Event> byDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            this.byTitle.Add(title.ToLower(), newEvent);
            this.byDate.Add(newEvent);
            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            int removed = 0;
            string title = titleToDelete.ToLower();
            foreach (var eventToRemove in this.byTitle[title])
            {
                removed++;
                this.byDate.Remove(eventToRemove);
            }

            this.byTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            int showed = 0;
            OrderedBag<Event>.View eventsToShow =
                this.byDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}