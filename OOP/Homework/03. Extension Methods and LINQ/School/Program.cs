/* Task 09:  Create a class student with properties FirstName, LastName, FN, Tel, Email,
 *           Marks (a List<int>), GroupNumber. Create a List<Student> with sample students.
 *           Select only the students that are from group number 2. Use LINQ query.
 *           Order the students by FirstName.
 *           
 * Task 10:  Implement the previous using the same query expressed with extension methods.
 * 
 * Task 11:  Extract all students that have email in abv.bg. Use string methods and LINQ.
 * 
 * Task 12:  Extract all students with phones in Sofia. Use LINQ.
 * 
 * Task 13:  Select all students that have at least one mark Excellent (6) into a new
 *           anonymous class that has properties – FullName and Marks. Use LINQ.
 * 
 * Task 14:  Write down a similar program that extracts the students
 *           with exactly two marks "2". Use extension methods.
 * 
 * Task 15:  Extract all Marks of the students that enrolled in 2006.
 *           (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
 * 
 * Task 16*: Create a class Group with properties GroupNumber and DepartmentName.
 *           Introduce a property Group in the Student class. Extract all students from
 *           "Mathematics" department. Use the Join operator.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace School
{
    class Program
    {
        static void Main()
        {
            //Create a list of students
            List<Student> students = new List<Student>
            {
                new Student("Ivan", "Ivanov", 23450432, "02888882", "ivancho@gmail.com", new List<int>{5, 4}, new Group(2, "Physics")),
                new Student("Maria", "Petrova", 23450612, "042888883", "mimi@abv.bg", new List<int>{6, 6, 6, 5}, new Group(1, "Mathematics")),
                new Student("Petar", "Stoyanov", 23450524, "02888884", "pesho@gmail.com", new List<int>{4, 4, 3, 4}, new Group(2, "Physics")),
                new Student("Ivan", "Petrov", 23450684, "074888881", "ivan@abv.bg", new List<int>{2, 2}, new Group(1, "Mathematics")),
                new Student("Elena", "Ivanova", 23450792, "034888885", "elena@gmail.com", new List<int>{4, 6, 3}, new Group(2, "Physics"))
            };

            // Print all students
            Console.WriteLine("All students:");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
            Console.ResetColor();

            #region Task 09: Select only the students that are from group 2 and order them by using Linq
            var group2Linq =
                from s in students
                where s.Group.GroupNumber == 2
                orderby s.FirstName
                select new { Name = s.FirstName + " " + s.LastName, GroupN = s.Group.GroupNumber };

            // Print the students from group 2
            Continue("from group 2 (by Linq)");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var student in group2Linq)
            {
                Console.WriteLine("Name: " + student.Name);
                Console.WriteLine("GroupNumber: " + student.GroupN + "\n");
            }
            Console.ResetColor();
            #endregion

            #region Task 10: Select only the students that are from group 2 and order them by using Lambda
            var group2Lambda = students.Where(m => m.Group.GroupNumber == 2).OrderBy(m => m.FirstName);

            // Print the students from group 2
            Continue("from group 2 (by Lambda)");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var student in group2Lambda)
            {
                Console.WriteLine("Name: " + student.FirstName + " " + student.LastName);
                Console.WriteLine("GroupNumber: " + student.Group.GroupNumber + "\n");
            }
            Console.ResetColor();
            #endregion

            #region Task 11: Extract all students that have email in abv.bg
            var abvStudents =
                from s in students
                where s.Email.Contains("@abv.bg")
                select new { Name = s.FirstName + " " + s.LastName, Email = s.Email };

            // Print the students with email in abv.bg
            Continue("with emails in abv.bg");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var student in abvStudents)
            {
                Console.WriteLine("Name: " + student.Name);
                Console.WriteLine("Email: " + student.Email + "\n");
            }
            Console.ResetColor();
            #endregion

            #region Task 12: Extract all students with phones in Sofia
            var sofiaStudents =
                from s in students
                where s.Tel.StartsWith("02")
                select new { Name = s.FirstName + " " + s.LastName, Tel = s.Tel };

            // Print the students with email in abv.bg
            Continue("with phones in Sofia");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var student in sofiaStudents)
            {
                Console.WriteLine("Name: " + student.Name);
                Console.WriteLine("Tel: " + student.Tel + "\n");
            }
            Console.ResetColor();
            #endregion

            #region Task 13: Select all students that have at least one excellent mark
            var excellentStudents =
                from s in students
                where s.Marks.Contains(6)
                select new { Name = s.FirstName + " " + s.LastName, Marks = s.Marks };

            // Print the students with excellent marks
            Continue("with excellent marks");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var student in excellentStudents)
            {
                Console.WriteLine("Name: " + student.Name);
                Console.Write("Marks: ");
                foreach (var mark in student.Marks)
                {
                    Console.Write(mark + " ");
                }
                Console.WriteLine("\n");
            }
            Console.ResetColor();
            #endregion

            #region Task 14: Extracts the students with exactly two marks
            var twoMarksStudents =
                from s in students
                where s.Marks.Count == 2
                select new { Name = s.FirstName + " " + s.LastName, Marks = s.Marks };

            // Print the students with two marks
            Continue("with exactly two marks");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var student in twoMarksStudents)
            {
                Console.WriteLine("Name: " + student.Name);
                Console.Write("Marks: ");
                foreach (var mark in student.Marks)
                {
                    Console.Write(mark + " ");
                }
                Console.WriteLine("\n");
            }
            Console.ResetColor();
            #endregion

            #region Task 15: Extract all Marks of the students that enrolled in 2006
            var studentsFrom2006 =
                from s in students
                where s.FN.ToString().Substring(4, 2) == "06"
                select new { Name = s.FirstName + " " + s.LastName, Department = s.FN };

            // Print the students that enrolled in 2006
            Continue("that enrolled in 2006");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var student in studentsFrom2006)
            {
                Console.WriteLine("Name: " + student.Name);
                Console.WriteLine("FN: " + student.Department + "\n");
            }
            Console.ResetColor();
            #endregion

            #region Task 16: Extract all students from "Mathematics" department
            // Extract all groups from the students
            List<Group> groups = new List<Group>();
            foreach (var student in students)
            {
                bool free = true;
                foreach (var group in groups)
                {
                    if (group.DepartmentName == student.Group.DepartmentName) free = false;
                }
                if (free)
                {
                    groups.Add(new Group(student.Group.GroupNumber, student.Group.DepartmentName));
                }
            }

            // Extract the students from "Mathematics" department
            var mathematicsStudents =
                from s in students
                join g in groups on s.Group.DepartmentName equals g.DepartmentName
                where g.DepartmentName == "Mathematics"
                select new { Name = s.FirstName + " " + s.LastName, Department = g.DepartmentName };

            // Print the students from "Mathematics" department
            Continue("from \"Mathematics\" department");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var student in mathematicsStudents)
            {
                Console.WriteLine("Name: " + student.Name);
                Console.WriteLine("Department: " + student.Department + "\n");
            }
            Console.ResetColor();
            #endregion
        }

        private static void Continue(string str)
        {
            Console.Write("Press any key to see the students {0}:", str);
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}