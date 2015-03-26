namespace School
{
    using System.Collections.Generic;

    public class SchoolClass : ICommentable
    {
        public SchoolClass(string name, List<Student> students, List<Teacher> teachers)
        {
            this.Name = name;
            this.Students = students;
            this.Teachers = teachers;
            this.Comments = new List<string>();
        }

        public string Name { get; private set; }

        public List<Student> Students { get; private set; }

        public List<Teacher> Teachers { get; private set; }

        public List<string> Comments { get; set; }

        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
        }

        public void AddStudent(Student student)
        {
            this.Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            this.Students.Remove(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            this.Teachers.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            this.Teachers.Remove(teacher);
        }

        public override string ToString()
        {
            string result = string.Format("Class: {0}{1}{2}{3}", this.Name,
                this.Comments.Count > 0 ? ": " + string.Join("; ", this.Comments) : null,
                this.Teachers.Count > 0 ? "\n\nTeachers:\n" + string.Join("\n\n", this.Teachers) : null,
                this.Students.Count > 0 ? "\n\nStudents:\n   " + string.Join("\n   ", this.Students) : null);

            return result;
        }
    }
}
