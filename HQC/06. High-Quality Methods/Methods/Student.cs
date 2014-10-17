namespace Methods
{
    using System;

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string OtherInfo { get; set; }

        /// <summary>
        /// Checks if the current student is older than some other student.
        /// </summary>
        /// <param name="other">The other student.</param>
        /// <returns>Returns true or false.</returns>
        public bool IsOlderThan(Student other)
        {
            return this.BirthDate > other.BirthDate;
        }
    }
}
