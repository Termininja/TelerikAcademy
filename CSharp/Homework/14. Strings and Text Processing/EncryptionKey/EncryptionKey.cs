//Task8: Write a program that encodes and decodes a string using given encryption key (cipher).
//       The key consists of a sequence of characters. The encoding/decoding is done by performing
//       XOR (exclusive or) operation over the first letter of the string with the first of the key,
//       the second – with the second, etc. When the last key character is reached, the next is the first.

using System;

class EncryptionKey
{
    static void Main()
    {
        Console.Write("Please, enter some text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine();                       // reads some text
        Console.ResetColor();
        Console.Write("Please, enter some encryption key: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string key = Console.ReadLine();                        // reads some encryption key
        Console.ResetColor();


        string encoded = Encryption(text, key);                 // encode the text
        Console.WriteLine("\nEncoded text is:");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(encoded);                             // the result from encoding
        Console.ResetColor();

        Console.WriteLine("\nDecoded text is:");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(Encryption(encoded, key));            // the result from decoding
        Console.ResetColor();
    }

    static string Encryption(string text, string key)           // encodes some text by given key
    {
        string result = "";
        for (int i = 0; i < text.Length; i++)                
        {
            result += (char)(text[i] ^ key[i % key.Length]);    // XOR for each one letter
        }
        return result;                                          // returns the encoded text
    }
}