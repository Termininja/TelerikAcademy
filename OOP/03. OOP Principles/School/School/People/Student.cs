namespace School
{
    using System;

    public class Student : Person, ICommentable
    {
        private uint classNumber;

        public Student(string name, uint classNumber)
            : base(name)
        {
            this.ClassNumber = classNumber;
        }

        public uint ClassNumber
        {
            get
            {
                return this.classNumber;
            }
            private set
            {
                if (value.ToString().Length > 5 && value <= 0)
                {
                    throw new ArgumentException("The number is not correct!");
                }

                this.classNumber = value;
            }
        }

        public override string ToString()
        {
            string result = string.Format("{0} (number: {1}){2}", base.Name, this.ClassNumber,
                base.Comments.Count > 0 ? ": " + string.Join("; ", base.Comments) : null);

            return result;
        }
    }
}
