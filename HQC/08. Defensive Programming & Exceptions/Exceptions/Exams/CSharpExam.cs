namespace Exceptions
{
    using System;

    public class CSharpExam : Exam
    {
        public int Score { get; private set; }

        /// <summary>
        /// Initializes a new instance of class CSharpExam.
        /// </summary>
        /// <param name="score">The scores for CSharp exam.</param>
        public CSharpExam(int score)
        {
            if (score < 0)
            {
                throw new ArgumentOutOfRangeException("The score cannot be negative!");
            }

            this.Score = score;
        }

        /// <summary>
        /// Check scores for this exam.
        /// </summary>
        /// <returns>Returns exam results calculated by score.</returns>
        public override ExamResult Check()
        {
            if (Score < 0 || Score > 100)
            {
                throw new ArgumentOutOfRangeException("The score has to be from 0 to 100!");
            }
            else
            {
                return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
            }
        }
    }
}