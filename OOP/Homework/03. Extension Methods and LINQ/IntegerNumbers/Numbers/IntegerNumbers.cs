using System;
using System.Linq;
using System.Collections.Generic;

namespace IntegerNumbers
{
    class IntegerNumbers
    {
        #region Constructor
        public IntegerNumbers(int n) { this.N = n; }
        #endregion

        #region Property
        public int N { get; set; }
        #endregion

        #region Takes only the numbers that are divisible by 7 and 3
        // By using lambda expressions
        public static List<IntegerNumbers> DivisibleBy21usingLambda(IntegerNumbers[] arr)
        {
            List<IntegerNumbers> result = new List<IntegerNumbers>();
            foreach (var item in arr.Where(m => m.N % 21 == 0)) result.Add(item);
            return result;
        }

        // By using LINQ
        public static List<IntegerNumbers> DivisibleBy21usingLINQ(IntegerNumbers[] arr)
        {
            List<IntegerNumbers> result = new List<IntegerNumbers>();
            foreach (var item in from m in arr where m.N % 21 == 0 select m) result.Add(item);
            return result;
        }
        #endregion
    }
}