using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Phonebook.Tests
{
    [TestClass]
    public class AddPhoneTests
    {
        private Repository repository;

        [TestInitialize]
        public void InitializeTests()
        {
            this.repository = new Repository();
        }

        [TestMethod]
        public void AddPhoneShouldReturnTrueWhenUnexistingEntryIsAdded()
        {
            var result = repository.AddPhone("Test", new[] { "123" });
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void AddPhoneShouldReturnFalseWhenExistingEntryIsAdded()
        {
            repository.AddPhone("Test", new[] { "123" });
            var result = repository.AddPhone("Test", new[] { "456" });
            Assert.AreEqual(false, result);
        }
    }
}
