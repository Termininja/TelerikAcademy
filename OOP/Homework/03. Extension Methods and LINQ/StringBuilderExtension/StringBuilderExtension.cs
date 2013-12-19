using System;
using System.Text;

public static class StringBuilderExtension
{
    // Extension method
    public static StringBuilder Substring(this StringBuilder str, int index, int length)
    {
        StringBuilder result = new StringBuilder();
        result.Append(str.ToString(index, length));
        return result;
    }
}