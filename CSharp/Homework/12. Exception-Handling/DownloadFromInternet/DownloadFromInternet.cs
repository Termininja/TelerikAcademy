//Task4: Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg)
//       and stores it the current directory. Find in Google how to download files in C#.
//       Be sure to catch all exceptions and to free any used resources in the finally block.

using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

class DownloadFromInternet
{
    static void Main()
    {
        using (WebClient client = new WebClient())
        {
            try
            {
                Console.WriteLine("Please, enter some file address in Internet: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string url = Console.ReadLine();                // reads some file address in Internet
                Console.ResetColor();

                Match filename = Regex.Match(url, @"[^\/]+\.\w+$");     // takes the name of the file

                // checks the size of the file before to be downloaded
                client.OpenRead(url);
                Int64 bytes = Convert.ToInt64(client.ResponseHeaders["Content-Length"]);
                Console.Write("\nThe size of the file is "+ bytes.ToString() + " Bytes. Press <Enter> to start downloading");
                Console.ReadLine();

                client.DownloadFile(url, filename.ToString());          // downloads the file
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The file is successfully downloaded!");
                Console.ResetColor();
            }
            catch (WebException)
            {
                Error("File not found!");
            }
            catch (ArgumentException)
            {
                Error("The path is not of a legal form!");
            }
            catch (PathTooLongException)
            {
                Error("The specified path, file name, or both are too long!");
            }
        }
    }

    static void Error(string error)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n" + error);
        Console.ResetColor();
    }
}