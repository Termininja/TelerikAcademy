## Extension Methods, Delegates, Lambda and LINQ

**Task 01.** Implement an extension method `Substring(int index, int length)` for the class `StringBuilder` that returns new `StringBuilder` and has the same functionality as `Substring` in the class `String`.

**Task 02.** Implement a set of extension methods for `IEnumerable<T>` that implement the following group functions: sum, product, min, max, average.

**Task 03.** Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Use LINQ query operators.

**Task 04.** Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

**Task 05.** Using the extension methods `OrderBy()` and `ThenBy()` with lambda expressions sort the students by first name and last name in descending order. Rewrite the same with LINQ.

**Task 06.** Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

**Task 07.** Using delegates write a class `Timer` that has can execute certain method at each `t` seconds.

**Task 08\*.** Read in MSDN about the keyword `event` in C# and <a href=http://msdn.microsoft.com/en-us/library/w369ty8x.aspx>how to publish events</a>. Re-implement the above using .NET events and following the best practices.