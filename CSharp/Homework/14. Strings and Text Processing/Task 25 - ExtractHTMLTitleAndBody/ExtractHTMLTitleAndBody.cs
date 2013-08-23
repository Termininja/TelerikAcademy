//Task25: Write a program that extracts from given HTML file its title (if available),
//        and its body text without the HTML tags. Example:
//              <html>
//                <head><title>News</title></head>
//                <body><p><a href="http://academy.telerik.com">Telerik
//                  Academy</a>aims to provide free real-world practical
//                  training for young people who want to turn into
//                  skillful .NET software engineers.</p></body>
//              </html>

using System;
using System.Text.RegularExpressions;

class ExtractHTMLTitleAndBody
{
    static void Main()
    {
        string TextInHTML = @"<html><head><title>News</title></head>
<body><p><a href=""http://academy.telerik.com"">Telerik Academy</a> aims to provide free real-world practical training...</p></body></html>";
        Console.WriteLine(Regex.Replace(TextInHTML, @"<title>(.*)</title>|<a href="".*?"">(.*?)</a>|</?\w+>", m => m.Groups[1] + "" + m.Groups[2] + ""));
    }
}