//Task12: Write a program that removes from a text file
//        all words listed in given another text file.
//        Handle all possible exceptions in your methods.

using System;
using System.IO;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

class RemoveWordsThatAreInOtherFile
{
    static void Main()
    {
        try
        {
            StringBuilder result = new StringBuilder();

            // Reads some text file
            StreamReader readText = new StreamReader("file.txt");
            using (readText) result.Append(readText.ReadToEnd());

            // Reads some file with words
            StreamReader readWords = new StreamReader("words.txt");
            string word = readWords.ReadLine();

            // For each one word in the file with words
            for (int line = 1; word != null; line++)
            {
                // Removes the current word
                StringBuilder temp = new StringBuilder();
                temp.Append(Regex.Replace(result.ToString(), String.Format(@"\b{0}\b", word), String.Empty));
                result = temp;

                // Reads the next word
                word = readWords.ReadLine();
            }

            // Prints the result
            Console.WriteLine(result);
        }

        // Handle all possible exceptions
        catch (FileNotFoundException e) { Console.WriteLine(e.Message); }
        catch (IOException e) { Console.WriteLine(e.Message); }
        catch (SecurityException e) { Console.WriteLine(e.Message); }
        catch (OutOfMemoryException e) { Console.WriteLine(e.Message); }
    }
}
