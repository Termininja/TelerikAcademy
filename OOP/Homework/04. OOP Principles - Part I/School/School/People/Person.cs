namespace School
{
    class Person
    {
        // Property
        public string Name { get; private set; }

        // Constructor
        public Person(string name)
        {
            this.Name = name;
        }
    }
}