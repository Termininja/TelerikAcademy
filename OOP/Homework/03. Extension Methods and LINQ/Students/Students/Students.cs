using System;
using System.Linq;
using System.Collections.Generic;

namespace Students
{
    class Students
    {
        // Constructor
        public Students(string first, string last, byte age)
        {
            this.First = first;
            this.Last = last;
            this.Age = age;
        }

        // Properties
        public string First { get; set; }
        public string Last { get; set; }
        public int Age { get; set; }

        // Method that finds all students whose first name is before its last name alphabetically
        public static List<Students> FilterByName(Students[] list)
        {
            List<Students> result = new List<Students>();
            var filtered = from n in list where n.First[0] < n.Last[0] select n;
            foreach (var item in filtered) result.Add(item);
            return result;
        }

        // Method that finds the names of all students with age between 18 and 24
        public static List<Students> FilterByAge(Students[] list)
        {
            List<Students> result = new List<Students>();
            var filtered = from n in list where n.Age >= 18 && n.Age <= 24 select n;
            foreach (var item in filtered) result.Add(item);
            return result;
        }

        // Method that adds all students in an list
        public static List<Students> AllStudents(Students[] list)
        {
            List<Students> result = new List<Students>();
            foreach (var item in list) result.Add(item);
            return result;
        }

        // String output for this class
        public override string ToString()
        {
            return "  " + this.First + " " + this.Last + " (" + this.Age + ")";
        }
    }
}