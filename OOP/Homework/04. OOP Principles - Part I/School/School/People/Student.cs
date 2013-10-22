using System;
using System.Collections.Generic;

namespace School
{
    class Student : Person, ICommentable
    {
        // Field
        private List<string> comments = new List<string>();

        // Properties
        public uint ClassNumber { get; private set; }

        public List<string> Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        // Constructor
        public Student(string name, uint classNumber)
            : base(name)
        {
            if (classNumber.ToString().Length <= 5 && classNumber > 0)
            {
                this.ClassNumber = classNumber;
            }
            else
            {
                throw new ArgumentException("The number is not correct!");
            }
        }

        // Methods
        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }

        public override string ToString()
        {
            string result = Name + " (number: " + ClassNumber + ")";
            if (comments.Count > 0)
            {
                result += ": ";
                for (int i = 0; i < comments.Count; i++)
                {
                    result += comments[i];
                    if (i != comments.Count - 1) result += "; ";
                }
            }
            return result;
        }
    }
}
