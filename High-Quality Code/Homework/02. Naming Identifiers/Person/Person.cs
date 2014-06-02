//Task 2. Refactor the following examples to produce code with well-named identifiers in C#:

namespace Person
{
    using System;

    public enum Sex { Male, Female };

    /// <summary>
    /// Class for person.
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }

        /// <summary>
        /// Creates some person.
        /// </summary>
        /// <param name="age">The age of the person.</param>
        /// <returns>Returns an new person.</returns>
        public static Person CreatePerson(int age)
        {
            Person person = new Person();
            person.Age = age;
            if (age % 2 == 0)
            {
                person.Name = "Батката";
                person.Sex = Sex.Male;
            }
            else
            {
                person.Name = "Мацето";
                person.Sex = Sex.Female;
            }

            return person;
        }

        /// <summary>
        /// Returns all informationa about the person like string.
        /// </summary>
        /// <returns>Returns the name, the age and the sex of the person like string.</returns>
        public override string ToString()
        {
            string result = String.Format("Name:{0}; Age: {1}; Sex: {2}",
                this.Name, this.Age, this.Sex);

            return result;
        }
    }
}