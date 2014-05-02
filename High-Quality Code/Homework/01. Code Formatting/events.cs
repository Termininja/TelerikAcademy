using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class Event : IComparable
{
    // Fields
    public DateTime date;
    public String title;
    public String location;

    // Constructor
    public Event(DateTime date, String title, String location)
    {
        this.date = date;
        this.title = title;
        this.location = location;
    }

    // Methods
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
        toString.Append(date.ToString("yyyy-MM-ddTHH:mm:ss"));
        toString.Append(" | " + title);

        if (location != null && location != "")
        {
            toString.Append(" | " + location);
        }

        return toString.ToString();
    }
}

class Program
{
    static StringBuilder output = new StringBuilder();
    static EventHolder events = new EventHolder();

    #region Classes
    static class Messages
    {
        public static void EventAdded()
        {
            output.Append("Event added\n");
        }

        public static void EventDeleted(int x)
        {
            (x == 0) ?
                NoEventsFound() :
                output.AppendFormat("{0} events deleted\n", x);
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

    class EventHolder
    {
        MultiDictionary<string, Event> byTitle =
            new MultiDictionary<string, Event>(true);
        OrderedBag<Event> byDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            byTitle.Add(title.ToLower(), newEvent);
            byDate.Add(newEvent); Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            int removed = 0;
            string title = titleToDelete.ToLower();
            foreach (var eventToRemove in byTitle[title])
            {
                removed++;
                byDate.Remove(eventToRemove);
            }

            byTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            int showed = 0;
            OrderedBag<Event>.View eventsToShow =
                byDate.RangeFrom(new Event(date, "", ""), true);
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count) break;
                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
    #endregion

    #region Methods
    static void Main(string[] args)
    {
        while (ExecuteNextCommand()) { }

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
            eventLocation = "";
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
    #endregion
}