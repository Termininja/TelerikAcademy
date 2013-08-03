//Task 8: Declare two string variables and assign them with following value: The "use" of quotations causes difficulties.
//Do the above in two different ways: with and without using quoted strings.

using System;

class DeclareTwoStrings
{
    static void Main()
    {
        string string1 = "The \"use\" of quotations causes difficulties.";
        string string2 = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(string1 + "\n" + string2);
    }
}