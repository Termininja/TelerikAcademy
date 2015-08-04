namespace Exceptions
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
    {
        private const string ErrorMessage = "The value is not in the range!";

        public InvalidRangeException(T start, T end)
            : base(ErrorMessage)
        {
            this.Start = start;
            this.End = end;
        }

        public T Start { get; private set; }

        public T End { get; private set; }
    }
}