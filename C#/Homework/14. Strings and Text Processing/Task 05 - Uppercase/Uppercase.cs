//Task5: Write a program that changes some given text in all regions surrounded by the tags
//       <upcase> and </upcase> to uppercase. The tags cannot be nested.
//       Example:
//          "We are living in a <upcase>yellow submarine</upcase>.
//           We don't have <upcase>anything</upcase> else."
//       The expected result: "We are living in a YELLOW SUBMARINE. We don't have ANYTHING else."

using System;
using System.Text.RegularExpressions;

class Uppercase
{
    static void Main()
    {
        #region Long variant
        // Reads some text
        Console.Write("Please, write some text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine();
        Console.ResetColor();

        while (true)
        {
            // Find the open-tag
            int index_start = text.IndexOf("<upcase>");

            // Find the close-tag
            int index_end = text.IndexOf("</upcase>");

            // If the result is not "-1"
            if (index_start >= 0)
            {
                // extract the tagged text
                string tagged = text.Substring(index_start + 8, index_end - index_start - 8);

                // Remove the tagged text
                text = text.Remove(index_start, index_end - index_start + 9);

                // Insert the uppered tagged text
                text = text.Insert(index_start, tagged.ToUpper());
            }
            else break;
        }

        // Prints the final result
        Console.Write("\nThe result is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);
        Console.ResetColor();
        #endregion

        #region Short variant (with regular expressions)
        //Console.WriteLine(Regex.Replace(text, "<upcase>(.*?)</upcase>", m => m.Groups[1].Value.ToUpper()));
        #endregion
    }
}