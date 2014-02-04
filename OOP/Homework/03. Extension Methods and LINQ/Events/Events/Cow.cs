using System;

namespace Events
{
    class Cow
    {
        #region Event
        public event EventHandler<CowTippedEventArgs> Moo;
        #endregion

        #region Property
        public string Name { get; set; }
        #endregion

        #region Method
        public void BeTippedOver()
        {
            if (Moo != null)
            {
                // Cow states by random ganerator
                CowState state = new CowState();
                switch (new Random().Next() % 3)
                {
                    case 0: state = CowState.Awake; break;
                    case 1: state = CowState.Sleeping; break;
                    case 2: state = CowState.Dead; break;
                    default: break;
                }
                Moo(this, new CowTippedEventArgs(state));
            }
        }
        #endregion
    }
}