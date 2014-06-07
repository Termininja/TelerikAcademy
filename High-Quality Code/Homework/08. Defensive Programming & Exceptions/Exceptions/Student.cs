namespace Exceptions
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Student
    {
        /// <summary>
        /// The first name of the student.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the student.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The list of all exams for this student.
        /// </summary>
        public IList<Exam> Exams { get; set; }

        /// <summary>
        /// Initializes a new instance of class Student.
        /// </summary>
        /// <param name="firstName">The first name of the student.</param>
        /// <param name="lastName">The second name of the student.</param>
        /// <param name="exams">The list of all exams for this student.</param>
        public Student(string firstName, string lastName, IList<Exam> exams = null)
        {
            if (firstName == null)
            {
                throw new ArgumentNullException("The first name cannot be null!");
            }

            if (lastName == null)
            {
                throw new ArgumentNullException("The last name cannot be null!");
            }

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        /// <summary>
        /// Checks all exam scores.
        /// </summary>
        /// <returns>Returns a new list of exams.</returns>
        public IList<ExamResult> CheckExams()
        {
            if (this.Exams == null)
            {
                throw new ArgumentNullException("The student has no exams!");
            }

            if (this.Exams.Count == 0)
            {
                throw new ArgumentOutOfRangeException("The student has no exams!");
            }

            IList<ExamResult> results = new List<ExamResult>();
            for (int i = 0; i < this.Exams.Count; i++)
            {
                results.Add(this.Exams[i].Check());
            }

            return results;
        }

        /// <summary>
        /// Calculates the average result from all exams.
        /// </summary>
        /// <returns>Returns the average result in percents.</returns>
        public double CalcAverageExamResultInPercents()
        {
            double[] examScore = new double[this.Exams.Count];
            IList<ExamResult> examResults = CheckExams();
            for (int i = 0; i < examResults.Count; i++)
            {
                examScore[i] =
                    ((double)examResults[i].Grade - examResults[i].MinGrade) /
                    (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            return examScore.Average();
        }
    }
}