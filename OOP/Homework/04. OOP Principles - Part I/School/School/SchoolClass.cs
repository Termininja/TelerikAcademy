using System;
using System.Collections.Generic;

namespace School
{
    class SchoolClass : ICommentable
    {
        // Field
        private List<string> comments = new List<string>();

        // Properties
        public string TextID { get; private set; }
        public List<Student> Students { get; private set; }
        public List<Teacher> Teachers { get; private set; }

        public List<string> Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        // Constructor
        public SchoolClass(string textID, List<Student> students, List<Teacher> teachers)
        {
            this.TextID = textID;
            this.Students = students;
            this.Teachers = teachers;
        }

        // Methods
        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            Teachers.Remove(teacher);
        }

        public override string ToString()
        {
            string result = "Class: " + TextID;

            if (comments.Count > 0)
            {
                for (int i = 0; i < comments.Count; i++)
                {
                    if (i == 0) result += ": ";
                    result += comments[i];
                    if (i != comments.Count - 1) result += "; ";
                }
            }
            if (Teachers.Count > 0)
            {
                result += "\n\nTeachers:";
                foreach (Teacher teacher in Teachers) result += "\n" + teacher + "\n";
            }
            if (Students.Count > 0)
            {
                result += "\nStudents:\n";
                foreach (Student student in Students) result += "   " + student + "\n";
            }
            return result;
        }
    }
}
