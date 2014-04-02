## Strings

**Task 01.** Write a JavaScript function reverses string and returns it.
Example: "sample" → "elpmas"

**Task 02.** Write a JavaScript function to check if in a given expression the brackets are put correctly.
Example of correct expression: ((a+b)/5-d)
Example of incorrect expression: )(a+b))

**Task 03.** Write a JavaScript function that finds how many times a substring is contained in a given text (perform case insensitive search).
Example: The target substring is "`in`". The text is as follows:
				We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.
The result is: 9.

**Task 04.** You are given a text. Write a function that changes the text in all regions:
- `<upcase>`text`</upcase>` to uppercase.
- `<lowcase>`text`</lowcase>` to lowercase
- `<mixcase>`text`</mixcase>` to mix casing(random)
				`We are` <mixcase>living</mixcase> `in a` <upcase>yellow submarine</upcase>. `We` <mixcase>don't</mixcase> `have` <lowcase>anything</lowcase> `else`.
The expected result:
				`We are` LiVinG `in a` YELLOW SUBMARINE. `We` dOn'T `have` anything `else`.
Regions can be nested

**Task 05.** Write a function that replaces non breaking white-spaces in a text with `&nbsp;`

**Task 06.** Write a function that extracts the content of a html page given as text. The function should return anything that is in a tag, without the tags:
				<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>
result:
				Sample sitetextmore textand more...in body

**Task 07.** Write a script that parses an URL address given in the format:
				[protocol]://[server]/[resource]
and extracts from it the `[protocol]`, `[server]` and `[resource]` elements. Return the elements in a JSON object.
For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
				{protocol: "http",
				 server: "www.devbg.org", 
				 resource: "/forum/index.php"}

**Task 08.** Write a JavaScript function that replaces in a HTML document given as string all the tags `<a href="…">…</a>` with corresponding tags `[URL=…]…/URL]`. Sample HTML fragment:
				<p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
	result:			
				<p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose a training course. Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>

**Task 09.** Write a function for extracting all email addresses from given text. All substrings that match the format `<identifier>@<host>…<domain>` should be recognized as emails. Return the emails as array of strings.

**Task 10.** Write a program that extracts from a given text all palindromes, e.g. "`ABBA`", "`lamal`", "`exe`".
				var str = stringFormat("Hello {0}!","Peter");
				//str = "Hello Peter!";

**Task 11.** Write a function that formats a string using placeholders:
				var str = stringFormat("Hello {0}!","Peter");
				//str = "Hello Peter!";
The function should work with up to 30 placeholders and all types:
				var format = "{0}, {1}, {0} text {2}";
				var str = stringFormat(format,1,"Pesho","Gosho");
				//str = "1, Pesho, 1 text Gosho"

**Task 12.** Write a function that creates a HTML UL using a template for every HTML LI. The source of the list should an array of elements. Replace all placeholders marked with –{…}–   with the value of the corresponding property of the object.
Example:
				<div data-type="template" id="list-item">
				 <strong>-{name}-</strong> <span>-{age}-</span>
				/div>

				var people = [{name: "Peter", age: 14},…];
				var tmpl = document.getElementById("list-item").innerHtml;
				var peopleList = generateList(people,template);
				//peopleList = "<ul><li><strong>Peter</strong> <span>14</span></li><li>…</li>…</ul>"
