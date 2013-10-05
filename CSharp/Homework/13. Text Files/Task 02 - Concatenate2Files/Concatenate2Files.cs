//Task2: Write a program that concatenates two text files into another text file.

using System;
using System.IO;
using System.Text;

class Concatenates2Files
{
    static void Main()
    {
        StreamWriter write = new StreamWriter("result.txt");        // the output file 
        using (write)
        {
            StreamReader file1 = new StreamReader("file1.txt");     // read some text file 1
            using (file1) write.WriteLine(file1.ReadToEnd());       // write file 1 to output file

            StreamReader file2 = new StreamReader("file2.txt");     // read some text file 2
            using (file2) write.WriteLine(file2.ReadToEnd());       // write file 2 to output file
        }
    }
}