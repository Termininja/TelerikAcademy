//Task1: Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.IO;

class PrintOddLines
{
    static void Main()
    {
        // Reads some text file
        StreamReader read = new StreamReader("file.txt");
        using (read)
        {
            string text = read.ReadLine();
            for (int line = 1; text != null; line++)
            {
                // Prints only odd lines
                if (line % 2 != 0) Console.WriteLine(text);

                // Reads the current line
                text = read.ReadLine();
            }
        }
    }
}