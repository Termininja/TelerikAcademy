// Task 04. Create a class Person with two fields – name and age. Age can be left unspecified
//          (may contain null value. Override ToString() to display the information of a person
//          and if age is not specified – to say so. Write a program to test this functionality.

using System;
using System.Collections.Generic;

namespace Person
{
    class Program
    {
        static void Main()
        {
            // Create a list of people
            List<Person> people = new List<Person>();

            // Add some people in the list
            people.Add(new Person("Ivan Petrov", null));
            people.Add(new Person("Maria Ilieva", 32));
            people.Add(new Person("Stefan Kirov", 27));
            people.Add(new Person("Nadia Ivanova", null));

            // Print the result
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0,-20} Age", "Name");
            Console.ResetColor();
            Console.WriteLine(new string('-', 35));
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}