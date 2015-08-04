namespace GroupedStudents
{
    public class Student
    {
        public Student(string name, string groupName)
        {
            this.Name = name;
            this.GroupName = groupName;
        }

        public string Name { get; set; }

        public string GroupName { get; set; }

        public override string ToString()
        {
            var result = string.Format("  Name: {0} ({1})", this.Name, this.GroupName);

            return result;
        }
    }
}
