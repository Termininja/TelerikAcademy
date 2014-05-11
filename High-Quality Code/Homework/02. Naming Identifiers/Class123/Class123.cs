//Task 1. Refactor the following examples to produce code with well-named C# identifiers:

using System;

class MainClass
{
    private const int max_count = 6;

    class Print
    {
        public void ToString(bool variable)
        {
            Console.WriteLine(variable.ToString());
        }
    }

    public static void Input()
    {
        MainClass.Print instance = new MainClass.Print();
        instance.ToString(true);
    }

    static void Main()
    {
        //delete me
    }
}
