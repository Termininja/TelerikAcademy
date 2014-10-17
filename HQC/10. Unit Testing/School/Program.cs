/*
 * Task 01. Write three classes: Student, Course and School.
 * Students should have name and unique number (inside the entire School).
 * Name can not be empty and the unique number is between 10000 and 99999.
 * Each course contains a set of students. Students in a course should
 * be less than 30 and can join and leave courses.

 * Task 02. Write VSTT tests for these two classes. Use 2 class library
 * projects in Visual Studio: School.csproj and TestSchool.csproj.
   
 * Task 03. Execute the tests using Visual Studio and check the code
 * coverage. Ensure it is at least 90%.
 */

namespace School
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var student = new Student("Pesho", 77777);
            Console.WriteLine(student);
        }
    }
}
