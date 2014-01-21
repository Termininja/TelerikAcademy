using System;
using System.Text;

class DecodeAndDecrypt
{
    static void Main()
    {
        string input = Console.ReadLine();
        int lengthOfCypher = 0;
        string word = String.Empty;
        for (int i = input.Length - 1; i >= 0; i--)
        {
            try
            {
                lengthOfCypher = int.Parse(input.Substring(i));
            }
            catch (Exception)
            {
                word = input.Substring(0, i + 1);
                break;
            }
        }
        string decodedMessage = Decode(word);
        string encryptedMessage = decodedMessage.Remove(decodedMessage.Length - lengthOfCypher);
        string cypher = decodedMessage.Substring(decodedMessage.Length - lengthOfCypher);
        Console.WriteLine(Decrypt(encryptedMessage, cypher));
    }

    private static string Decode(string word)
    {
        string result = String.Empty;
        string tempNum = String.Empty;
        bool findedNumber = false;
        for (int i = 0; i < word.Length; i++)
        {
            if (char.IsDigit(word[i]))
            {
                findedNumber = true;
                tempNum += word[i].ToString();
            }
            else
            {
                if (findedNumber)
                {
                    result += new string(word[i], int.Parse(tempNum));
                    tempNum = String.Empty;
                    findedNumber = false;
                }
                else result += word[i];
            }
        }
        return result;
    }

    private static StringBuilder Decrypt(string m, string c)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < m.Length; i++)
        {
            int decrypt = (m[i] - 65);
            int curr = i;
            curr %= c.Length;
            while (curr < c.Length)
            {
                decrypt ^= (c[curr] - 65);
                curr += m.Length;
            }
            result.Append((char)(decrypt + 65));
        }
        return result;
    }
}