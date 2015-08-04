namespace School
{
    using System.Collections.Generic;

    public class Teacher : Person, ICommentable
    {
        public Teacher(string name, List<Discipline> discipline)
            : base(name)
        {
            this.Disciplines = discipline;
        }

        public List<Discipline> Disciplines { get; set; }

        public void AddDiscipline(Discipline discipline)
        {
            this.Disciplines.Add(discipline);
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            this.Disciplines.Remove(discipline);
        }

        public override string ToString()
        {
            string result = string.Format("   Name: {0}", base.Name);
            foreach (var discipline in Disciplines)
            {
                result += string.Format("\n   Discipline: {0} (lectures: {1}, exercises: {2}){3}{4}",
                    discipline.Name, discipline.NumberOfLectures, discipline.NumberOfExercises,
                    discipline.Comments.Count > 0 ? " - " + string.Join("; ", discipline.Comments) : null,
                    base.Comments.Count > 0 ? "\n   Comments: " + string.Join("; ", base.Comments) : null);
            }

            return result;
        }
    }
}
