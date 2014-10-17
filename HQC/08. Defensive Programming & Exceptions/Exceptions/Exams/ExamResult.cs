namespace Exceptions
{
    using System;

    public class ExamResult
    {
        /// <summary>
        /// The exam grade.
        /// </summary>
        public int Grade { get; private set; }

        /// <summary>
        /// The minimal exam grade.
        /// </summary>
        public int MinGrade { get; private set; }

        /// <summary>
        /// The maximal exam grade.
        /// </summary>
        public int MaxGrade { get; private set; }

        /// <summary>
        /// The comments about the exam.
        /// </summary>
        public string Comments { get; private set; }

        /// <summary>
        /// The result for some exam.
        /// </summary>
        /// <param name="grade">The exam grade.</param>
        /// <param name="minGrade">The minimal grade.</param>
        /// <param name="maxGrade">The maximal grade.</param>
        /// <param name="comments">The comments about the exam.</param>
        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            if (grade < 0)
            {
                throw new ArgumentOutOfRangeException("The grade cannot be negative!");
            }
            if (minGrade < 0)
            {
                throw new ArgumentOutOfRangeException("The minimum grade cannot be negative!");
            }
            if (maxGrade <= minGrade)
            {
                throw new ArgumentException("The maximum grade cannot be less than the minimum grade!");
            }
            if (comments == null || comments == "")
            {
                throw new ArgumentNullException("The comments cannot be null!");
            }

            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }
    }
}