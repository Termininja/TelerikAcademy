//Task 02. Add exception handling (where missing) and refactor all incorrect error
//handling in the code from the project to follow the best practices for using exceptions.

namespace Exceptions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Demonstration of class Exceptions
    /// </summary>
    class Demo
    {
        static void Main()
        {
            var subStr = Exceptions.Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(subStr);

            var subArr = Exceptions.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(String.Join(" ", subArr));

            var allArr = Exceptions.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(String.Join(" ", allArr));

            var emptyArr = Exceptions.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(String.Join(" ", emptyArr));

            try
            {
                Console.WriteLine(Exceptions.ExtractEnding("I love C#", 2));
                Console.WriteLine(Exceptions.ExtractEnding("Nakov", 4));
                Console.WriteLine(Exceptions.ExtractEnding("beer", 4));
                Console.WriteLine(Exceptions.ExtractEnding("Hi", 100));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("23 is" + ((Exceptions.IsPrime(23)) ? "" : " not") + " prime.");
            Console.WriteLine("33 is" + ((Exceptions.IsPrime(33)) ? "" : " not") + " prime.");

            List<Exam> peterExams = new List<Exam>() {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}
