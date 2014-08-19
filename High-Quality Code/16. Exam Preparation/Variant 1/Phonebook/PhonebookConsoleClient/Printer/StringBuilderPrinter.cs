using System.Text;

namespace Phonebook
{

    class StringBuilderPrinter : IPrinter
    {
        private static StringBuilder output = new StringBuilder();

        public void Print(string text)
        {
            output.AppendLine(text);
        }

        public string GetAllText()
        {
            return output.ToString();
        }
    }
}
