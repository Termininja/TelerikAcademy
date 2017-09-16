namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhoneBookEntry : IComparable<PhoneBookEntry>
    {
        private string name;

        private string nameInLowerCase;

        public PhoneBookEntry(string name)
        {
            this.Name = name;
            this.PhoneNumbers = new SortedSet<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be null!");
                }

                this.name = value;
                this.nameInLowerCase = value.ToLowerInvariant();
            }
        }

        public SortedSet<string> PhoneNumbers { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append('[');
            result.Append(this.Name);
            result.Append(": ");
            result.Append(string.Join(", ", this.PhoneNumbers));
            result.Append(']');

            return result.ToString();
        }

        public int CompareTo(PhoneBookEntry other)
        {
            return this.nameInLowerCase.CompareTo(other.nameInLowerCase);
        }
    }
}