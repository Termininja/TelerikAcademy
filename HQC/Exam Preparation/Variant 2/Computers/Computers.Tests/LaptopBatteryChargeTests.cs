namespace Computers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LaptopBatteryChargeTests
    {
        [TestMethod]
        public void ChargeBatteryTest()
        {
            RAM laptopRAM = new RAM(4);
            var laptopVideoCard = new VideoCard(false);
            var laptopHardDrives = new[] { new HardDrive(500, false, 0) };
            var laptopBattery = new LaptopBattery();
            var laptopCPU = new CPU(2, CPUTypes._64bit, laptopRAM, laptopVideoCard);

            Computer laptop = new Computer(ComputerType.LAPTOP, laptopCPU, laptopRAM, laptopHardDrives, laptopVideoCard, laptopBattery);
            laptop.ChargeBattery(30);
        }

        [TestMethod]
        public void NegativeChargeBatteryTest()
        {
            RAM laptopRAM = new RAM(4);
            var laptopVideoCard = new VideoCard(false);
            var laptopHardDrives = new[] { new HardDrive(500, false, 0) };
            var laptopBattery = new LaptopBattery();
            var laptopCPU = new CPU(2, CPUTypes._64bit, laptopRAM, laptopVideoCard);

            Computer laptop = new Computer(ComputerType.LAPTOP, laptopCPU, laptopRAM, laptopHardDrives, laptopVideoCard, laptopBattery);
            laptop.ChargeBattery(-100);
        }

        [TestMethod]
        public void OverChargeBatteryTest()
        {
            RAM laptopRAM = new RAM(4);
            var laptopVideoCard = new VideoCard(false);
            var laptopHardDrives = new[] { new HardDrive(500, false, 0) };
            var laptopBattery = new LaptopBattery();
            var laptopCPU = new CPU(2, CPUTypes._64bit, laptopRAM, laptopVideoCard);

            Computer laptop = new Computer(ComputerType.LAPTOP, laptopCPU, laptopRAM, laptopHardDrives, laptopVideoCard, laptopBattery);
            laptop.ChargeBattery(300);
        }
    }
}
