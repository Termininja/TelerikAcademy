//Task 6: Declare a boolean variable called isFemale and assign an appropriate value corresponding to your gender.

using System;

class DeclareBool
{
    static void Main()
    {
        bool isFemale;
        Console.Write("What is your gender (male/female): ");
        string gender = Console.ReadLine();
        if (gender == "female")
        {
            isFemale = true;
        }
        else
        {
            isFemale = false;
        }
        Console.WriteLine("You are female: {0}!", isFemale);
    }
}