/* Task 02.
 * Define abstract class Human with first name and last name. Define new class Student which is
 * derived from Human and has new field – grade. Define class Worker derived from Human with new
 * property WeekSalary and WorkHoursPerDay and method MoneyPerHour() that returns money earned by
 * hour by the worker. Define the proper constructors and properties for this hierarchy.
 * Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy()
 * extension method). Initialize a list of 10 workers and sort them by money per hour in descending order.
 * Merge the lists and sort them by first name and last name.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace People
{
    public class Program
    {
        static Random random = new Random();

        public static void Main()
        {
            // Create a list of 10 students
            PressAnyKey("Press any key to create a list of 10 students...");
            List<Student> students = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                students.Add(new Student(NameGenerator(), NameGenerator(), random.Next(1, 10)));
            }
            Student.Print(students);

            // Sort the list by grade in ascending order
            PressAnyKey("\nPress any key to sort them by grade in ascending order...");
            students = students.OrderBy(m => m.Grade).ToList();
            Student.Print(students);

            // Create a list of 10 workers
            PressAnyKey("\nPress any key to create a list of 10 workers...");
            List<Worker> workers = new List<Worker>();
            for (int i = 0; i < 10; i++)
            {
                workers.Add(new Worker(NameGenerator(), NameGenerator(), random.Next(10, 150) * 10, Convert.ToByte(random.Next(1, 10))));
            }
            Worker.Print(workers);

            // Sort the list by money per hour in descending order
            PressAnyKey("\nPress any key to sort them by money per hour in descending order...");
            workers = workers.OrderBy(m => -m.MoneyPerHour()).ToList();
            Worker.Print(workers);

            // Merge the both lists
            PressAnyKey("\nPress any key to merge the both lists...");
            List<Human> merged = students.Concat<Human>(workers).ToList();
            Human.Print(merged);

            // Sort the merged list by first and last name
            PressAnyKey("\nPress any key to sort the merged list by first and last name...");
            merged = merged.OrderBy(m => m.FirstName).ThenBy(m => m.LastName).ToList();
            Human.Print(merged);
        }

        // Go to the next subtask
        private static void PressAnyKey(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(text);
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        // Generator of random names
        private static dynamic NameGenerator()
        {
            string result = String.Empty;
            for (int i = 0; i < random.Next(3, 11); i++)
            {
                result += (i != 0) ?
                    ((char)random.Next(65, 91)).ToString().ToLower() :
                    ((char)random.Next(65, 91)).ToString();
            }
            return result;
        }
    }
}