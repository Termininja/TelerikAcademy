//Task4: Write a program that compares two text files line by line
//       and prints the number of lines that are the same and the number of lines
//       that are different. Assume the files have equal number of lines.

using System;
using System.IO;

class Compare2Files
{
    static void Main()
    {
        StreamReader file1 = new StreamReader("file1.txt");     // reads some text file 1
        StreamReader file2 = new StreamReader("file2.txt");     // reads some text file 2

        using (file1)
        {
            using (file2)
            {
                string text = file1.ReadLine();
                int equal = 0;
                int notequal = 0;
                for (int line = 1; text != null; line++)
                {
                    if (text == file2.ReadLine()) equal++;      // the same lines 
                    else notequal++;                            // different lines
                    text = file1.ReadLine();                    // reads the current line in file 1
                }

                // Prints the result
                Console.WriteLine("The same lines: " + equal);
                Console.WriteLine("Different lines: " + notequal);
            }
        }
    }
}