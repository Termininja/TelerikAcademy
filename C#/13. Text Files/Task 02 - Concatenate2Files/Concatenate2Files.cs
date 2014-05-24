//Task2: Write a program that concatenates two text files into another text file.

using System;
using System.IO;
using System.Text;

class Concatenates2Files
{
    static void Main()
    {
        // The output file
        StreamWriter write = new StreamWriter("result.txt");
        using (write)
        {
            // Read some text file1 and write it to output file
            StreamReader file1 = new StreamReader("file1.txt");
            using (file1) write.WriteLine(file1.ReadToEnd());

            // Read some text file2 and write it to output file
            StreamReader file2 = new StreamReader("file2.txt");
            using (file2) write.WriteLine(file2.ReadToEnd());
        }
    }
}