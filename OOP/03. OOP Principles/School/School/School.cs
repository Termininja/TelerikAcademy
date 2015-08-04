namespace School
{
    using System.Collections.Generic;

    public class School
    {
        public School(string name, List<SchoolClass> classes)
        {
            this.Name = name;
            this.Classes = classes;
        }

        public string Name { get; private set; }

        public List<SchoolClass> Classes { get; private set; }

        public void AddClass(SchoolClass schoolClass)
        {
            this.Classes.Add(schoolClass);
        }

        public void RemoveClass(SchoolClass schoolClass)
        {
            this.Classes.Remove(schoolClass);
        }

        public override string ToString()
        {
            string result = string.Format("School Name: {0}\n{1}\n", this.Name, string.Join("\n", this.Classes));

            return result;
        }
    }
}