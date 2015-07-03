namespace Events
{
    using System;
    using System.Collections.Generic;

    using Wintellect.PowerCollections;

    public class EventHolder
    {
        private Dictionary<string, Event> eventsByTitle;

        private OrderedBag<Event> eventsByDate;

        public EventHolder()
        {
            this.eventsByTitle = new Dictionary<string, Event>();
            this.eventsByDate = new OrderedBag<Event>();
        }

        public void AddEvent(DateTime date, string title, string location)
        {
            var newEvent = new Event(date, title, location);
            this.eventsByTitle.Add(title.ToLower(), newEvent);
            this.eventsByDate.Add(newEvent);

            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            var removed = 0;
            var title = titleToDelete.ToLower();
            foreach (var eventToRemove in this.eventsByTitle)
            {
                removed++;
                this.eventsByDate.Remove(eventToRemove.Value);
            }

            this.eventsByTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            var showed = 0;
            var eventsToShow = this.eventsByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
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
