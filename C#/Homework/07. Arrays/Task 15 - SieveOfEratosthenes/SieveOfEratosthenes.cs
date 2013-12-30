// Task 15. Write a program that finds all prime numbers in the range [1...10 000 000].
//          Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

using System;

class SieveOfEratosthenes
{
    static void Main()
    {
        bool[] prime = new bool[(int)10E6 + 1];     // creates empty boolean array
        byte[] n = { 2, 3, 5, 7 };                  // all one-digit prime numbers
        for (int i = 2; i < prime.Length; i++)      // makes all numbers prime
        {
            prime[i] = true;
        }

        for (int i = 2; i < prime.Length; i++)      // for all elements in array
        {
            for (int j = 0; j < n.Length; j++)      // for all one-digit prime number
            {
                if (i % n[j] == 0 && i > n[j])      // finds wich number is not a prime
                {
                    prime[i] = false;
                }
            }
        }

        // Prints the prime numbers
        for (int j = 0; j < prime.Length; j++)
        {
            if (prime[j]) Console.WriteLine(j);
        }
    }
}