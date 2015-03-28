namespace Person
{
    using System;

    public class Person
    {
        public Person(string name, byte? age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public byte? Age { get; private set; }

        public override string ToString()
        {
            var result = String.Format("{0,-16} {1}", this.Name, this.Age == null ? "not specified" : this.Age.ToString());

            return result;
        }
    }
}