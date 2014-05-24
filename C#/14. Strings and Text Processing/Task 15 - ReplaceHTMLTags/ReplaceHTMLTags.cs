//Task15: Write a program that replaces in a HTML document given as string all the tags
//        <a href="…">…</a> with corresponding tags [URL=…]…/URL]. Sample HTML fragment:
//              "<p>Please visit <a href="http://academy.telerik. com">our site</a>
//              to choose a training course. Also visit <a href="www.devbg.org">our
//              forum</a> to discuss the courses.</p>"
//        Result:
//              "<p>Please visit [URL=http://academy.telerik.com]our site[/URL] to
//              choose a training course. Also visit [URL=www.devbg.org]our forum[/URL]
//              to discuss the courses.</p>"

using System;
using System.Text.RegularExpressions;

class ReplaceHTMLTags
{
    static void Main()
    {
        /* By using regular expressions we can split the text
         * to two groups, and replace directly the matches
         * outside the groups (1 and 2) with "[URL=", "]" and "[/URL]"
         */
        string TextInHTML = @"<p>Please visit <a href=""http://academy.telerik.com"">our site</a> to choose...</p>";
        Console.WriteLine(Regex.Replace(TextInHTML, @"<a href=""(.*?)"">(.*?)</a>",
            m => "[URL=" + m.Groups[1] + "]" + m.Groups[2] + "[/URL]"));
        Console.WriteLine();
    }
}