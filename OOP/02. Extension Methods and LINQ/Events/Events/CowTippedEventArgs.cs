namespace Events
{
    using System;

    public class CowTippedEventArgs : EventArgs
    {
        public CowTippedEventArgs(CowState currentCowState)
        {
            this.CurrentCowState = currentCowState;
        }

        public CowState CurrentCowState { get; private set; }
    }
}
