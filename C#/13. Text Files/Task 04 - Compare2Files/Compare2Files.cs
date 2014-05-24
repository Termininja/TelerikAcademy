//Task4: Write a program that compares two text files line by line
//       and prints the number of lines that are the same and the number of lines
//       that are different. Assume the files have equal number of lines.

using System;
using System.IO;

class Compare2Files
{
    static void Main()
    {
        // Reads two text files
        StreamReader file1 = new StreamReader("file1.txt");
        StreamReader file2 = new StreamReader("file2.txt");

        using (file1)
        {
            using (file2)
            {
                // Compares the both files line by line
                string text = file1.ReadLine();
                int equal = 0;
                int notequal = 0;
                for (int line = 1; text != null; line++)
                {
                    if (text == file2.ReadLine()) equal++;
                    else notequal++;
                    text = file1.ReadLine();
                }

                // Prints the result
                Console.WriteLine("The same lines: " + equal);
                Console.WriteLine("Different lines: " + notequal);
            }
        }
    }
}