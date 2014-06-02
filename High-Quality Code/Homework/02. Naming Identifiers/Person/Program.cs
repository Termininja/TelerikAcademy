namespace Person
{
    using System;

    /// <summary>
    /// Demonstration of class Person
    /// </summary>
    class Program
    {
        static void Main()
        {
            Person person1 = Person.CreatePerson(22);
            Console.WriteLine(person1);

            Person person2 = Person.CreatePerson(25);
            Console.WriteLine(person2);
        }
    }
}
