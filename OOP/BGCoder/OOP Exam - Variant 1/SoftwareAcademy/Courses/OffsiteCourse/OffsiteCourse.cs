using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public class OffsiteCourse : Course, IOffsiteCourse
    {
        // Property
        public string Town { get; set; }

        // Constructor
        public OffsiteCourse(string name, string town)
            : base(name)
        {
            this.Town = town;
        }
    }
}
