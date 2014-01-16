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

        // Reads some text file
        StreamReader read = new StreamReader("file.txt");
        using (read)
        {
            string text = read.ReadLine();
            for (int line = 1; text != null; line++)
            {
                // Delete the odd lines
                if (line % 2 == 0) contents.Append(text + "\n");

                // Reads the next line
                text = read.ReadLine();
                if (text == null) contents.Remove(contents.Length - 1, 1);
            }
        }

        // Write the result in the same file
        StreamWriter write = new StreamWriter("file.txt");
        using (write) write.WriteLine(contents);
    }
}