using System;

namespace Events
{
    class CowTippedEventArgs : EventArgs
    {
        #region Constructor
        public CowTippedEventArgs(CowState currentCowState)
        {
            this.CurrentCowState = currentCowState;
        }
        #endregion

        #region Property
        public CowState CurrentCowState { get; private set; }
        #endregion
    }
}
