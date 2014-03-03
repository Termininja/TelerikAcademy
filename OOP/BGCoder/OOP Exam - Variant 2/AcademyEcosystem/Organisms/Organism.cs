namespace AcademyEcosystem
{
    public abstract class Organism : IOrganism
    {
        // Properties
        public bool IsAlive { get; protected set; }
        public Point Location { get; protected set; }
        public int Size { get; protected set; }

        // Constructor
        public Organism(Point location, int size)
        {
            this.Location = location;
            this.Size = size;
            this.IsAlive = true;
        }

        // Methods
        public virtual void Update(int time) { }

        public virtual void RespondTo(IOrganism organism) { }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
