//Task 10: Provide a short list with information about the most popular programming languages. How do they differ from C#?

using System;

class ProgrammingLanguages
{
    static void Main()
    {
        PrintInColor("Python");
        Console.WriteLine(@"  
  Paradigms:                    multi-paradigm: object-oriented, imperative,
                                functional, procedural, reflective
  Appeared in:                  1991
  Influenced by:                ABC, ALGOL 68, C, C++, Dylan, Haskell, Icon,
                                Java, Lisp, Modula-3");
        PrintInColor("\nPerl");
        Console.WriteLine(@"
  Influenced:                   Boo, Cobra, D, Falcon, Groovy, JavaScript,
                                F#, Nimrod, Ruby
  Usual filename extensions:    .py, .pyw, .pyc, .pyo, .pyd");

        PrintInColor("\nJava");
        Console.WriteLine(@"
  Paradigms:                    multi-paradigm: object-oriented, structured,
                                imperative, generic, reflective
  Appeared in:                  1995
  Influenced by:                Ada 83, C++, C#, Eiffel, Generic Java, Mesa,
                                Modula-3, Oberon, Objective-C, UCSD Pascal,
                                Smalltalk
  Influenced:                   Ada 2005, BeanShell, C#, Clojure, ECMAScript,
                                Groovy, D, JavaScript, PHP, Python, Scala,
                                Seed7, Vala, J#
  Usual filename extensions:    .java, .class, .jar");

        PrintInColor("\nC++");
        Console.WriteLine(@" 
  Paradigms:                    multi-paradigm: procedural, object-oriented,
                                generic, functional
  Appeared in:                  1983
  Influenced:                   Perl, LPC, Lua, Pike, Ada 95, Java, PHP, D,
                                C99, C#, Falcon
  Usual filename extensions:    .h .hh .hpp .hxx .h++ .cc .cpp .cxx .c++");

        PrintInColor("\nPHP");
        Console.WriteLine(@" 
  Paradigms:                    imperative, object-oriented, procedural,
                                reflective
  Appeared in:                  1995
  Influenced by:                Perl, C, C++, Java, Tcl
  Usual filename extensions:    .php, .phtml, .php4 .php3, .php5, .phps");

        PrintInColor("\nC#");
        Console.WriteLine(@"  
  Paradigms:                    multi-paradigm: object-oriented, event-driven,
                                imperative, generic, reflective, concurrent,
                                functional, structured
  Appeared in:                  2000
  Influenced by:                C++, Eiffel, Java, Modula-3, Object Pascal
  Influenced:                   D, F#, Java, Nemerle, Vala
  Usual filename extensions:    .cs");
        Console.ReadKey();
    }

    // Method which print some text in color
    private static void PrintInColor(string text)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}