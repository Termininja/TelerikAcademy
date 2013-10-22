using System;
using System.Collections.Generic;

namespace School
{
    class Discipline : ICommentable
    {
        // Field
        private List<string> comments = new List<string>();

        // Properties
        public string Name { get; private set; }
        public uint NumberOfLectures { get; private set; }
        public uint NumberOfExercises { get; private set; }

        public List<string> Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        // Constructor
        public Discipline(string name, uint numberOfLectures, uint numberOfExercises)
        {
            if (name.Length >= 2) this.Name = name;
            else throw new ArgumentException("The name has to be minimum 2 symbols!");

            if (numberOfLectures < 0 || numberOfLectures > 5000)
            {
                throw new ArgumentOutOfRangeException("The number has to be positive and less than 5000!");
            }
            else this.NumberOfLectures = numberOfLectures;

            if (numberOfExercises < 0 || numberOfExercises > 5000)
            {
                throw new ArgumentOutOfRangeException("The number has to be positive and less than 5000!");
            }
            else this.NumberOfExercises = numberOfExercises;
        }

        // Methods
        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
