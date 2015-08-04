/* 
 * Problem 2. Students and workers:
 *      Define abstract class Human with a first name and a last name.
 *      Define a new class Student which is derived from Human and has a new field – grade.
 *      Define class Worker derived from Human with a new property WeekSalary and WorkHoursPerDay
 *      and a method MoneyPerHour() that returns money earned per hour by the worker.
 *      Define the proper constructors and properties for this hierarchy.
 *      
 *      Initialize a list of 10 students and sort them by grade in ascending order
 *      (use LINQ or OrderBy() extension method).
 * 
 *      Initialize a list of 10 workers and sort them by money per hour in descending order.
 * 
 *      Merge the lists and sort them by first name and last name.
 */

namespace People
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static Random random = new Random();

        private static readonly List<string[]> Titles = new List<string[]> {
            new []{ "Students", "Grade", null, null},
            new []{ "Workers", "Week Salary", "Work Hours Per Day", "Money Per Hour"},
            new []{ "First Name", "Last Name", null, null}
        };

        public static void Main()
        {
            // Creates a list of 10 students
            Continue("Press any key to create a list of 10 students...");
            var students = new List<Student>();
            Enumerable.Range(0, 10).ToList().ForEach(m => students.Add(new Student(
                RandomNameGenerator(), RandomNameGenerator(), random.Next(1, 10))));
            Print<Student>(students, Titles[0]);

            // Sorts the list by grade in ascending order
            Continue("\nPress any key to sort them by grade in ascending order...");
            students = students.OrderBy(m => m.Grade).ToList();
            Print<Student>(students, Titles[0]);

            // Creates a list of 10 workers
            Continue("\nPress any key to create a list of 10 workers...");
            var workers = new List<Worker>();
            Enumerable.Range(0, 10).ToList().ForEach(m => workers.Add(new Worker(
                RandomNameGenerator(), RandomNameGenerator(), random.Next(10, 150) * 10, Convert.ToByte(random.Next(1, 10)))));
            Print<Worker>(workers, Titles[1]);

            // Sorts the list by money per hour in descending order
            Continue("\nPress any key to sort them by money per hour in descending order...");
            workers = workers.OrderBy(m => -m.MoneyPerHour()).ToList();
            Print<Worker>(workers, Titles[1]);

            // Merge the both lists
            Continue("\nPress any key to merge the both lists...");
            List<Human> merged = students.Concat<Human>(workers).ToList();
            Print<Human>(merged, Titles[2]);

            // Sorts the merged list by first and last name
            Continue("\nPress any key to sort the merged list by first and last name...");
            merged = merged.OrderBy(m => m.FirstName).ThenBy(m => m.LastName).ToList();
            Print<Human>(merged, Titles[2]);
        }

        private static void Continue(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(text);
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        private static dynamic RandomNameGenerator()
        {
            var result = String.Empty;
            for (int i = 0; i < random.Next(3, 11); i++)
            {
                result += (i != 0) ?
                    ((char)random.Next(65, 91)).ToString().ToLower() :
                    ((char)random.Next(65, 91)).ToString();
            }

            return result;
        }

        private static void Print<T>(List<T> list, string[] names)
        {
            var format = "┌{0}┬{1}" +
                (names[2] != null ? "┬{0}┬{0}" : null) + "┐\n│ {2,-18} │ {3,11} " +
                (names[2] != null ? "│ {4,18} │ {5,18} " : null) + "│\n├{0}┼{1}" +
                (names[2] != null ? "┼{0}┼{0}" : null) + "┤";

            Console.WriteLine(format, new string('─', 20), new string('─', 13), names[0], names[1], names[2], names[3]);

            foreach (var element in list)
            {
                if (list is List<Human>)
                {
                    TableColumn("{0,-18} ", (element as Human).FirstName, ConsoleColor.White);
                    TableColumn("{0,11} ", (element as Human).LastName, ConsoleColor.White);
                }
                else if (list is List<Student>)
                {
                    TableColumn("{0,-18} ", (element as Student), ConsoleColor.White);
                    TableColumn("{0,11} ", (element as Student).Grade, ConsoleColor.Green);
                }
                else if (list is List<Worker>)
                {
                    TableColumn("{0,-18} ", (element as Worker), ConsoleColor.White);
                    TableColumn("{0,11} ", "$" + (element as Worker).WeekSalary, ConsoleColor.White);
                    TableColumn("{0,18} ", (element as Worker).WorkHoursPerDay, ConsoleColor.White);
                    TableColumn("{0,18} ", "$" + (element as Worker).MoneyPerHour().ToString("F2"), ConsoleColor.Green);
                }

                Console.WriteLine("│");
            }

            Console.WriteLine("└{0}┴{1}" + (names[2] != null ? "┴{0}┴{0}" : null) + "┘", new string('─', 20), new string('─', 13));
        }

        private static void TableColumn(string format, dynamic student, ConsoleColor color)
        {
            Console.Write("│ ");
            Console.ForegroundColor = color;
            Console.Write(format, student);
            Console.ResetColor();
        }
    }
}