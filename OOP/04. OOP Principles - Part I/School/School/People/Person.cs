namespace School
{
    class Person
    {
        #region Property
        public string Name { get; private set; }
        #endregion

        #region Constructor
        public Person(string name)
        {
            this.Name = name;
        }
        #endregion
    }
}