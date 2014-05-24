// Task 05. Define a class BitArray64 to hold 64 bit values inside an ulong value.
//          Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.

using System;

namespace BitArray
{
    class Program
    {
        static void Main()
        {
            // Create two BitArray64s
            ulong number = 12345678901234567890;
            BitArray64 array1 = new BitArray64(number);
            BitArray64 array2 = new BitArray64(number / 2);

            // Print the arrays
            PrintArray(array1, "array1: ");
            PrintArray(array2, "array2: ");

            // Compare the both arrays
            Console.WriteLine("\n{0,-24} →  {1}", "array1.Equals(array2)", array1.Equals(array2));
            Console.WriteLine("{0,-24} →  {1}\n", "array1 != array2", array1 != array2);

            // Test ToString() method
            Console.WriteLine(array1);

            // Test the indexer
            Console.WriteLine("array1[7] = {0}", array1[7]);
        }

        // Print some array with foreach
        private static void PrintArray(BitArray64 array1, string text)
        {
            Console.Write(text);
            foreach (var bit in array1) Console.Write(bit);
            Console.WriteLine();
        }
    }
}