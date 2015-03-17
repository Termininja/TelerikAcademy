/* 
 * Problem 11. Version attribute:
 *     Create a [Version] attribute that can be applied to structures, classes, interfaces,
 *     enumerations and methods and holds a version in the format major.minor (e.g. 2.11).
 *     Apply the version attribute to a sample class and display its version at runtime.
 */

namespace Attribute
{
    using System;

    [Version(2.11)]
    public class Program
    {
        public static void Main()
        {
            var attributes = typeof(Program).GetCustomAttributes(false);

            Console.WriteLine("Version: {0}", attributes[0]);
        }
    }
}