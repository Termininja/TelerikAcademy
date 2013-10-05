//Task3: Write a program that reads a text file and inserts line numbers in front of each of its lines.
//       The result should be written to another text file.

using System;
using System.IO;

class InsertLine
{
    static void Main()
    {
        StreamWriter write = new StreamWriter("result.txt");        // the name of output file
        using (write)
        {
            StreamReader read = new StreamReader("file.txt");       // reads some text file
            using (read)
            {
                string text = read.ReadLine();
                for (int line = 1; text != null; line++)
                {
                    write.WriteLine(line + ": " + text);            // write the result in file
                    text = read.ReadLine();                         // reads the current line
                }
            }
        }
    }
}