using System.Linq;
using System;
using System.Collections.Generic;

namespace School
{
    class Student
    {
        #region Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FN { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public List<int> Marks { get; set; }
        public Group Group { get; set; }
        #endregion

        #region Constructor
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
        #endregion

        #region Method
        public override string ToString()
        {
            string result = "Name: " + this.FirstName + " " + this.LastName;
            result += "\n" + "FN: " + this.FN;
            result += "\n" + "Tel: " + this.Tel;
            result += "\n" + "Email: " + this.Email;
            result += "\n" + "Marks: " + String.Join(" ", Marks);
            result += this.Group + "\n";

            return result;
        }
        #endregion
    }
}