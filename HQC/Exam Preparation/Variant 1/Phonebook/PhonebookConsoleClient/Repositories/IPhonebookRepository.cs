// -----------------------------------------------------------------------------
// <copyright file="IPhonebookRepository.cs" company="Telerik">
// Telerik Academy 2014
// </copyright>
// <summary>
// Defines a phonebook repository interface
// </summary>
// -----------------------------------------------------------------------------

namespace Phonebook
{
    using System.Collections.Generic;

    /// <summary>
    /// This interface is used for listing, adding and changing phonebook entries.
    /// </summary>
    public interface IPhonebookRepository
    {
        /// <summary>
        /// This method adds a new phone to a contact.
        /// </summary>
        /// <param name="name">The name of the contact.</param>
        /// <param name="phoneNumbers">Collection of phone numbers to be added.</param>
        /// <returns>Returns whether or not the name already exists.</returns>
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        /// <summary>
        /// This method change some old phone number with a new one.
        /// </summary>
        /// <param name="oldPhoneNumber">The old phone number.</param>
        /// <param name="newPhoneNumber">The new phone number.</param>
        /// <returns>Returns the number of the phone numbers for this entry.</returns>
        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        /// <summary>
        /// This method lists some number of phones in all phonebook entries starting from some start index.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The number of the phones which has to be listed.</param>
        /// <returns>Returns the list of phones.</returns>
        IEnumerable<PhoneBookEntry> ListEntries(int startIndex, int count);
    }
}
