/*
 * Problem 4. Person class:
 *      Create a class Person with two fields – name and age. Age can be left
 *      unspecified (may contain null value. Override ToString() to display
 *      the information of a person and if age is not specified – to say so.
 *      
 *      Write a program to test this functionality. 
 */

namespace Person
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main()
        {
            var people = new List<Person>() { 
                new Person("Ivan Petrov", null),
                new Person("Maria Ilieva", 32),
                new Person("Stefan Kirov", 27),
                new Person("Nadia Ivanova", null)
            };

            Console.WriteLine("{0,-16} Age\n{1}\n{2}", "Name", new string('-', 20), string.Join("\n", people));
        }
    }
}