//Task 10: Provide a short list with information about the most popular programming languages. How do they differ from C#?

using System;

class ProgrammingLanguages
{
    static void Main()
    {
        Console.Write("Task: ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Provide a short list with information about the most popular programming languages. How do they differ from C#?");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Solution: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Python\n    Paradigms: multi-paradigm: object-oriented, imperative, functional, procedural, reflective\n    Appeared in: 1991\n    Influenced by: ABC, ALGOL 68, C, C++, Dylan, Haskell, Icon, Java, Lisp, Modula-3, Perl\n    Influenced: Boo, Cobra, D, Falcon, Groovy, JavaScript, F#, Nimrod, Ruby\n    Usual filename extensions: .py, .pyw, .pyc, .pyo, .pyd");
        Console.WriteLine("Java\n    Paradigms: multi-paradigm: object-oriented, structured, imperative, generic, reflective\n    Appeared in: 1995\n    Influenced by: Ada 83, C++, C#, Eiffel, Generic Java, Mesa, Modula-3, Oberon, Objective-C, UCSD Pascal, Smalltalk\n    Influenced: Ada 2005, BeanShell, C#, Clojure, D, ECMAScript, Groovy, J#, JavaScript, PHP, Python, Scala, Seed7, Vala\n    Usual filename extensions: .java, .class, .jar");
        Console.WriteLine("C++\n    Paradigms: multi-paradigm: procedural, functional, object-oriented, generic\n    Appeared in: 1983\n    Influenced: Perl, LPC, Lua, Pike, Ada 95, Java, PHP, D, C99, C#, Falcon, Seed7\n    Usual filename extensions: .h .hh .hpp .hxx .h++ .cc .cpp .cxx .c++");
        Console.WriteLine("PHP\n    Paradigms: imperative, object-oriented, procedural, reflective\n    Appeared in: 1995\n    Influenced by: Perl, C, C++, Java, Tcl\n    Usual filename extensions: .php, .phtml, .php4 .php3, .php5, .phps");
        Console.WriteLine("C#\n    Paradigms: multi-paradigm: structured, imperative, object-oriented, event-driven, functional, generic, reflective, concurrent\n    Appeared in: 2000\n    Influenced by: C++, Eiffel, Java, Modula-3, Object Pascal\n    Influenced: D, F#, Java, Nemerle, Vala\n    Usual filename extensions: .cs\n");
        Console.ResetColor();
    }
}