namespace School
{
    using System;
    using System.Collections.Generic;

    public class Discipline : ICommentable
    {
        private string name;
        private uint numberOfLectures;
        private uint numberOfExercises;

        public Discipline(string name, uint numberOfLectures, uint numberOfExercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
            this.Comments = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("The name has to be from minimum 2 symbols!");
                }

                this.name = value;
            }
        }

        public uint NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }
            private set
            {
                if (value < 0 || value > 5000)
                {
                    throw new ArgumentOutOfRangeException("The number has to be positive and less than 5000!");
                }

                this.numberOfLectures = value;
            }
        }

        public uint NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }
            private set
            {
                if (value < 0 || value > 5000)
                {
                    throw new ArgumentOutOfRangeException("The number has to be positive and less than 5000!");
                }

                this.numberOfExercises = value;
            }
        }

        public List<string> Comments { get; set; }

        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
