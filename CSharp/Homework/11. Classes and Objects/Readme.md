## Using Classes and Objects

**Task 1.** Write a program that reads a year from the console and checks whether it is a leap. Use `System.DateTime`.

**Task 2.** Write a program that generates and prints to the console 10 random values in the range [100, 200].

**Task 3.** Write a program that prints to the console which day of the week is today. Use `System.DateTime`.

**Task 4.** Write methods that calculate the surface of a triangle by given:
   * Side and an altitude to it;
   * Three sides;
   * Two sides and an angle between them.

**Task 5.** Write a method that calculates the number of workdays between today and given date, passed as parameter. Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

**Task 6.** You are given a sequence of positive integer values written into a string, separated by spaces. Write a function that reads these values from given string and calculates their sum.
>Example: string = "43 68 9 23 318" → **result = 461**

**Task 7\*.** Write a program that calculates the value of given arithmetical expression. The expression can contain the following elements only:
   * Real numbers, e.g. 5, 18.33, 3.14159, 12.6
   * Arithmetic operators: +, -, *, / (standard priorities)
   * Mathematical functions: ln(x), sqrt(x), pow(x,y)
   * Brackets (for changing the default priorities)

>Examples:
* (3+5.3) \* 2.7 - ln(22) / pow(2.2, -1.7) → **~10.6**
* pow(2, 3.14) \* (3 - (3 \* sqrt(2) - 3.2) + 1.5\*0.3) → **~21.22**

Hint: Use the classical "shunting yard" algorithm and "reverse Polish notation".
