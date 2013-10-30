//Task9: Write a program that deletes from given text file all odd lines.
//       The result should be in the same file.

using System;
using System.IO;
using System.Text;

class DeleteOddLines
{
    static void Main()
    {
        StringBuilder contents = new StringBuilder();

        StreamReader read = new StreamReader("file.txt");           // reads some text file
        using (read)
        {
            string text = read.ReadLine();
            for (int line = 1; text != null; line++)
            {
                if (line % 2 == 0) contents.Append(text + "\n");    // delete the odd lines
                text = read.ReadLine();                             // reads the next line
                if (text == null) contents.Remove(contents.Length - 1, 1);
            }
        }

        // Write the result in the same file
        StreamWriter write = new StreamWriter("file.txt");
        using (write) write.WriteLine(contents);
    }
}