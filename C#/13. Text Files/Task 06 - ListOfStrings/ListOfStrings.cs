//Task6: Write a program that reads a text file containing a list of strings,
//       sorts them and saves them to another text file. Example:
//          Ivan			    George
//      	Peter	    →		Ivan
//      	Maria			    Maria
//      	George			    Peter

using System;
using System.Collections.Generic;
using System.IO;

class ListOfStrings
{
    static void Main()
    {
        // Reads some text file
        StreamReader read = new StreamReader("file.txt");
        using (read)
        {
            // Creates an empty list and fill it
            string line = read.ReadLine();
            List<string> list = new List<string>();
            for (int l = 0; line != null; l++)
            {
                // Adds each one word from the file in the list
                list.Add(line);

                // Reads the next line
                line = read.ReadLine();
            }

            // Sorting the list
            list.Sort();

            // Write the sorted list in some output file
            StreamWriter write = new StreamWriter("output.txt");
            using (write)
            {
                foreach (var word in list)
                {
                    write.WriteLine(word);
                }
            }
        }
    }
}