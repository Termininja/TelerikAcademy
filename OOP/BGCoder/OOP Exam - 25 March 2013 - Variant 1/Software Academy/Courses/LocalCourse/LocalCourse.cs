using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public class LocalCourse : Course, ILocalCourse
    {
        // Property
        public string Lab { get; set; }

        // Constructor
        public LocalCourse(string name, string lab)
            : base(name)
        {
            this.Lab = lab;
        }
    }
}
