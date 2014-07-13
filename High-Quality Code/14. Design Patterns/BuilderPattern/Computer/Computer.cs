using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class Computer
    {
        private ComputerType computerType;

        public string MotherBoard { get; set; }
        public string Processor { get; set; }
        public string HardDisk { get; set; }
        public string Screen { get; set; }

        public Computer(ComputerType type)
        {
            computerType = type;
        }

        public void DisplayConfiguration()
        {
            string message;

            message = string.Format("Computer: {0}", computerType);
            Console.WriteLine(message);

            message = string.Format("Motherboard: {0}", MotherBoard);
            Console.WriteLine(message);

            message = string.Format("Processor: {0}", Processor);
            Console.WriteLine(message);

            message = string.Format("Harddisk: {0}", HardDisk);
            Console.WriteLine(message);

            message = string.Format("Screen: {0}", Screen);
            Console.WriteLine(message);

            Console.WriteLine();
        }
    }
}
