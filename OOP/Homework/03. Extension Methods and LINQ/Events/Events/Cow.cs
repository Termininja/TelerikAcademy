using System;

namespace Events
{
    // Cow states
    public enum CowState { Awake, Sleeping, Dead }

    class Cow
    {
        // Event
        public event EventHandler<CowTippedEventArgs> Moo;

        // Property
        public string Name { get; set; }

        // Methods
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
    }
}