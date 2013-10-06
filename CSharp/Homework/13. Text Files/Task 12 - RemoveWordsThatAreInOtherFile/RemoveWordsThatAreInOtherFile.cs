//Task12: Write a program that removes from a text file all words listed in given another text file.
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

            StreamReader readText = new StreamReader("file.txt");           // reads some text file
            using (readText) result.Append(readText.ReadToEnd());

            StreamReader readWords = new StreamReader("words.txt");         // reads some file with words
            string word = readWords.ReadLine();
            for (int line = 1; word != null; line++)                        // for each one word in the file with words
            {
                // Removes the current word
                StringBuilder temp = new StringBuilder();
                temp.Append(Regex.Replace(result.ToString(), @"\w+", m => m.Value.Replace(word == m.Value ? word : " ", "")));
                result = temp;
                word = readWords.ReadLine();                                // reads the next word
            }

            Console.WriteLine(result);                                      // prints the result
        }

        // Handle all possible exceptions
        catch (FileNotFoundException e) { Console.WriteLine(e.Message); }
        catch (IOException e) { Console.WriteLine(e.Message); }
        catch (SecurityException e) { Console.WriteLine(e.Message); }
        catch (OutOfMemoryException e) { Console.WriteLine(e.Message); }
    }
}