namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Repository : IPhonebookRepository
    {
        private OrderedSet<PhoneBookEntry> sortedEntries;
        private IDictionary<string, PhoneBookEntry> entriesByName;
        private MultiDictionaryBase<string, PhoneBookEntry> entriesByPhone;

        public Repository()
            : this(
                new OrderedSet<PhoneBookEntry>(),
                new Dictionary<string, PhoneBookEntry>(),
                new MultiDictionary<string, PhoneBookEntry>(false))
        {
        }

        public Repository(
            OrderedSet<PhoneBookEntry> sortedEntries,
            IDictionary<string, PhoneBookEntry> entriesByName,
            MultiDictionaryBase<string, PhoneBookEntry> entriesByPhone)
        {
            this.sortedEntries = sortedEntries;
            this.entriesByName = entriesByName;
            this.entriesByPhone = entriesByPhone;
        }

        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            string nameToLowerInvariant = name.ToLowerInvariant();
            PhoneBookEntry entry;
            bool entryDoesNotExist = !this.entriesByName.TryGetValue(nameToLowerInvariant, out entry);
            if (entryDoesNotExist)
            {
                entry = new PhoneBookEntry(name);
                this.entriesByName.Add(nameToLowerInvariant, entry);
                this.sortedEntries.Add(entry);
            }

            this.AddPhoneNumbersToEntriesByPhone(phoneNumbers, entry);
            entry.PhoneNumbers.UnionWith(phoneNumbers);

            return entryDoesNotExist;
        }

        public int ChangePhone(string oldEntry, string newEntry)
        {
            var foundEntries = this.entriesByPhone[oldEntry].ToList();
            foreach (var entry in foundEntries)
            {
                entry.PhoneNumbers.Remove(oldEntry);
                this.entriesByPhone.Remove(oldEntry, entry);
                entry.PhoneNumbers.Add(newEntry);
                this.entriesByPhone.Add(newEntry, entry);
            }

            return foundEntries.Count;
        }

        public IEnumerable<PhoneBookEntry> ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex + count > this.entriesByName.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            var result = new List<PhoneBookEntry>(count);
            for (int i = startIndex; i <= startIndex + count - 1; i++)
            {
                result.Add(this.sortedEntries[i]);
            }

            return result;
        }

        private void AddPhoneNumbersToEntriesByPhone(IEnumerable<string> phoneNumbers, PhoneBookEntry entry)
        {
            foreach (var number in phoneNumbers)
            {
                this.entriesByPhone.Add(number, entry);
            }
        }
    }
}
