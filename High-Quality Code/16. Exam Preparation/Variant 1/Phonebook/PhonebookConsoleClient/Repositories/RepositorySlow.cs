namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RepositorySlow : IPhonebookRepository
    {
        private IList<PhoneBookEntry> entries;

        public RepositorySlow()
            : this(new List<PhoneBookEntry>())
        {
        }

        public RepositorySlow(IList<PhoneBookEntry> entries)
        {
            this.entries = entries;
        }

        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            var entry = this.entries.FirstOrDefault(m => m.Name.ToLowerInvariant() == name.ToLowerInvariant());
            bool isNew = false;
            if (entry == null)
            {
                entry = new PhoneBookEntry(name);
                this.entries.Add(entry);
                isNew = true;
            }

            AddPhoneNumberToEntry(phoneNumbers, entry);

            return isNew;
        }

        public int ChangePhone(string oldNumber, string newNumber)
        {
            var entriesWithOldNumbers = this.entries.Where(m => m.PhoneNumbers.Contains(oldNumber));

            foreach (var entry in entriesWithOldNumbers)
            {
                entry.PhoneNumbers.Remove(oldNumber);
                entry.PhoneNumbers.Add(newNumber);
            }

            return entriesWithOldNumbers.Count();
        }

        public IEnumerable<PhoneBookEntry> ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex + count > this.entries.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            this.entries.OrderBy(m => m);

            var result = new List<PhoneBookEntry>(count);
            for (int i = startIndex; i <= startIndex + count - 1; i++)
            {
                result.Add(this.entries[i]);
            }

            return result;
        }

        private static void AddPhoneNumberToEntry(IEnumerable<string> numbers, PhoneBookEntry entry)
        {
            foreach (var number in numbers)
            {
                entry.PhoneNumbers.Add(number);
            }
        }
    }
}
