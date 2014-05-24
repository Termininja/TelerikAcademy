//Task3: Write a program that enters file name along with its
//       full file path (e.g. C:\WINDOWS\win.ini), reads its
//       contents and prints it on the console. Find in MSDN
//       how to use System.IO.File.ReadAllText(…). Be sure to
//       catch all possible exceptions and print user-friendly
//       error messages.

using System;
using System.IO;
using System.Security;

class ReadAllText
{
    static void Main()
    {
        try
        {
            // Reads some file path
            Console.Write("Please, enter the full file path: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string path = Console.ReadLine();

            // Prints the contents of the file
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(File.ReadAllText(path));
            Console.ResetColor();
        }

        catch (ArgumentNullException)
        {
            Error("Path is null.");
        }

        catch (ArgumentException)
        {
            Error("Path is a zero-length string, contains only white space, or contains one or more invalid characters.");
        }

        catch (PathTooLongException)
        {
            Error("The specified path, file name, or both exceed the system-defined maximum length.");
        }

        catch (DirectoryNotFoundException)
        {
            Error("The specified path is invalid.");
        }

        catch (FileNotFoundException)
        {
            Error("The file specified in path was not found.");
        }

        catch (IOException)
        {
            Error("An I/O error occurred while opening the file.");
        }

        catch (UnauthorizedAccessException)
        {
            Error("Operating system denies access because of an I/O error or a specific type of security error");
        }

        catch (NotSupportedException)
        {
            Error("Path is in an invalid format.");
        }

        catch (SecurityException)
        {
            Error("The caller does not have the required permission.");
        }
    }

    static void Error(string error)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n" + error);
        Console.ResetColor();
    }
}