// Task 11: Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations
//          and methods and holds a version in the format major.minor (e.g. 2.11).
//          Apply the version attribute to a sample class and display its version at runtime.

using System;

namespace Attribute
{
    [Version(2.11)]
    class TestProgram
    {
        static void Main()
        {
            Type type = typeof(TestProgram);
            object[] versionAttributes = type.GetCustomAttributes(false);
            Console.WriteLine("Version: {0}", versionAttributes[0]);
        }
    }
}