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
        StreamReader read = new StreamReader("file.txt");           // reads some text file
        using (read)
        {
            string line = read.ReadLine();
            List<string> list = new List<string>();                 // creates empty list
            for (int l = 0; line != null; l++)
            {
                // Adds each one word from the file in the list
                list.Add(line);
                line = read.ReadLine();                             // reads the next line
            }
            list.Sort();                                            // sorting the list
            StreamWriter write = new StreamWriter("output.txt");
            using (write)
            {
                // Write the sorted list in some output file
                foreach (var word in list)      
                {
                    write.WriteLine(word);
                }
            }
        }
    }
}