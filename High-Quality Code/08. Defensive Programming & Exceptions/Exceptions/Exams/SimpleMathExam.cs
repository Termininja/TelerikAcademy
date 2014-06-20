namespace Exceptions
{
    using System;

    public class SimpleMathExam : Exam
    {
        /// <summary>
        /// The number of the solved problems.
        /// </summary>
        public int ProblemsSolved { get; private set; }

        /// <summary>
        /// Initializes a new instance of class SimpleMathExam
        /// </summary>
        /// <param name="problemsSolved">The number of the solved problems.</param>
        public SimpleMathExam(int problemsSolved)
        {
            if (problemsSolved < 0 || problemsSolved > 10)
            {
                throw new ArgumentOutOfRangeException("The solved problems has to be from 0 to 10!");
            }

            this.ProblemsSolved = problemsSolved;
        }

        /// <summary>
        /// Check solved problems for this exam.
        /// </summary>
        /// <returns>Returns exam result.</returns>
        public override ExamResult Check()
        {
            if (ProblemsSolved == 0)
            {
                return new ExamResult(2, 2, 6, "Bad result: nothing done.");
            }
            else if (ProblemsSolved == 1)
            {
                return new ExamResult(4, 2, 6, "Average result: nothing done.");
            }
            else if (ProblemsSolved == 2)
            {
                return new ExamResult(6, 2, 6, "Average result: nothing done.");
            }

            throw new ArgumentOutOfRangeException("Invalid number of problems solved!");
        }
    }
}