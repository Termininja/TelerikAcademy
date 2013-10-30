namespace Bank
{
    class Customer
    {
        // Property
        public string Name { get; set; }

        // Constructor
        public Customer(string name)
        {
            this.Name = name;
        }

        // Override to string method
        public override string ToString()
        {
            return this.Name;
        }
    }
}