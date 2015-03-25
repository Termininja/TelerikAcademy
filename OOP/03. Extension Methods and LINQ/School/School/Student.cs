namespace School
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        public Student(string firstName, string lastName, int fn, string tel, string email, List<int> marks, Group group)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FN = fn;
            this.Tel = tel;
            this.Email = email;
            this.Marks = marks;
            this.Group = group;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int FN { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        public List<int> Marks { get; set; }

        public Group Group { get; set; }

        public override string ToString()
        {
            string result = string.Format("Name: {0} {1}\nFN: {2}\nTel: {3}\nEmail: {4}\nMarks: {5} {6}\n",
                this.FirstName, this.LastName, this.FN, this.Tel, this.Email, String.Join(" ", Marks), this.Group);

            return result;
        }
    }
}