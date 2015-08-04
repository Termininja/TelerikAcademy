namespace StringBuilderExtension
{
    using System.Text;

    public static class StringBuilderExtension
    {
        public static StringBuilder Substring(this StringBuilder str, int index, int length)
        {
            StringBuilder result = new StringBuilder();
            result.Append(str.ToString(index, length));

            return result;
        }
    }
}