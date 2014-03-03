using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareAcademy
{
    public abstract class Course : ICourse
    {
        // Fields
        private string name;
        private List<string> topics;

        // Constructor
        protected Course(string name)
        {
            this.Name = name;
            this.topics = new List<string>();
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
        public ITeacher Teacher { get; set; }

        // Adds some topic for the course
        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        // Override to string method
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0}: Name={1}", this.GetType().Name, this.Name);
            if (this.Teacher != null) result.AppendFormat("; Teacher={0}", Teacher.Name);
            if (this.topics.Count > 0)
            {
                result.AppendFormat("; Topics=[{0}]", string.Join(", ", this.topics));
            }
            if (this.GetType().Name == "LocalCourse") result.AppendFormat("; Lab={0}", (this as LocalCourse).Lab);
            if (this.GetType().Name == "OffsiteCourse") result.AppendFormat("; Town={0}", (this as OffsiteCourse).Town);
            return result.ToString();
        }
    }
}
