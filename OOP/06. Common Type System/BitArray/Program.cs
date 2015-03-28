/*
 * Problem 5. 64 Bit array:
 *      Define a class BitArray64 to hold 64 bit values inside an ulong value.
 *      Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.      
 */

namespace BitArray
{
    using System;

    public class Program
    {
        private const ulong number = 12345678901234567890;

        public static void Main()
        {
            // Creates two BitArray64s
            var array1 = new BitArray64(number);
            var array2 = new BitArray64(number / 2);

            // Prints the arrays
            Console.WriteLine("array1: {0}", string.Join(null, array1));
            Console.WriteLine("array2: {0}", string.Join(null, array2));

            // Compares the both arrays
            Console.WriteLine("\n{0,-24} →  {1}", "array1.Equals(array2)", array1.Equals(array2));
            Console.WriteLine("{0,-24} →  {1}\n", "array1 != array2", array1 != array2);

            // Tests ToString() method
            Console.WriteLine(array1);

            // Tests the indexer
            Console.WriteLine("array1[7] = {0}", array1[7]);
        }
    }
}