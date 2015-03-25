namespace IntegerNumbers
{
    using System.Linq;
    using System.Collections.Generic;

    public class IntegerNumbers
    {
        public IntegerNumbers(int n)
        {
            this.N = n;
        }

        public int N { get; set; }

        // By using Lambda expressions
        public static List<IntegerNumbers> DivisibleBy21usingLambda(IntegerNumbers[] arr)
        {
            var result = new List<IntegerNumbers>();
            foreach (var item in arr.Where(m => m.N % 21 == 0)) result.Add(item);

            return result;
        }

        // By using LINQ
        public static List<IntegerNumbers> DivisibleBy21usingLINQ(IntegerNumbers[] arr)
        {
            var result = new List<IntegerNumbers>();
            foreach (var item in from m in arr where m.N % 21 == 0 select m) result.Add(item);

            return result;
        }
    }
}