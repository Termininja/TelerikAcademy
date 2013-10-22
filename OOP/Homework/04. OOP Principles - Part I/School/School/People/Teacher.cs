using System;
using System.Collections.Generic;

namespace School
{
    class Teacher : Person, ICommentable
    {
        // Field
        private List<string> comments = new List<string>();

        // Properties
        public List<Discipline> Disciplines { get; set; }

        public List<string> Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        // Constructor
        public Teacher(string name, List<Discipline> discipline)
            : base(name)
        {
            this.Disciplines = discipline;
        }

        // Methods
        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }

        public void AddDiscipline(Discipline discipline)
        {
            Disciplines.Add(discipline);
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            Disciplines.Remove(discipline);
        }

        public override string ToString()
        {
            string result = "   Name: " + Name;
            foreach (Discipline discipline in Disciplines)
            {
                result +=
                    "\n   Discipline: " + discipline.Name +
                    " (lectures: " + discipline.NumberOfLectures +
                    ", exercises: " + discipline.NumberOfExercises + ")";

                for (int i = 0; i < discipline.Comments.Count; i++)
                {
                    if (i == 0) result += " - ";
                    result += discipline.Comments[i];
                    if (i != discipline.Comments.Count - 1) result += "; ";
                }
            }
            if (comments.Count > 0)
            {
                result += "\n   Comments: ";
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
