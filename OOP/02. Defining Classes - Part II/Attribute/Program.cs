// Task 11: Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations
//          and methods and holds a version in the format major.minor (e.g. 2.11).
//          Apply the version attribute to a sample class and display its version at runtime.

using System;

namespace Attribute
{
    // Applying the attribute 'Version'
    [Version(2.11)]
    class Program
    {
        static void Main()
        {
            object[] attributes = typeof(Program).GetCustomAttributes(false);

            /* First variant */
            Console.WriteLine("Version: {0}", attributes[0]);

            /* Second variant which prints all elements */
            Console.Write("Version: ");
            foreach (VersionAttribute item in attributes)
            {
                Console.WriteLine(item.version);
            }
        }
    }
}