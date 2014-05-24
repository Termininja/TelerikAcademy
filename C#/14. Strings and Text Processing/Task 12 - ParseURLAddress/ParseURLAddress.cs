//Task12: Write a program that parses an URL address given in the format:
//              [protocol]://[server]/[resource]
//        and extracts from it the [protocol], [server] and [resource] elements. For example from the URL
//        http://www.devbg.org/forum/index.php the following information should be extracted:
//              [protocol] = "http"
//		        [server] = "www.devbg.org"
//		        [resource] = "/forum/index.php"

using System;
using System.Text.RegularExpressions;

class ParseURLAddress
{
    static void Main()
    {
        #region Long variant
        try
        {
            // Reads some URL address
            Console.Write("Please, enter some URL address: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string url = Console.ReadLine();
            Console.ResetColor();

            byte count = 0;
            int i = 0;

            // Search the 3rd '/' in URL
            for (i = 0; i < url.Length; i++)
            {
                if (url[i] == '/')
                {
                    count++;
                    if (count == 3) break;
                }
            }

            Console.WriteLine();
            Print("protocol", url.Remove(url.IndexOf(':')));
            Print("server", url.Substring(url.IndexOf("://") + 3, i - url.IndexOf("://") - 3));
            Print("resource", url.Substring(i));
        }
        catch (Exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The URL is not correct!"); ;
            Console.ResetColor();
        }
        #endregion

        #region Short variant (with regular expressions)
        //Match result = Regex.Match(url, @"(\w*)://(.*?)/(.*)");
        //Console.WriteLine(result.Groups[1]);
        //Console.WriteLine(result.Groups[2]);
        //Console.WriteLine(result.Groups[3]);
        #endregion
    }

    // Prints some name with his value
    static void Print(string name, dynamic value)
    {
        Console.Write(name + " = ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(value);
        Console.ResetColor();
    }
}