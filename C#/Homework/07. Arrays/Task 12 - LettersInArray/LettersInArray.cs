//12. Write a program that creates an array containing all letters from the alphabet (A-Z).
//    Read a word from the console and print the index of each of its letters in the array.

using System;

class LettersInArray
{
    static void Main()
    {
        char[] array = new char['Z' - 'A' + 1];

        for (int i = 0; i < array.Length; i++)                  // fills the array with letters
        {
            array[i] = (char)(i + 'A');
        }
        
        foreach (var item in Console.ReadLine())                // reads some word
        {
            char letter = char.ToUpper(item);
            for (int i = 0; i < array.Length; i++)              // for each letter from the word
            {
                if (letter == array[i])
                {
                    Console.WriteLine(letter + " -> " + i);     // prints the result
                    break;
                }
            }
        }
    }
}