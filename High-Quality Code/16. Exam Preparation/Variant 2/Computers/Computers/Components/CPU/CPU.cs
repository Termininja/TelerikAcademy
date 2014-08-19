namespace Computers
{
    using System;

    public class CPU
    {
        private const int MaxValueForSquareNumber32bit = 500;
        private const int MaxValueForSquareNumber64bit = 1000;
        private const int MaxValueForSquareNumber128bit = 2000;
        private static readonly Random RandomGenerator = new Random();
        private readonly CPUTypes numberOfBits;
        private readonly RAM ram;
        private readonly VideoCard videoCard;

        public CPU(byte numberOfCores, CPUTypes numberOfBits, RAM ram, VideoCard videoCard)
        {
            this.NumberOfCores = numberOfCores;
            this.numberOfBits = numberOfBits;
            this.ram = ram;
            this.videoCard = videoCard;
        }

        public byte NumberOfCores { get; set; }

        public void SquareNumber()
        {
            switch (this.numberOfBits)
            {
                case CPUTypes._32bit:
                    this.SquareNumber(MaxValueForSquareNumber32bit);
                    break;
                case CPUTypes._64bit:
                    this.SquareNumber(MaxValueForSquareNumber64bit);
                    break;
                case CPUTypes._128bit:
                    this.SquareNumber(MaxValueForSquareNumber128bit);
                    break;
                default: break;
            }
        }

        internal void SaveRandomNumberToRam(int startNumber, int endNumber)
        {
            int randomNumber = startNumber + RandomGenerator.Next(0, endNumber - startNumber + 1);

            this.ram.SaveValue(randomNumber);
        }

        private void SquareNumber(int maxValue)
        {
            var data = this.ram.LoadValue();
            if (data < 0)
            {
                this.videoCard.DrawInConsole("Number too low.");
            }
            else if (data > maxValue)
            {
                this.videoCard.DrawInConsole("Number too high.");
            }
            else
            {
                int value = 0;
                for (int i = 0; i < data; i++)
                {
                    value += data;
                }

                this.videoCard.DrawInConsole(string.Format("Square of {0} is {1}.", data, value));
            }
        }
    }
}
