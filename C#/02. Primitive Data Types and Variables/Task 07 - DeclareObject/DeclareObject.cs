//Task 7: Declare two string variables and asssign them with “Hello” and “World”. Declare an
//        object variable and assign it with the concatenation of the first two variables
//        (mind adding an interval). Declare a third string variable and initialize it with
//        the value of the object variable (you should perform type casting).

using System;

class DeclareObject
{
    static void Main()
    {
        // Declaring two string variables
        string word1 = "Hello";
        string word2 = "World";

        // Concatenation of both string variables
        object join = word1 + " " + word2;

        // Declaring a third string variable
        string @string = (string)join;

        // Print the result
        Console.WriteLine(@string + "!");
    }
}