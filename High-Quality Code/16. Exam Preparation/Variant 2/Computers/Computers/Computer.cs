namespace Computers
{
    using System.Collections.Generic;

    public class Computer
    {
        private const int MinPlayNumber = 1;
        private const int MaxPlayNumber = 10;
        private readonly LaptopBattery battery;

        public Computer(ComputerType type, CPU cpu, RAM ram, IEnumerable<HardDrive> hardDrives, VideoCard videoCard, LaptopBattery battery)
        {
            this.CPU = cpu;
            this.RAM = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
            if (type != ComputerType.LAPTOP && type != ComputerType.PC)
            {
                this.VideoCard.IsMonochrome = true;
            }

            this.battery = battery;
        }

        public CPU CPU { get; set; }

        public RAM RAM { get; set; }

        public IEnumerable<HardDrive> HardDrives { get; set; }

        public VideoCard VideoCard { get; set; }

        public void Play(int guessNumber)
        {
            this.CPU.SaveRandomNumberToRam(MinPlayNumber, MaxPlayNumber);
            var cpuNumber = RAM.LoadValue();
            if (cpuNumber != guessNumber)
            {
                this.VideoCard.DrawInConsole(string.Format("You didn't guess the number {0}.", cpuNumber));
            }
            else
            {
                this.VideoCard.DrawInConsole("You win!");
            }
        }

        public void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);

            this.VideoCard.DrawInConsole(string.Format("Battery status: {0}%", this.battery.Percentage));
        }

        internal void Process(int data)
        {
            RAM.SaveValue(data);
            CPU.SquareNumber();
        }
    }
}
