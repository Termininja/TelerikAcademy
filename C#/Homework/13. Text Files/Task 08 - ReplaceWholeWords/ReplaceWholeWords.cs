//Task8: Modify the solution of the previous problem to replace only whole words (not substrings).

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class ReplaceWholeWords
{
    static void Main()
    {
        StringBuilder text = new StringBuilder();

        StreamReader read = new StreamReader("file.txt");       // reads some text file
        using (read)
        {
            // Imports the whole text file in one variable 'text'
            text.Append(read.ReadToEnd());
        }

        // Write the replaced words in the same file
        StreamWriter write = new StreamWriter("file.txt");
        using (write)
        {
            // Replace only the words
            write.WriteLine(Regex.Replace(text.ToString(), @"\bstart\b", "finish"));
        }
    }
}