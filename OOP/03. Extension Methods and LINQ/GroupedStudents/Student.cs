using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupedStudents
{
    class Student
    {
        // Properties
        public string Name { get; set; }
        public string GroupName { get; set; }

        // Constructor
        public Student(string name, string groupName)
        {
            this.Name = name;
            this.GroupName = groupName;
        }

        // Method
        public override string ToString()
        {
            return "Name: " + this.Name + " (" + this.GroupName + ")";
        }
    }
}
