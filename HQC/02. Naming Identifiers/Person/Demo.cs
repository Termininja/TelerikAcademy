namespace Person
{
    using System;

    /// <summary>
    /// Demonstration of class Person
    /// </summary>
    class Demo
    {
        static void Main()
        {
            Person firstPerson = Person.CreatePerson(22);
            Console.WriteLine(firstPerson);

            Person secondPerson = Person.CreatePerson(25);
            Console.WriteLine(secondPerson);
        }
    }
}
