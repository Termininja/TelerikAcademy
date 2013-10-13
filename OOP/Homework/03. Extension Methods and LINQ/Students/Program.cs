/* 
 * Task 03. Write a method that from a given array of students finds all students whose first name
 *          is before its last name alphabetically. Use LINQ query operators.
 *          
 * Task 04. Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
 * 
 * Task 05. Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students
 *          by first name and last name in descending order. Rewrite the same with LINQ.
 */

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Students
{
    public class Program
    {
        public static void Main()
        {
            // Given array of students
            Students[] students = { 
                                      new Students("Hristo", "Stoichkov", 47), 
                                      new Students("Desi", "Slava", 34),
                                      new Students("Kubrat", "Pulev", 32), 
                                      new Students("Ejko", "Bejko", 23), 
                                      new Students("Ivet", "Lalova", 29), 
                                      new Students("Boyko", "Borisov", 54), 
                                      new Students("Ejko", "Taralejko", 78), 
                                      new Students("Lubo", "Ganev", 48),
                                      new Students("Radka", "Piratka", 19)
                                  };

            // Prints all students
            Print(Students.AllStudents(students), "All students:");

            // Extract and print only the students whose first name is before its last name alphabetically
            Print(Students.FilterByName(students), "\nStudents with first name before its last name: ");

            // Extract and print only the students with age between 18 and 24
            Print(Students.FilterByAge(students), "\nStudents with age between 18 and 24: ");

            // Sorting the students by first name and last name
            LambdaAndLINQ(students, "Lambda");                                  // by Lambda
            LambdaAndLINQ(students, "LINQ");                                    // by LINQ
        }

        private static void LambdaAndLINQ(Students[] students, string method)
        {
            string order = (method == "lambda") ? "descending" : "ascending";
            Console.Write("\nPress any key to sort all lists in {0} order by {1}...", order, method);
            Console.ReadKey();
            Console.Clear();
            PrintSorted(method, Students.AllStudents(students), "All students:");
            PrintSorted(method, Students.FilterByName(students), "\nStudents with first name before its last name: ");
            PrintSorted(method, Students.FilterByAge(students), "\nStudents with age between 18 and 24: ");
        }

        // Print without sorting
        private static void Print(List<Students> list, string str)
        {
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in list) Console.WriteLine(item);
            Console.ResetColor();
        }

        // Print with sorting by first and last name
        private static void PrintSorted(string method, List<Students> list, string str)
        {
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
            IEnumerable result = list;
            switch (method)
            {
                // Sorting by using lambda expressions and extension methods OrderBy() and ThenBy()
                case "Lambda": result = list.OrderByDescending(m => m.First).ThenByDescending(m => m.Last); break;

                // Sorting by using LINQ
                case "LINQ": result = from m in list orderby m.First ascending, m.Last ascending select m; break;
                default: break;
            }
            foreach (var item in result) Console.WriteLine(item);
            Console.ResetColor();
        }
    }
}
