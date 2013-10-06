//Task7: Write a program that replaces all occurrences of the substring "start" with the
//       substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class Substring
{
    static void Main()
    {
        StringBuilder text = new StringBuilder();          

        StreamReader read = new StreamReader("file.txt");       // reads some text file
        using (read)
        {
            // Imports the whole text file in variable 'text'
            text.Append(read.ReadToEnd());                     
        }

        // Write the replaced substrings in the same file
        StreamWriter write = new StreamWriter("file.txt");
        using (write)
        {
            // Replace the substrings
            write.WriteLine(Regex.Replace(text.ToString(), @"start", "finish"));
        }
    }
}
