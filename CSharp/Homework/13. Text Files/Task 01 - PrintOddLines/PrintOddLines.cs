//Task1: Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.IO;

class PrintOddLines
{
    static void Main()
    {
        StreamReader read = new StreamReader("file.txt");       // reads some text file
        using (read)
        {
            string text = read.ReadLine();
            for (int line = 1; text != null; line++)
            {
                if (line % 2 != 0) Console.WriteLine(text);     // prints only odd lines
                text = read.ReadLine();                         // reads the current line
            }
        }
    }
}