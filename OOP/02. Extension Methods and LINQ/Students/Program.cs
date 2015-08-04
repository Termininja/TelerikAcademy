/* 
 * Problem 3. First before last:
 *      Write a method that from a given array of students finds all students whose
 *      first name is before its last name alphabetically. Use LINQ query operators.
 * 
 * Problem 4. Age range:
 *      Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
 * 
 * Problem 5. Order students:
 *      Using the extension methods OrderBy() and ThenBy() with lambda expressions sort
 *      the students by first name and last name in descending order. Rewrite the same with LINQ.
 */

namespace Students
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;

    public class Program
    {
        public static void Main()
        {
            // Given array of students
            var students = new List<Student>() { 
                new Student("Hristo", "Stoichkov", 47), 
                new Student("Desi", "Slava", 34),
                new Student("Kubrat", "Pulev", 32), 
                new Student("Ejko", "Bejko", 23), 
                new Student("Ivet", "Lalova", 29), 
                new Student("Boyko", "Borisov", 54), 
                new Student("Ejko", "Taralejko", 78), 
                new Student("Lubo", "Ganev", 48),
                new Student("Radka", "Piratka", 19)
            };

            // Prints all students
            Print(students, "All students:");

            // Extracts and prints only the students whose first name is before its last name alphabetically
            Print(FilterByName(students), "\nStudents with first name before its last name: ");

            // Extracts and prints only the students with age between 18 and 24
            Print(FilterByAge(students), "\nStudents with age between 18 and 24: ");

            // Sorting the students by first name and last name by using Lambda and LINQ
            LambdaAndLINQ(students, "Lambda");
            LambdaAndLINQ(students, "LINQ");
        }

        /// <summary>
        /// Finds all students whose first name is before its last name alphabetically.
        /// </summary>
        /// <param name="list">The list of students.</param>
        /// <returns>Returns all students whose first name is before its last name alphabetically.</returns>
        public static List<Student> FilterByName(List<Student> list)
        {
            var result = new List<Student>();
            var filtered = from n in list where n.FirstName[0] < n.LastName[0] select n;
            filtered.ToList().ForEach(m => result.Add(m));

            return result;
        }

        /// <summary>
        /// Finds the names of all students with age between 18 and 24.
        /// </summary>
        /// <param name="list">The list of students.</param>
        /// <returns>Returns the names of all students with age between 18 and 24.</returns>
        public static List<Student> FilterByAge(List<Student> list)
        {
            var result = new List<Student>();
            var filtered = from n in list where n.Age >= 18 && n.Age <= 24 select n;
            filtered.ToList().ForEach(m => result.Add(m));

            return result;
        }

        private static void LambdaAndLINQ(List<Student> students, string method)
        {
            var order = (method == "Lambda") ? "descending" : "ascending";
            Console.Write("\nPress any key to sort all lists in {0} order by {1}...", order, method);
            Console.ReadKey();
            Console.Clear();
            PrintSorted(method, students, "All students:");
            PrintSorted(method, FilterByName(students), "\nStudents with first name before its last name: ");
            PrintSorted(method, FilterByAge(students), "\nStudents with age between 18 and 24: ");
        }

        // Print without sorting
        private static void Print(List<Student> students, string str)
        {
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
            students.ForEach(student => Console.WriteLine(student));
            Console.ResetColor();
        }

        // Print with sorting by first and last name
        private static void PrintSorted(string method, List<Student> list, string str)
        {
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
            var students = new List<Student>();
            switch (method)
            {
                // Sorting by using lambda expressions and extension methods OrderBy() and ThenBy()
                case "Lambda":
                    students = list.OrderByDescending(m => m.FirstName).ThenByDescending(m => m.LastName).ToList();
                    break;
                // Sorting by using LINQ
                case "LINQ":
                    students = (from m in list orderby m.FirstName ascending, m.LastName ascending select m).ToList();
                    break;
                default:
                    break;
            }

            students.ForEach(student => Console.WriteLine(student));
            Console.ResetColor();
        }
    }
}
