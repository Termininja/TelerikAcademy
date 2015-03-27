/* 
 * Problem 1. School classes:
 *      We are given a school. In the school there are classes of students. Each class has a set of teachers.
 *      Each teacher teaches, a set of disciplines. Students have a name and unique class number.
 *      Classes have unique text identifier. Teachers have a name. Disciplines have a name, number of lectures
 *      and number of exercises. Both teachers and students are people. Students, classes, teachers
 *      and disciplines could have optional comments (free text block).
 *      
 *      Your task is to identify the classes (in terms of OOP) and their attributes and operations, encapsulate
 *      their fields, define the class hierarchy and create a class diagram with Visual Studio.
 */

namespace School
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var school = new School(ReadText("Please, enter the name of your school: "), new List<SchoolClass>());
            var disciplines = new List<Discipline>();
            var teachers = new List<Teacher>();
            var students = new List<Student>();
            var exit = false;
            while (!exit)
            {
                Console.CursorVisible = false;
                Console.Clear();
                try
                {
                    PrintMenu('C', "Create Class");
                    PrintMenu('D', "Create Discipline");
                    PrintMenu('T', "Enter Teacher");
                    PrintMenu('S', "Enter Student\n");

                    PrintMenu('I', "Remove Discipline");
                    PrintMenu('H', "Remove Teacher");
                    PrintMenu('L', "Remove Class");
                    PrintMenu('Z', "Remove Student\n");

                    PrintMenu('N', "Add comment to some Discipline");
                    PrintMenu('R', "Add comment to some Teacher");
                    PrintMenu('A', "Add comment to some Class");
                    PrintMenu('E', "Add comment to some Student\n");

                    PrintMenu('P', "Print all information");
                    PrintMenu('Q', "Quit\n");

                    var key = Console.ReadKey();
                    Console.Write("\b \b");
                    Console.CursorVisible = true;
                    switch (key.Key)
                    {
                        // Creates some new discipline in the school
                        case ConsoleKey.D:
                            var disciplineName = ReadText("Please, enter the name of discipline: ");
                            var lectures = uint.Parse(ReadText("The number of lectures for this discipline: "));
                            var exercises = uint.Parse(ReadText("The number of exercises for this discipline: "));
                            disciplines.Add(new Discipline(disciplineName, lectures, exercises));
                            break;

                        // Creates some new teacher in some class from the school
                        case ConsoleKey.T:
                            if (school.Classes.Count > 0 && disciplines.Count > 0)
                            {
                                var teacherName = ReadText("Please, enter the name of the teacher: ");
                                teachers.Add(new Teacher(teacherName, new List<Discipline>()));
                                var numDisciplines = uint.Parse(ReadText("The number of disciplines for this teacher (max " + disciplines.Count + "): "));
                                if (numDisciplines > disciplines.Count)
                                {
                                    throw new ArgumentOutOfRangeException("The number has to be maximum " + disciplines.Count + "!");
                                }

                                PrintObject(disciplines);
                                for (int i = 0; i < numDisciplines; i++)
                                {
                                    var discName = ReadText("The name of discipline " + (i + 1) + ": ");
                                    for (int j = 0; j < disciplines.Count; j++)
                                    {
                                        if (discName == disciplines[j].Name)
                                        {
                                            teachers[teachers.Count - 1].AddDiscipline(disciplines[j]);
                                            break;
                                        }
                                    }
                                }

                                PrintObject(school.Classes);
                                var clNameT = ReadText("Enter the name of the class for this teacher: ");

                                for (int j = 0; j < school.Classes.Count; j++)
                                {
                                    if (clNameT == school.Classes[j].Name)
                                    {
                                        school.Classes[j].AddTeacher(teachers[teachers.Count - 1]);
                                        break;
                                    }
                                }
                            }
                            else throw new MissingMemberException("First you have to create some class and some discipline!");
                            break;

                        // Creates some new class in the school
                        case ConsoleKey.C:
                            var className = ReadText("Please, enter the name of the class: ");
                            school.AddClass(new SchoolClass(className, new List<Student>(), new List<Teacher>()));
                            break;

                        // Creates some new student in some class from the school
                        case ConsoleKey.S:
                            if (school.Classes.Count > 0)
                            {
                                var studentName = ReadText("Please, enter the name of the student: ");
                                var studentNumber = uint.Parse(ReadText("The class number for this student (max 5 digits): "));
                                students.Add(new Student(studentName, studentNumber));

                                PrintObject(school.Classes);
                                var clNameS = ReadText("Enter the name of the class for this student: ");
                                for (int j = 0; j < school.Classes.Count; j++)
                                {
                                    if (clNameS == school.Classes[j].Name)
                                    {
                                        school.Classes[j].AddStudent(students[students.Count - 1]);
                                        break;
                                    }
                                }
                            }
                            else throw new MissingMemberException("First you have to create some class!");
                            break;

                        // Removes some discipline for some teacher
                        case ConsoleKey.I:
                            if (teachers.Count > 0 && disciplines.Count > 0)
                            {
                                PrintObject(teachers);
                                var delT = ReadText("Choose some teacher: ");
                                PrintObject(teachers[teachers.FindIndex(m => m.Name == delT)].Disciplines);
                                var delD = ReadText("The name of discipline you want to be deleted: ");

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

                        // Removes some teacher from some class
                        case ConsoleKey.H:
                            if (school.Classes.Count > 0 && teachers.Count > 0)
                            {
                                PrintObject(school.Classes);
                                var delC = ReadText("Choose some class: ");
                                PrintObject(school.Classes[school.Classes.FindIndex(m => m.Name == delC)].Teachers);
                                var delCT = ReadText("The name of teacher you want to be deleted: ");

                                for (int c = 0; c < school.Classes.Count; c++)
                                {
                                    if (delC == school.Classes[c].Name)
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

                        // Removes some class from the school
                        case ConsoleKey.L:
                            if (school.Classes.Count > 0)
                            {
                                PrintObject(school.Classes);
                                var delClass = ReadText("Choose some class: ");

                                for (int c = 0; c < school.Classes.Count; c++)
                                {
                                    if (delClass == school.Classes[c].Name)
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

                        // Removes some student from some class
                        case ConsoleKey.Z:
                            if (school.Classes.Count > 0 && students.Count > 0)
                            {
                                PrintObject(school.Classes);
                                var delC2 = ReadText("Choose some class: ");
                                PrintObject(school.Classes[school.Classes.FindIndex(m => m.Name == delC2)].Students);
                                var delCS = ReadText("The name of student you want to be deleted: ");

                                for (int c = 0; c < school.Classes.Count; c++)
                                {
                                    if (delC2 == school.Classes[c].Name)
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
                            AddComment<Discipline>(disciplines);
                            break;

                        // Adds comment for some teacher
                        case ConsoleKey.R:
                            AddComment<Teacher>(teachers);
                            break;

                        // Adds comment for some school class
                        case ConsoleKey.A:
                            AddComment<SchoolClass>(school.Classes);
                            break;

                        // Adds comment for some student
                        case ConsoleKey.E:
                            AddComment<Student>(students);
                            break;

                        // Prints the whole information about the school
                        case ConsoleKey.P:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(school);
                            Console.ResetColor();
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            break;

                        // Exit
                        case ConsoleKey.Q:
                            exit = true;
                            break;
                        default: break;
                    }
                }
                catch (Exception e)
                {
                    PrintError(e);
                    Console.Write("\nPress any key to continue...");
                    Console.ReadKey();
                    continue;
                }
            }
        }

        private static void AddComment<T>(List<T> list)
        {
            if (list.Count <= 0)
            {
                throw new MissingMemberException("First you have to create some " + typeof(T).Name + "!");
            }

            PrintObject(list);
            var command = ReadText("Choose some " + typeof(T).Name + ": ");
            foreach (dynamic element in list)
            {
                if (command == element.Name)
                {
                    element.AddComment(ReadText("Please, enter the comment for this " + typeof(T).Name + ": "));
                    break;
                }
            }
        }

        private static void PrintObject<T>(List<T> list)
        {
            Console.Write(list is List<Teacher> ? "\nTeachers:\n" : (list is List<Discipline> ? "\nDisciplines: " : null));
            for (int i = 0; i < list.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(list is List<Discipline> ? string.Format("{0}{1}", list[i], i != list.Count - 1 ? ", " : "\n") : (list[i] + "\n"));
                Console.ResetColor();
            }
        }

        private static void PrintMenu(char key, string text)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(key);
            Console.ResetColor();
            Console.WriteLine("]: {0}", text);
        }

        private static string ReadText(string text)
        {
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Yellow;
            var input = Console.ReadLine();
            Console.ResetColor();

            return input;
        }

        private static void PrintError(Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
        }
    }
}