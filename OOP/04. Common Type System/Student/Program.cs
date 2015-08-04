/* 
 * Problem 1. Student class:
 *      Define a class Student, which contains data about a student – first, middle and
 *      last name, SSN, permanent address, mobile phone e-mail, course, specialty, university,
 *      faculty. Use an enumeration for the specialties, universities and faculties.
 *      
 *      Override the standard methods, inherited by System.Object: Equals(),
 *      ToString(), GetHashCode() and operators == and !=.
 *      
 * Problem 2. IClonable:
 *      Add implementations of the ICloneable interface. The Clone() method should
 *      deeply copy all object's fields into a new object of type Student.

 * Problem 3. IComparable:
 *      Implement the IComparable<Student> interface to compare students by names (as first criteria,
 *      in lexicographic order) and by social security number (as second criteria, in increasing order).
 */

namespace Student
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main()
        {
            // Creates a list of students
            var students = new List<Student>(){
                new Student("Ivan", "Ivanov", "Ivanov",
                    12345, "address1", "0888 88 88 88", "ivan1@gmail.com", "course1",
                    University.SU, Faculty.IT, Specialty.Informatics),
                new Student("Ivan", "Ivanov", "Ivanov",
                    67890, "address2", "09999 99 99 99", "ivan2@gmail.com", "course2",
                    University.TU, Faculty.IT, Specialty.ComputerSystems)
            };

            // Makes a deep copy of the first student
            var firstCloned = (Student)students[0].Clone();

            // Print all students
            PrintStudent("Student 1", students[0]);
            PrintStudent("Student 2", students[1]);
            PrintStudent("Cloned student", firstCloned);

            // Tests the cloning by Equals method and == and != operators
            if (students[0].Equals(firstCloned) && students[0] == firstCloned)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Cloning is successful!\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cloning is not successful!\n");
            }

            // Tests the CompareTo method
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Comparing:");
            Console.ResetColor();
            Console.WriteLine("Student 1 and Cloned student: {0}", students[0].CompareTo(firstCloned));
            Console.WriteLine("Student 2 and Cloned student: {0}", students[1].CompareTo(firstCloned));
        }

        // Prints some student
        private static void PrintStudent(string text, Student student)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.WriteLine(student);
        }
    }
}