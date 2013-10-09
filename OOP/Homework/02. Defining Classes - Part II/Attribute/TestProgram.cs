// Task 11: Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations
//          and methods and holds a version in the format major.minor (e.g. 2.11).
//          Apply the version attribute to a sample class and display its version at runtime.

using System;

namespace Attribute
{
    [Version(2.11)]                                                 // applying the attribute 'Version'
    class TestProgram
    {
        static void Main()
        {
            Type t = typeof(TestProgram);                           // takes the type of class 'TestProgram'
            object[] attributes = t.GetCustomAttributes(false);

            Console.WriteLine("Version: {0}", attributes[0]);
            //foreach (VersionAttribute item in attributes)         // second variant which prints all elements
            //    Console.WriteLine(item.version);
        }
    }
}