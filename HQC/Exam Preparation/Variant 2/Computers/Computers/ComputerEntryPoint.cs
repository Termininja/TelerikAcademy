namespace Computers
{
    using System;
    using System.Collections.Generic;

    public class ComputerEntryPoint
    {
        private static Computer personalComputer, laptop, server;

        public static void Main()
        {
            var manufacturer = Console.ReadLine();
            if (manufacturer == "HP")
            {
                var personalComputerRAM = new RAM(2);
                var personalComputerVideoCard = new VideoCard(false);
                var personalComputerHardDrives = new[] { new HardDrive(500, false, 0) };
                var personalComputerCPU = new CPU(2, CPUTypes._32bit, personalComputerRAM, personalComputerVideoCard);

                personalComputer = new Computer(ComputerType.PC, personalComputerCPU, personalComputerRAM, personalComputerHardDrives, personalComputerVideoCard, null);

                var serverRAM = new RAM(32);
                var serverVideoCard = new VideoCard();
                var serverHardDrives = new List<HardDrive> { new HardDrive(0, true, 2, new List<HardDrive> { new HardDrive(1000, false, 0), new HardDrive(1000, false, 0) }) };
                var serverCPU = new CPU(4, CPUTypes._32bit, serverRAM, serverVideoCard);

                server = new Computer(ComputerType.SERVER, serverCPU, serverRAM, serverHardDrives, serverVideoCard, null);

                var laptopRAM = new RAM(4);
                var laptopVideoCard = new VideoCard(false);
                var laptopHardDrives = new[] { new HardDrive(500, false, 0) };
                var laptopBattery = new LaptopBattery();
                var laptopCPU = new CPU(2, CPUTypes._64bit, laptopRAM, laptopVideoCard);

                laptop = new Computer(ComputerType.LAPTOP, laptopCPU, laptopRAM, laptopHardDrives, laptopVideoCard, laptopBattery);
            }
            else if (manufacturer == "Dell")
            {
                var personalComputerRAM = new RAM(8);
                var personalComputerVideoCard = new VideoCard(false);
                var personalComputerHardDrives = new[] { new HardDrive(1000, false, 0) };
                var personalComputerCPU = new CPU(4, CPUTypes._64bit, personalComputerRAM, personalComputerVideoCard);

                personalComputer = new Computer(ComputerType.PC, personalComputerCPU, personalComputerRAM, personalComputerHardDrives, personalComputerVideoCard, null);

                var serverRAM = new RAM(64);
                var serverVideoCard = new VideoCard();
                var serverHardDrives = new List<HardDrive> { new HardDrive(0, true, 2, new List<HardDrive> { new HardDrive(2000, false, 0), new HardDrive(2000, false, 0) }) };
                var serverCPU = new CPU(8, CPUTypes._64bit, serverRAM, serverVideoCard);

                server = new Computer(ComputerType.SERVER, serverCPU, serverRAM, serverHardDrives, serverVideoCard, null);

                var laptopRAM = new RAM(8);
                var laptopVideoCard = new VideoCard(false);
                var laptopHardDrives = new[] { new HardDrive(1000, false, 0) };
                var laptopBattery = new LaptopBattery();
                var laptopCPU = new CPU(4, CPUTypes._32bit, laptopRAM, laptopVideoCard);

                laptop = new Computer(ComputerType.LAPTOP, laptopCPU, laptopRAM, laptopHardDrives, laptopVideoCard, laptopBattery);
            }
            else if (manufacturer == "Lenovo")
            {
                var personalComputerRAM = new RAM(4);
                var personalComputerVideoCard = new VideoCard(true);
                var personalComputerHardDrives = new[] { new HardDrive(2000, false, 0) };
                var personalComputerCPU = new CPU(2, CPUTypes._64bit, personalComputerRAM, personalComputerVideoCard);

                personalComputer = new Computer(ComputerType.PC, personalComputerCPU, personalComputerRAM, personalComputerHardDrives, personalComputerVideoCard, null);

                var serverRAM = new RAM(8);
                var serverVideoCard = new VideoCard();
                var serverHardDrives = new List<HardDrive> { new HardDrive(0, true, 2, new List<HardDrive> { new HardDrive(500, false, 0), new HardDrive(500, false, 0) }) };
                var serverCPU = new CPU(2, CPUTypes._128bit, serverRAM, serverVideoCard);

                server = new Computer(ComputerType.SERVER, serverCPU, serverRAM, serverHardDrives, serverVideoCard, null);

                var laptopRAM = new RAM(16);
                var laptopVideoCard = new VideoCard(false);
                var laptopHardDrives = new[] { new HardDrive(1000, false, 0) };
                var laptopBattery = new LaptopBattery();
                var laptopCPU = new CPU(2, CPUTypes._64bit, laptopRAM, laptopVideoCard);

                laptop = new Computer(ComputerType.LAPTOP, laptopCPU, laptopRAM, laptopHardDrives, laptopVideoCard, laptopBattery);
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }

            var command = Console.ReadLine();

            while (command != null && command != "Exit")
            {
                var commandArguments = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandArguments.Length != 2)
                {
                    throw new ArgumentException("Invalid command!");
                }

                var commandName = commandArguments[0];
                var commandParameter = int.Parse(commandArguments[1]);
                if (commandName == "Charge")
                {
                    laptop.ChargeBattery(commandParameter);
                }
                else if (commandName == "Process")
                {
                    server.Process(commandParameter);
                }
                else if (commandName == "Play")
                {
                    personalComputer.Play(commandParameter);
                }

                command = Console.ReadLine();
            }
        }
    }
}
