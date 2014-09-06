## Linear Data Structures

**Task 01.** Write a program that reads from the console a sequence of positive integer numbers. The sequence ends when empty line is entered. Calculate and print the sum and average of the elements of the sequence. Keep the sequence in `List<int>`.

**Task 02.** Write a program that reads N integers from the console and reverses them using a stack. Use the `Stack<int>` class.

**Task 03.** Write a program that reads a sequence of integers (`List<int>`) ending with an empty line and sorts them in an increasing order.

**Task 04.** Write a method that finds the longest subsequence of equal numbers in given `List<int>` and returns the result as new `List<int>`. Write a program to test whether the method works correctly.

**Task 05.** Write a program that removes from given sequence all negative numbers.

**Task 06.** Write a program that removes from given sequence all numbers that occur odd number of times.
>Example: {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} → **{5, 3, 3, 5}**

**Task 07.** Write a program that finds in given array of integers (all belonging to the range [0...1000]) how many times each of them occurs.
>Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
 * 2 → **2 times**
 * 3 → **4 times**
 * 4 → **3 times**

**Task 08\*.** The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. Write a program to find the majorant of given array (if exists).
>Example: {2, 2, 3, 3, 2, 3, 4, 3, 3} → **3**

**Task 09.** We are given the following sequence:
 * S1 = N;
 * S2 = S1 + 1;
 * S3 = 2*S1 + 1;
 * S4 = S1 + 2;
 * S5 = S2 + 1;
 * S6 = 2*S2 + 1;
 * S7 = S2 + 2;
 * ...

Using the `Queue<T>` class write a program to print its first 50 members for given N.
>Example: N=2 → **2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...**

**Task 10\*.** We are given numbers N and M and the following operations:
 * N = N+1
 * N = N+2
 * N = N*2
 
Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M. Hint: use a queue.
>Example: N = 5, M = 16; Sequence: 5 → 7 → 8 → 16

**Task 11.** Implement the data structure `linked list`. Define a class `ListItem<T>` that has two fields: `value` (of type `T`) and `NextItem` (of type `ListItem<T>`). Define additionally a class `LinkedList<T>` with a single field `FirstElement` (of type `ListItem<T>`).

**Task 12.** Implement the ADT `stack` as auto-resizable array. Resize the capacity on demand (when no space is available to add / insert a new element).

**Task 13.** Implement the ADT `queue` as dynamic linked list. Use generics (`LinkedQueue<T>`) to allow storing different data types in the queue.

**Task 14\*.** We are given a labyrinth of size N x N. Some of its cells are empty (`0`) and some are full (`x`). We can move from an empty cell to another empty cell if they share common wall. Given a starting position (*) calculate and fill in the array the minimal distance from this position to any other cell in the array. Use "`u`" for all unreachable cells.
>Example:

>Input table
<table>
    <tr><td>0</td><td>0</td><td>0</td><td>x</td><td>0</td><td>x</td></tr>
    <tr><td>0</td><td>x</td><td>0</td><td>x</td><td>0</td><td>x</td></tr>
	<tr><td>0</td><td>*</td><td>x</td><td>0</td><td>x</td><td>0</td></tr>
    <tr><td>0</td><td>x</td><td>0</td><td>0</td><td>0</td><td>0</td></tr>
    <tr><td>0</td><td>0</td><td>0</td><td>x</td><td>x</td><td>0</td></tr>
    <tr><td>0</td><td>0</td><td>0</td><td>x</td><td>0</td><td>x</td></tr>
</table>

>Output table
<table>
    <tr><td>3</td><td>4</td><td>5</td><td>x</td><td>u</td><td>x</td></tr>
    <tr><td>2</td><td>x</td><td>6</td><td>x</td><td>u</td><td>x</td></tr>
	<tr><td>1</td><td>*</td><td>x</td><td>8</td><td>x</td><td>10</td></tr>
    <tr><td>2</td><td>x</td><td>6</td><td>7</td><td>8</td><td>9</td></tr>
    <tr><td>3</td><td>4</td><td>5</td><td>x</td><td>x</td><td>10</td></tr>
    <tr><td>4</td><td>5</td><td>6</td><td>x</td><td>u</td><td>x</td></tr>
</table>
