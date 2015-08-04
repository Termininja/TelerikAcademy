/*
 * Problem 9. Student groups:
 *      Create a class Student with properties FirstName, LastName, FN, Tel, Email, Marks (a List), GroupNumber.
 *      Create a List<Student> with sample students. Select only the students that are from group number 2.
 *      Use LINQ query. Order the students by FirstName.
 * 
 * Problem 10. Student groups extensions:
 *      Implement the previous using the same query expressed with extension methods.
 * 
 * Problem 11. Extract students by email:
 *      Extract all students that have email in abv.bg. Use string methods and LINQ.
 * 
 * Problem 12. Extract students by phone:
 *      Extract all students with phones in Sofia. Use LINQ.
 * 
 * Problem 13. Extract students by marks:
 *      Select all students that have at least one mark Excellent (6) into a new anonymous
 *      class that has properties – FullName and Marks. Use LINQ.
 * 
 * Problem 14. Extract students with two marks:
 *      Write down a similar program that extracts the students with exactly two marks "2".
 *      Use extension methods.
 * 
 * Problem 15. Extract marks:
 *      Extract all Marks of the students that enrolled in 2006.
 *      (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
 * 
 * Problem 16.* Groups:
 *      Create a class Group with properties GroupNumber and DepartmentName.
 *      Introduce a property GroupNumber in the Student class.
 *      Extract all students from "Mathematics" department. Use the Join operator.
 */

namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            //Creates a list of students
            var students = new List<Student>
            {
                new Student("Ivan", "Ivanov", 23450432, "02888882", "ivancho@gmail.com", new List<int>{5, 4}, new Group(2, "Physics")),
                new Student("Maria", "Petrova", 23450612, "042888883", "mimi@abv.bg", new List<int>{6, 6, 6, 5}, new Group(1, "Mathematics")),
                new Student("Petar", "Stoyanov", 23450524, "02888884", "pesho@gmail.com", new List<int>{4, 4, 3, 4}, new Group(2, "Physics")),
                new Student("Ivan", "Petrov", 23450684, "074888881", "ivan@abv.bg", new List<int>{2, 2}, new Group(1, "Mathematics")),
                new Student("Elena", "Ivanova", 23450792, "034888885", "elena@gmail.com", new List<int>{4, 6, 3}, new Group(2, "Physics"))
            };

            // Prints all students
            Console.WriteLine("All students:");
            Console.ForegroundColor = ConsoleColor.Gray;
            students.ForEach(m => Console.WriteLine(m));
            Console.ResetColor();

            #region Task 09: Select only the students that are from group 2 and order them by using Linq

            var group2Linq =
                from s in students
                where s.Group.GroupNumber == 2
                orderby s.FirstName
                select new { Name = s.FirstName + " " + s.LastName, GroupN = s.Group.GroupNumber };

            // Prints the students from group 2
            Continue("from group 2 (by Linq)");
            Console.ForegroundColor = ConsoleColor.Gray;
            group2Linq.ToList().ForEach(m => Console.WriteLine("Name: {0}\nGroupNumber: {1}\n", m.Name, m.GroupN));
            Console.ResetColor();

            #endregion

            #region Task 10: Select only the students that are from group 2 and order them by using Lambda

            var group2Lambda = students.Where(m => m.Group.GroupNumber == 2).OrderBy(m => m.FirstName);

            // Prints the students from group 2
            Continue("from group 2 (by Lambda)");
            Console.ForegroundColor = ConsoleColor.Gray;
            group2Lambda.ToList().ForEach(m => Console.WriteLine("Name: {0} {1}\nGroupNumber: {2}\n", m.FirstName, m.LastName, m.Group.GroupNumber));
            Console.ResetColor();

            #endregion

            #region Task 11: Extract all students that have email in abv.bg

            var abvStudents =
                from s in students
                where s.Email.Contains("@abv.bg")
                select new { Name = s.FirstName + " " + s.LastName, Email = s.Email };

            // Prints the students with email in abv.bg
            Continue("with emails in abv.bg");
            Console.ForegroundColor = ConsoleColor.Gray;
            abvStudents.ToList().ForEach(m => Console.WriteLine("Name: {0}\nEmail: {1}\n", m.Name, m.Email));
            Console.ResetColor();

            #endregion

            #region Task 12: Extract all students with phones in Sofia

            var sofiaStudents =
                from s in students
                where s.Tel.StartsWith("02")
                select new { Name = s.FirstName + " " + s.LastName, Tel = s.Tel };

            // Prints the students with email in abv.bg
            Continue("with phones in Sofia");
            Console.ForegroundColor = ConsoleColor.Gray;
            sofiaStudents.ToList().ForEach(m => Console.WriteLine("Name: {0}\nTel: {1}\n", m.Name, m.Tel));
            Console.ResetColor();

            #endregion

            #region Task 13: Select all students that have at least one excellent mark

            var excellentStudents =
                from s in students
                where s.Marks.Contains(6)
                select new { Name = s.FirstName + " " + s.LastName, Marks = s.Marks };

            // Prints the students with excellent marks
            Continue("with excellent marks");
            Console.ForegroundColor = ConsoleColor.Gray;
            excellentStudents.ToList().ForEach(m => Console.WriteLine("Name: {0}\nMarks: {1}\n", m.Name, string.Join(" ", m.Marks)));
            Console.ResetColor();

            #endregion

            #region Task 14: Extracts the students with exactly two marks

            var twoMarksStudents =
                from s in students
                where s.Marks.Count == 2
                select new { Name = s.FirstName + " " + s.LastName, Marks = s.Marks };

            // Prints the students with two marks
            Continue("with exactly two marks");
            Console.ForegroundColor = ConsoleColor.Gray;
            twoMarksStudents.ToList().ForEach(m => Console.WriteLine("Name: {0}\nMarks: {1}\n", m.Name, string.Join(" ", m.Marks)));
            Console.ResetColor();

            #endregion

            #region Task 15: Extract all Marks of the students that enrolled in 2006

            var studentsFrom2006 =
                from s in students
                where s.FN.ToString().Substring(4, 2) == "06"
                select new { Name = s.FirstName + " " + s.LastName, Department = s.FN };

            // Prints the students that enrolled in 2006
            Continue("that enrolled in 2006");
            Console.ForegroundColor = ConsoleColor.Gray;
            studentsFrom2006.ToList().ForEach(m => Console.WriteLine("Name: {0}\nFN: {1}\n", m.Name, m.Department));
            Console.ResetColor();

            #endregion

            #region Task 16: Extract all students from "Mathematics" department

            // Extracts all groups from the students
            var groups = new List<Group>();
            foreach (var student in students)
            {
                var free = true;
                foreach (var group in groups)
                {
                    if (group.DepartmentName == student.Group.DepartmentName) free = false;
                }
                if (free)
                {
                    groups.Add(new Group(student.Group.GroupNumber, student.Group.DepartmentName));
                }
            }

            // Extracts the students from "Mathematics" department
            var mathematicsStudents =
                from s in students
                join g in groups on s.Group.DepartmentName equals g.DepartmentName
                where g.DepartmentName == "Mathematics"
                select new { Name = s.FirstName + " " + s.LastName, Department = g.DepartmentName };

            // Prints the students from "Mathematics" department
            Continue("from \"Mathematics\" department");
            Console.ForegroundColor = ConsoleColor.Gray;
            mathematicsStudents.ToList().ForEach(m => Console.WriteLine("Name: {0}\nDepartment: {1}\n", m.Name, m.Department));
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