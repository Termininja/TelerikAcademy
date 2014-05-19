//Task 1. Refactor the following examples to produce code with well-named C# identifiers:

using System;

class Printer
{
    private const int MaxCount = 6;

    class Print
    {
        public void ToString(bool variable)
        {
            Console.WriteLine(variable.ToString());
        }
    }

    static void Main()
    {
        Print printer = new Print();
        printer.ToString(true);
    }
}
