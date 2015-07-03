namespace Events
{
    using System.Text;

    public static class Messages
    {
        private static StringBuilder output = new StringBuilder();

        public static void EventAdded()
        {
            output.Append("Event added\n");
        }

        public static void EventDeleted(int numberOfEvents)
        {
            if (numberOfEvents == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendFormat("{0} events deleted\n", numberOfEvents);
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

        public static string GetMessage()
        {
            return output.ToString();
        }
    }
}
