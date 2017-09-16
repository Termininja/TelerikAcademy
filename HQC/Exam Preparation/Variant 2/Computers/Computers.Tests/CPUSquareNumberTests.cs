namespace Computers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CPUSquareNumberTests
    {
        [TestMethod]
        public void CPUSquareNumber32bitTests()
        {
            RAM laptopRAM = new RAM(4);
            var laptopVideoCard = new VideoCard(false);
            var laptopCPU = new CPU(2, CPUTypes._32bit, laptopRAM, laptopVideoCard);

            laptopCPU.SquareNumber();
        }

        [TestMethod]
        public void CPUSquareNumber64bitTests()
        {
            RAM laptopRAM = new RAM(4);
            var laptopVideoCard = new VideoCard(false);
            var laptopCPU = new CPU(2, CPUTypes._64bit, laptopRAM, laptopVideoCard);

            laptopCPU.SquareNumber();
        }

        [TestMethod]
        public void CPUSquareNumber128bitTests()
        {
            RAM laptopRAM = new RAM(4);
            var laptopVideoCard = new VideoCard(false);
            var laptopCPU = new CPU(2, CPUTypes._128bit, laptopRAM, laptopVideoCard);

            laptopCPU.SquareNumber();
        }
    }
}
