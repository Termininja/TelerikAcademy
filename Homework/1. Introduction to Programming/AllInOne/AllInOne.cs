//Program which show all 12 tasks from the homework 1

using System;

class AllInOne
{
    static void Main()
    {
        Console.SetWindowSize(130, 40); //change the window size of the console
        Console.ForegroundColor = ConsoleColor.Cyan; //change the font color
        Console.WriteLine("Hello! This is my 1st homework and my 1st steps in C#\n");
        Console.ResetColor(); //reset the font color
        Console.WriteLine("Press Enter to continue . . .");
        string enter = Console.ReadLine();
        for (int t = 0; ; t++)
        {
            Console.ResetColor();
            Console.Write("Please type a task number from 1 to 12, or \"end\" to exit: ");
            Console.ForegroundColor = ConsoleColor.White;
            string task = Console.ReadLine();

            if (task == "1")
            {
                Console.Write("\nTask 1: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Familiarize yourself with Microsoft Visual Studio and MSDN Library Documentation");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Decision: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Done!\n");
            }

            if (task == "2")
            {
                Console.Write("\nTask 2: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Create, compile and run a \"Hello C#\" console application");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nDecision: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("using System;\n\nclass HelloCS\n{\n    static void Main()\n    {\n        Console.WriteLine(\"Hello C#\");\n    }\n}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nTo run the program press Enter");
                string enter2 = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;

                //Program: Hello C#
                Console.WriteLine("Hello C#");

                Console.WriteLine();
            }

            if (task == "3")
            {
                Console.Write("\nTask 3: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Modify the application to print your name");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nDecision: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("using System;\n\nclass WriteMyName\n{\n    static void Main()\n    {\n        Console.WriteLine(\"Write your name and press Enter\");\n        string name = Console.ReadLine();\n        Console.Write(\"\\nYour name is: \" + name);\n    }\n}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nTo run the program press Enter");
                string enter3 = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;

                //Program: Write my name
                Console.WriteLine("Write your name and press Enter");
                string name = Console.ReadLine();
                Console.WriteLine("\nYour name is: " + name);

                Console.WriteLine();
            }

            if (task == "4")
            {
                Console.Write("\nTask 4: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Write a program to print the numbers 1, 101 and 1001");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nDecision: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("using System;\n\nclass PrintNumbers\n{\n    static void Main()\n    {\n        Console.WriteLine(1 + \"\\n\" + 101 + \"\\n\" + 1001);\n    }\n}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nTo run the program press Enter");
                string enter4 = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;

                //Program: Print numbers
                Console.WriteLine(1 + "\n" + 101 + "\n" + 1001);

                Console.WriteLine();
            }

            if (task == "5")
            {
                Console.Write("\nTask 5: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Install at home Microsoft Visual Studio");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nDecision: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Done!\n");
            }

            if (task == "6")
            {
                Console.Write("\nTask 6: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Create a console application that prints your first and last name");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nDecision: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("using System;\n\nclass PrintFirsLastName\n{\n    static void Main()\n    {\n        Console.WriteLine(\"What is your first name?\");\n        string first = Console.ReadLine();\n        Console.WriteLine(\"What is your last name?\");\n        string last = Console.ReadLine();\n        Console.WriteLine(\"Your full name is: \" + first + \" \" + last);\n    }\n}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nTo run the program press Enter");
                string enter6 = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;

                //Program: Print first and last name
                Console.WriteLine("What is your first name?");
                string first = Console.ReadLine();
                Console.WriteLine("What is your last name?");
                string last = Console.ReadLine();
                Console.WriteLine("Your full name is: " + first + " " + last);

                Console.WriteLine();
            }

            if (task == "7")
            {
                Console.Write("\nTask 7: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Create a console application that prints the current date and time");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nDecision: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("using System;\n\nclass CurrentDateTime\n{\n    static void Main()\n    {\n        Console.WriteLine(\"Today is \" + DateTime.Now.ToString(\"dd MMMM yyyy (dddd)\"));\n        Console.WriteLine(\"The time is \" + DateTime.Now.ToString(\"h:m:ss tt\"));\n   }\n}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nTo run the program press Enter");
                string enter7 = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;

                //Program: Current date time
                Console.WriteLine("Today is " + DateTime.Now.ToString("dd MMMM yyyy (dddd)"));
                Console.WriteLine("The time is " + DateTime.Now.ToString("h:m:ss tt"));

                Console.WriteLine();
            }

            if (task == "8")
            {
                Console.Write("\nTask 8: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Create a console application that calculates and prints the square of the numbers 12345");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nDecision: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("using System;\n\nclass CurrentDateTime\n{\n    static void Main()\n    {\n        Console.WriteLine(Math.Pow(12345, 2));\n   }\n}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nTo run the program press Enter");
                string enter8 = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;

                //Program: Square of 12345
                Console.WriteLine(Math.Pow(12345, 2));

                Console.WriteLine();
            }

            if (task == "9")
            {
                Console.Write("\nTask 9: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nDecision: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("using System;\n\nclass PrintFirst10\n{\n    static void Main()\n    {\n        for (int i = 2; i <= 11; i++)\n        {\n            if (i % 2 == 0)\n            {\n                Console.Write(i + \", \");\n            }\n            else\n            {\n                Console.Write(-i + \", \");\n            }\n        }\n        Console.WriteLine();\n    }\n}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nTo run the program press Enter");
                string enter9 = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;

                //Program: First 10 numbers of a sequence
                for (int i = 2; i <= 11; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write(i + ", ");
                    }
                    else
                    {
                        Console.Write(-i + ", ");
                    }
                }
                Console.WriteLine();

                Console.WriteLine();
            }

            if (task == "10")
            {
                Console.Write("\nTask 10: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Provide a short list with information about the most popular programming languages. How do they differ from C#?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Decision: ");
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("Python\n    Paradigms: multi-paradigm: object-oriented, imperative, functional, procedural, reflective\n    Appeared in: 1991\n    Influenced by: ABC, ALGOL 68, C, C++, Dylan, Haskell, Icon, Java, Lisp, Modula-3, Perl\n    Influenced: Boo, Cobra, D, Falcon, Groovy, JavaScript, F#, Nimrod, Ruby\n    Usual filename extensions: .py, .pyw, .pyc, .pyo, .pyd");
                Console.WriteLine("Java\n    Paradigms: multi-paradigm: object-oriented, structured, imperative, generic, reflective\n    Appeared in: 1995\n    Influenced by: Ada 83, C++, C#, Eiffel, Generic Java, Mesa, Modula-3, Oberon, Objective-C, UCSD Pascal, Smalltalk\n    Influenced: Ada 2005, BeanShell, C#, Clojure, D, ECMAScript, Groovy, J#, JavaScript, PHP, Python, Scala, Seed7, Vala\n    Usual filename extensions: .java, .class, .jar");
                Console.WriteLine("C++\n    Paradigms: multi-paradigm: procedural, functional, object-oriented, generic\n    Appeared in: 1983\n    Influenced: Perl, LPC, Lua, Pike, Ada 95, Java, PHP, D, C99, C#, Falcon, Seed7\n    Usual filename extensions: .h .hh .hpp .hxx .h++ .cc .cpp .cxx .c++");
                Console.WriteLine("PHP\n    Paradigms: imperative, object-oriented, procedural, reflective\n    Appeared in: 1995\n    Influenced by: Perl, C, C++, Java, Tcl\n    Usual filename extensions: .php, .phtml, .php4 .php3, .php5, .phps");
                Console.WriteLine("C#\n    Paradigms: multi-paradigm: structured, imperative, object-oriented, event-driven, functional, generic, reflective, concurrent\n    Appeared in: 2000\n    Influenced by: C++, Eiffel, Java, Modula-3, Object Pascal\n    Influenced: D, F#, Java, Nemerle, Vala\n    Usual filename extensions: .cs\n");

                Console.WriteLine();
            }

            if (task == "11")
            {
                Console.Write("\nTask 11: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Describe the difference between C# and .NET Framework");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Decision: ");
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("The .Net Framework is environment in which is executed the C# code.\n");
                Console.WriteLine("The .Net Framework(initial release 13 February 2002) is a software framework developed by Microsoft that runs primarily on Microsoft Windows. It includes a large library of over 4000 classes organized into namespaces that provide a wide variety of useful functionality for everything from file input and output to string manipulation to XML parsing, to Windows Forms controls. Also it provides language interoperability across several programming languages, like C#, Visual Basic .NET, C++/CLI, Managed, F#, J#, Windows PowerShell and still more than 20 other CTS-compliant languages. The typical C# application uses the .NET Framework class library extensively to handle common \"plumbing\" chores.\n");
                Console.WriteLine("Programs written for the .NET Framework execute in a software environment, known as the Common Language Runtime (CLR), an application virtual machine that provides services such as security, automatic garbage collection, memory management, and exception handling.\n");
                Console.WriteLine("The class library and the CLR together constitute the .NET Framework.");

                Console.WriteLine();
            }

            if (task == "12")
            {
                Console.Write("\nTask 12: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Write a program to read your age from the console and print how old you will be after 10 years");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nDecision: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("using System;\n\nclass ReadPrintMyAge\n{\n    static void Main()\n    {\n        Console.Write(\"How old are you? \");\n        int age = int.Parse(Console.ReadLine());\n        Console.WriteLine(\"After 10 years you'll be \" + (age + 10) + \" years old\");\n    }\n}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nTo run the program press Enter");
                string enter12 = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;

                //Program: Age after 10 years
                Console.Write("How old are you? ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("After 10 years you'll be " + (age + 10) + " years old");

                Console.WriteLine();
            }

            if (task == "end")
            {
                Environment.Exit(0);
            }
        }
    }
}