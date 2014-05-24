//Task7: Write a program that encodes and decodes a string using given encryption key (cipher).
//       The key consists of a sequence of characters. The encoding/decoding is done by performing
//       XOR (exclusive or) operation over the first letter of the string with the first of the key,
//       the second – with the second, etc. When the last key character is reached, the next is the first.

using System;

class EncryptionKey
{
    static void Main()
    {
        // Reads some text
        Console.Write("Please, enter some text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = Console.ReadLine();
        Console.ResetColor();

        // Reads some encryption key
        Console.Write("Please, enter some encryption key: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string key = Console.ReadLine();
        Console.ResetColor();

        // Encode the text
        string encoded = Encryption(text, key);

        // The result from encoding
        Console.WriteLine("\nEncoded text is:");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(encoded);
        Console.ResetColor();

        // The result from decoding
        Console.WriteLine("\nDecoded text is:");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(Encryption(encoded, key));
        Console.ResetColor();
    }

    // Encodes some text by a given key
    static string Encryption(string text, string key)
    {
        string result = "";
        for (int i = 0; i < text.Length; i++)
        {
            // XOR for each one letter
            result += (char)(text[i] ^ key[i % key.Length]);
        }

        // Returns the encoded text
        return result;
    }
}