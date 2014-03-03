using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class Teacher : ITeacher
    {
        // Fields
        private string name;
        private List<ICourse> courses;

        // Constructor
        public Teacher(string name)
        {
            this.Name = name;
            this.courses = new List<ICourse>();
        }

        // Properties
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value != null && value != "") name = value;
                else throw new ArgumentNullException("This is mandatory property!");
            }
        }

        // Adds some course for the teacher
        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        // Override to string method
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Teacher: Name={0}", this.Name);
            if (this.courses.Count > 0)
            {
                result.AppendFormat("; Courses=[{0}]", string.Join(", ", this.courses.Select(m => m.Name)));
            }
            return result.ToString();
        }
    }
}
