namespace Events
{
    using System;
    using System.Text;

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
            var objEvent = obj as Event;
            var compareByDate = this.date.CompareTo(objEvent.date);
            var compareByTitle = this.title.CompareTo(objEvent.title);
            var compareByLocation = this.location.CompareTo(objEvent.location);

            var result = (compareByDate == 0) ? ((compareByTitle == 0) ? compareByLocation : compareByTitle) : compareByDate;

            return result;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            result.Append(" | " + this.title);

            if (this.location != null && this.location != string.Empty)
            {
                result.Append(" | " + this.location);
            }

            return result.ToString();
        }
    }
}