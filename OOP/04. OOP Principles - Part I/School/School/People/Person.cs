namespace School
{
    using System.Collections.Generic;

    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
            this.Comments = new List<string>();
        }

        public string Name { get; private set; }

        public List<string> Comments { get; set; }

        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
        }
    }
}