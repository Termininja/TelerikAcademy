using System;

namespace Events
{
    class CowTippedEventArgs : EventArgs
    {
        // Constructor
        public CowTippedEventArgs(CowState currentCowState)
        {
            this.CurrentCowState = currentCowState;
        }

        // Property
        public CowState CurrentCowState { get; private set; }
    }
}
