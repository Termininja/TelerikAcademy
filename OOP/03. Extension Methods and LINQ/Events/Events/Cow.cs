namespace Events
{
    using System;

    public class Cow
    {
        public event EventHandler<CowTippedEventArgs> Moo;

        public string Name { get; set; }

        public void BeTippedOver()
        {
            if (Moo != null)
            {
                // Cow states by random ganerator
                var state = new CowState();
                switch (new Random().Next() % 3)
                {
                    case 0:
                        state = CowState.Awake;
                        break;
                    case 1:
                        state = CowState.Sleeping;
                        break;
                    case 2:
                        state = CowState.Dead;
                        break;
                    default: break;
                }

                Moo(this, new CowTippedEventArgs(state));
            }
        }
    }
}