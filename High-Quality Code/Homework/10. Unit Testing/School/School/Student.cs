namespace School
{
    using System;

    public class Student
    {
        private string name;
        private int id;

        /// <summary>
        /// Initializes a new instance of class Student
        /// </summary>
        /// <param name="name">The name of the student.</param>
        /// <param name="id">The student unique number.</param>
        public Student(string name, int id)
        {
            this.Name = name;
            this.ID = id;
        }

        /// <summary>
        /// The name of the student.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentNullException("The student name cannot be null!");
                }
            }
        }

        /// <summary>
        /// The student unique number.
        /// </summary>
        public int ID
        {
            get { return this.id; }
            set
            {
                if (10000 <= value && value <= 99999)
                {
                    this.id = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The ID has to be from 10000 to 99999!");
                }
            }
        }

        /// <summary>
        /// Takes all information about the student.
        /// </summary>
        /// <returns>Returns the name and the ID of the students like string.</returns>
        public override string ToString()
        {
            string result = "Name: " + this.Name + ", ID: " + this.ID;

            return result;
        }
    }
}
