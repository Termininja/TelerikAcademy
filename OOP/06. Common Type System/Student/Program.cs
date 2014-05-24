/* Task 01. Define a class Student, which contains data about a student: first, middle and last name,
 *          SSN, permanent address, mobile phone, e-mail, course, specialty, university, faculty.
 *          
 *          Use an enumeration for the specialties, universities and faculties.
 *          
 *          Override the standard methods, inherited by System.Object:
 *          Equals(), ToString(), GetHashCode() and operators == and !=.
 *          
 * Task 02. Add implementations of the ICloneable interface. The Clone() method should deeply copy
 *          all object's fields into a new object of type Student.
 *          
 * Task 03. Implement the IComparable<Student> interface to compare students in lexicographic order
 *          by names and as second criteria by social security number in increasing order.
 */

using System;
using System.Collections.Generic;

namespace Student
{
    class Program
    {
        static void Main()
        {
            // Create a list of students
            List<Student> students = new List<Student>();

            // Add some students in the list
            students.Add(
                new Student("Ivan", "Petrov", "Ivanov",
                12345, "address1", "0888 88 88 88", "ivanpetrov1@gmail.com", "course1",
                University.SU, Faculty.IT, Specialty.Informatics));
            students.Add(
                new Student("Ivan", "Petrov", "Petrov",
                12345, "address2", "0888 88 88 88", "ivanpetrov2@gmail.com", "course2",
                University.TU, Faculty.IT, Specialty.ComputerSystems));

            // Make a copy of the first student
            Student cloned = (Student)students[1].Clone();

            // Print all students
            PrintStudent("Student 1", students[0]);
            PrintStudent("Student 2", students[1]);
            PrintStudent("Cloned student", cloned);

            // Test the cloning by Equals method and operators == and !=
            if (!students[0].Equals(cloned) && students[1] == cloned)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Cloning is successful!\n");
            }
            else if (students[1] != cloned)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cloning is not successful!\n");
            }
            Console.ResetColor();

            // Test the CompareTo method
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Comparing:");
            Console.ResetColor();
            Console.WriteLine("Student 1 and Cloned student: {0}", students[0].CompareTo(cloned));
            Console.WriteLine("Student 2 and Cloned student: {0}", students[1].CompareTo(cloned));
        }

        // Print some student
        private static void PrintStudent(string text, Student student)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.WriteLine(student);
        }
    }
}