//Task1: Describe the strings in C#. What is typical for the string data type?
//       Describe the most important methods of the String class.

using System;

class DescribingString
{
    static void Main()
    {
        Console.WriteLine(@"String is array of chars. The most important methods of the String class are:
 * CompareTo() - compares two strings by first letter
 * Substring() - extracts substring from some string
 * Concat() - concatenates two strings
 * IndexOf() - returns index of char or string in string
 * ToLower() - converts string to lowercase
 * ToUpper() - converts string to uppercase
 * Split() - returns a string array which is splitted by using char separator
 * Replace() - returns a new string in which one substring is replaced by other
 * Remove() - removes substring from some string
 * Contains() - search string in string
 * Equals() - compares two strings
 * Insert() - inserts a new string on position in some other string
 * Trim() - removes all leading and trailing white-spaces from the string");
    }
}