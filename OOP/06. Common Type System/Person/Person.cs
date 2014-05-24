using System;

namespace Person
{
    class Person
    {
        // Properties
        public string Name { get; private set; }
        public byte? Age { get; private set; }

        // Constructor
        public Person(string name, byte? age)
        {
            this.Name = name;
            this.Age = age;
        }

        // Override to string method
        public override string ToString()
        {
            return String.Format("{0,-20} {1}", this.Name, this.Age.ToString() ?? "not specified");
        }
    }
}