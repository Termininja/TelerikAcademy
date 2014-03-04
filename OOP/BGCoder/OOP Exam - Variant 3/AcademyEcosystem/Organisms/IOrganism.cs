namespace AcademyEcosystem
{
    public interface IOrganism
    {
        // Properties
        bool IsAlive { get; }
        Point Location { get; }
        int Size { get; }

        // Methods
        void Update(int timeElapsed);
    }
}
