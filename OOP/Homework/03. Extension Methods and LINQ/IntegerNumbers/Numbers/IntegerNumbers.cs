using System;
using System.Linq;
using System.Collections.Generic;

namespace IntegerNumbers
{
    class IntegerNumbers
    {
        // Constructor
        public IntegerNumbers(int n) { this.N = n; }

        // Property
        public int N { get; set; }

        // Methods that take only the numbers that are divisible by 7 and 3
        public static List<IntegerNumbers> DivisibleBy21usingLambda(IntegerNumbers[] arr)
        {
            List<IntegerNumbers> result = new List<IntegerNumbers>();
            foreach (var item in arr.Where(m => m.N % 21 == 0)) result.Add(item);                   // by using lambda expressions
            return result;
        }

        public static List<IntegerNumbers> DivisibleBy21usingLINQ(IntegerNumbers[] arr)
        {
            List<IntegerNumbers> result = new List<IntegerNumbers>();
            foreach (var item in from m in arr where m.N % 21 == 0 select m) result.Add(item);      // by using LINQ
            return result;
        }
    }
}