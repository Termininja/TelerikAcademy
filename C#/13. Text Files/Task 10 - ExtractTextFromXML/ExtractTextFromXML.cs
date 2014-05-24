//Task10: Write a program that extracts from given XML file all the text without the tags. Example:
//        <?xml version="1.0"><student><name>Pesho</name><age>21</age><interests count="3"><interest>
//        Games</instrest><interest>C#</instrest><interest> Java</instrest></interests></student>

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class ExtractTextFromXML
{
    static void Main()
    {
        StringBuilder contents = new StringBuilder();

        // Reads some xml file and takes all contents
        StreamReader read = new StreamReader("file.xml");
        using (read) contents.Append(read.ReadToEnd());

        // Prints only the text without the tags
        foreach (Match item in Regex.Matches(contents.ToString(), @">([^<].?\w*.?)<"))
        {
            Console.WriteLine(item.Groups[1].ToString().Trim());
        }
    }
}