//Task3: Write a program that reads a text file and inserts
//       line numbers in front of each of its lines.
//       The result should be written to another text file.

using System;
using System.IO;

class InsertLine
{
    static void Main()
    {
        // The name of output file
        StreamWriter write = new StreamWriter("result.txt");
        using (write)
        {
            // Reads some text file
            StreamReader read = new StreamReader("file.txt");
            using (read)
            {
                string text = read.ReadLine();
                for (int line = 1; text != null; line++)
                {
                    // Write the result in file
                    write.WriteLine(line + ": " + text);

                    // Reads the current line
                    text = read.ReadLine();
                }
            }
        }
    }
}