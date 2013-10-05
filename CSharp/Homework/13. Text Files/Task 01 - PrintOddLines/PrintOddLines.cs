//Task1: Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.IO;

class PrintOddLines
{
    static void Main()
    {
        StreamReader read = new StreamReader("file.txt");         	// reads some text file
        using (read)
        {
            for (int line = 1; ; line++)
            {
                string text = read.ReadLine();                      // reads the current line
                if (text == null) break;                            // stop in the end of the file
                if (line % 2 != 0)
                {
                    Console.WriteLine(text);                        // prints only odd lines
                }
            }
        }
    }
}