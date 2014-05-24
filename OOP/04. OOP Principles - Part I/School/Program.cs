/* Task 01.
 * We are given a school. In the school there are classes of students. Each class has a set of teachers.
 * Each teacher teaches a set of disciplines. Students have name and unique class number.
 * Classes have unique text identifier. Teachers have name. Disciplines have name, number of lectures
 * and number of exercises. Both teachers and students are people. Students, classes, teachers
 * and disciplines could have optional comments (free text block).
 * 
 * Your task is to identify the classes (in terms of OOP) and their attributes and operations,
 * encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio. 
 */

using System;
using System.Collections.Generic;

namespace School
{
    public class Program
    {
        public static void Main()
        {
            // Creates some school
            string schoolName = Read("Please, enter the name of your school: ");
            School school = new School(schoolName, new List<SchoolClass>());

            // Creates some disciplines
            List<Discipline> disciplines = new List<Discipline>();

            // Creates some list of teachers
            List<Teacher> teachers = new List<Teacher>();

            // Creates some list of students
            List<Student> students = new List<Student>();
            List<uint> studentNs = new List<uint>();

            bool exit = false;
            while (!exit)
            {
                Console.CursorVisible = false;
                Console.Clear();
                try
                {
                    // The menu
                    Menu('C', "Create some Class");
                    Menu('D', "Create some Discipline");
                    Menu('T', "Enter some Teacher");
                    Menu('S', "Enter some Student\n");

                    Menu('I', "Remove some Discipline");
                    Menu('H', "Remove some Teacher");
                    Menu('L', "Remove some Class");
                    Menu('Z', "Remove some Student\n");

                    Menu('N', "Add comment to some Discipline");
                    Menu('R', "Add comment to some Teacher");
                    Menu('A', "Add comment to some Class");
                    Menu('E', "Add comment to some Student\n");

                    Menu('P', "Print all information");
                    Menu('Q', "Quit\n");

                    // Our choice
                    ConsoleKeyInfo key = Console.ReadKey();
                    Console.Write("\b \b");
                    Console.CursorVisible = true;
                    switch (key.Key)
                    {
                        // Create some new discipline in the school
                        case ConsoleKey.D:
                            string disciplineName = Read("Please, enter the name of discipline: ");
                            uint lectures = uint.Parse(Read("The number of lectures for this discipline: "));
                            uint exercises = uint.Parse(Read("The number of exercises for this discipline: "));
                            disciplines.Add(new Discipline(disciplineName, lectures, exercises));
                            break;

                        // Create some new teacher in some class from the school
                        case ConsoleKey.T:
                            if (school.Classes.Count > 0 && disciplines.Count > 0)
                            {
                                string teacherName = Read("Please, enter the name of the teacher: ");
                                teachers.Add(new Teacher(teacherName, new List<Discipline>()));
                                uint numDisciplines = uint.Parse(Read("The number of disciplines for this teacher (max " + disciplines.Count + "): "));
                                if (numDisciplines > disciplines.Count)
                                {
                                    throw new ArgumentOutOfRangeException("The number has to be maximum " + disciplines.Count + "!");
                                }

                                PrintForeach(disciplines);
                                for (int i = 0; i < numDisciplines; i++)
                                {
                                    string discName = Read("The name of discipline " + (i + 1) + ": ");
                                    for (int j = 0; j < disciplines.Count; j++)
                                    {
                                        if (discName == disciplines[j].Name)
                                        {
                                            teachers[teachers.Count - 1].AddDiscipline(disciplines[j]);
                                            break;
                                        }
                                    }
                                }

                                PrintForeach(school.Classes);
                                string clNameT = Read("Enter the name of the class for this teacher: ");

                                for (int j = 0; j < school.Classes.Count; j++)
                                {
                                    if (clNameT == school.Classes[j].TextID)
                                    {
                                        school.Classes[j].AddTeacher(teachers[teachers.Count - 1]);
                                        break;
                                    }
                                }
                            }
                            else throw new MissingMemberException("First you have to create some class and some discipline!");
                            break;

                        // Create some new class in the school
                        case ConsoleKey.C:
                            string className = Read("Please, enter the name of the class: ");
                            school.AddClass(new SchoolClass(className, new List<Student>(), new List<Teacher>()));
                            break;

                        // Create some new student in some class from the school
                        case ConsoleKey.S:
                            if (school.Classes.Count > 0)
                            {
                                string studentName = Read("Please, enter the name of the student: ");
                                uint studentNumber = uint.Parse(Read("The class number for this student (max 5 digits): "));
                                foreach (uint n in studentNs)
                                    if (studentNumber == n) throw new ArgumentException("The number already exist!");
                                studentNs.Add(studentNumber);
                                students.Add(new Student(studentName, studentNumber));

                                PrintForeach(school.Classes);
                                string clNameS = Read("Enter the name of the class for this student: ");
                                for (int j = 0; j < school.Classes.Count; j++)
                                {
                                    if (clNameS == school.Classes[j].TextID)
                                    {
                                        school.Classes[j].AddStudent(students[students.Count - 1]);
                                        break;
                                    }
                                }
                            }
                            else throw new MissingMemberException("First you have to create some class!");
                            break;

                        // Remove some discipline for some teacher
                        case ConsoleKey.I:
                            if (teachers.Count > 0 && disciplines.Count > 0)
                            {
                                PrintForeach(teachers);
                                string delT = Read("Choose some teacher: ");
                                PrintForeach(teachers[teachers.FindIndex(m => m.Name == delT)].Disciplines);
                                string delD = Read("The name of discipline you want to be deleted: ");

                                for (int t = 0; t < teachers.Count; t++)
                                {
                                    if (delT == teachers[t].Name)
                                    {
                                        for (int d = 0; d < disciplines.Count; d++)
                                        {
                                            if (delD == disciplines[d].Name)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Magenta;
                                                Console.Write("Are you sure? The information will be lost! (y/n): ");
                                                Console.ResetColor();
                                                if (Console.ReadKey().Key == ConsoleKey.Y)
                                                {
                                                    Console.Write("\b \b\n");
                                                    teachers[t].RemoveDiscipline(disciplines[d]);
                                                }
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            else throw new MissingMemberException("First you have to create some discipline and some teacher!");
                            break;

                        // Remove some teacher from some class
                        case ConsoleKey.H:
                            if (school.Classes.Count > 0 && teachers.Count > 0)
                            {
                                PrintForeach(school.Classes);
                                string delC = Read("Choose some class: ");
                                PrintForeach(school.Classes[school.Classes.FindIndex(m => m.TextID == delC)].Teachers);
                                string delCT = Read("The name of teacher you want to be deleted: ");

                                for (int c = 0; c < school.Classes.Count; c++)
                                {
                                    if (delC == school.Classes[c].TextID)
                                    {
                                        for (int t = 0; t < teachers.Count; t++)
                                        {
                                            if (delCT == teachers[t].Name)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Magenta;
                                                Console.Write("Are you sure? The information will be lost! (y/n): ");
                                                Console.ResetColor();
                                                if (Console.ReadKey().Key == ConsoleKey.Y)
                                                {
                                                    Console.Write("\b \b\n");
                                                    school.Classes[c].Teachers[t].Disciplines.Clear();
                                                    school.Classes[c].RemoveTeacher(teachers[t]);
                                                }
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            else throw new MissingMemberException("First you have to create some class and some teacher!");
                            break;

                        // Remove some class from the school
                        case ConsoleKey.L:
                            if (school.Classes.Count > 0)
                            {
                                PrintForeach(school.Classes);
                                string delClass = Read("Choose some class: ");

                                for (int c = 0; c < school.Classes.Count; c++)
                                {
                                    if (delClass == school.Classes[c].TextID)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.Write("Are you sure? The information will be lost! (y/n): ");
                                        Console.ResetColor();
                                        if (Console.ReadKey().Key == ConsoleKey.Y)
                                        {
                                            Console.Write("\b \b\n");
                                            school.Classes[c].Teachers.Clear();
                                            school.Classes[c].Students.Clear();
                                            school.RemoveClass(school.Classes[c]);
                                        }
                                        break;
                                    }
                                }
                            }
                            else throw new MissingMemberException("First you have to create some class!");
                            break;

                        // Remove some student from some class
                        case ConsoleKey.Z:
                            if (school.Classes.Count > 0 && students.Count > 0)
                            {
                                PrintForeach(school.Classes);
                                string delC2 = Read("Choose some class: ");
                                PrintForeach(school.Classes[school.Classes.FindIndex(m => m.TextID == delC2)].Students);
                                string delCS = Read("The name of student you want to be deleted: ");

                                for (int c = 0; c < school.Classes.Count; c++)
                                {
                                    if (delC2 == school.Classes[c].TextID)
                                    {
                                        for (int s = 0; s < students.Count; s++)
                                        {
                                            if (delCS == students[s].Name)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Magenta;
                                                Console.Write("Are you sure? The information will be lost! (y/n): ");
                                                Console.ResetColor();
                                                if (Console.ReadKey().Key == ConsoleKey.Y)
                                                {
                                                    Console.Write("\b \b\n");
                                                    school.Classes[c].RemoveStudent(students[s]);
                                                }
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            else throw new MissingMemberException("First you have to create some class and some teacher!");
                            break;

                        // Adds comment for some discipline
                        case ConsoleKey.N:
                            if (disciplines.Count > 0)
                            {
                                PrintForeach(disciplines);
                                string discCom = Read("Choose some discipline: ");
                                for (int d = 0; d < disciplines.Count; d++)
                                {
                                    if (discCom == disciplines[d].Name)
                                    {
                                        string dComment = Read("Please, enter the comment for this discipline: ");
                                        disciplines[d].AddComment(dComment);
                                        break;
                                    }
                                }
                            }
                            else throw new MissingMemberException("First you have to create some discipline!");
                            break;

                        // Adds comment for some teacher
                        case ConsoleKey.R:
                            if (teachers.Count > 0)
                            {
                                PrintForeach(teachers);
                                string teachCom = Read("Choose some teacher: ");
                                for (int t = 0; t < teachers.Count; t++)
                                {
                                    if (teachCom == teachers[t].Name)
                                    {
                                        string tComment = Read("Please, enter the comment for this teacher: ");
                                        teachers[t].AddComment(tComment);
                                        break;
                                    }
                                }
                            }
                            else throw new MissingMemberException("First you have to create some teacher!");
                            break;

                        // Adds comment for some school class
                        case ConsoleKey.A:
                            if (school.Classes.Count > 0)
                            {
                                PrintForeach(school.Classes);
                                string classCom = Read("Choose some class: ");
                                for (int c = 0; c < school.Classes.Count; c++)
                                {
                                    if (classCom == school.Classes[c].TextID)
                                    {
                                        string cComment = Read("Please, enter the comment for this class: ");
                                        school.Classes[c].AddComment(cComment);
                                        break;
                                    }
                                }
                            }
                            else throw new MissingMemberException("First you have to create some class!");
                            break;

                        // Adds comment for some student
                        case ConsoleKey.E:
                            if (students.Count > 0)
                            {
                                PrintForeach(students);
                                string studCom = Read("Choose some student: ");
                                for (int s = 0; s < students.Count; s++)
                                {
                                    if (studCom == students[s].Name)
                                    {
                                        string sComment = Read("Please, enter the comment for this student: ");
                                        students[s].AddComment(sComment);
                                        break;
                                    }
                                }
                            }
                            else throw new MissingMemberException("First you have to create some student!");
                            break;

                        // Print the whole information about the school
                        case ConsoleKey.P:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(school);
                            Console.ResetColor();
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            break;

                        // Exit from the program
                        case ConsoleKey.Q:
                            exit = true;
                            break;
                        default: break;
                    }
                }
                catch (Exception e)
                {
                    Error(e);
                    Console.Write("\nPress any key to continue...");
                    Console.ReadKey();
                    continue;
                }
            }
        }

        // Print some class of objects
        private static void PrintForeach<T>(List<T> list)
        {
            if (list is List<Teacher>) Console.Write("\nTeachers:\n");
            if (list is List<Discipline>) Console.Write("\nDisciplines: ");
            for (int i = 0; i < list.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                if (list is List<Discipline>)
                {
                    Console.Write(list[i]);
                    if (i != list.Count - 1) Console.Write(", ");
                    else Console.WriteLine();
                }
                else Console.Write(list[i] + "\n");
                Console.ResetColor();
            }
        }

        // Print some line from the menu
        private static void Menu(char key, string text)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(key);
            Console.ResetColor();
            Console.WriteLine("]: {0}", text);
        }

        // Read some information about the 'text'
        private static string Read(string text)
        {
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Yellow;
            string input = Console.ReadLine();
            Console.ResetColor();
            return input;
        }

        // Print some error message
        private static void Error(Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
        }
    }
}