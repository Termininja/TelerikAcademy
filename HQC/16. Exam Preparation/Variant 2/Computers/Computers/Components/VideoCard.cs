namespace Computers
{
    using System;

    public class VideoCard
    {
        public VideoCard()
        {
        }

        public VideoCard(bool isMonochrome)
        {
            this.IsMonochrome = isMonochrome;
        }

        public bool IsMonochrome { get; set; }

        public void DrawInConsole(string text)
        {
            Console.ForegroundColor = this.IsMonochrome ? ConsoleColor.Gray : ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}