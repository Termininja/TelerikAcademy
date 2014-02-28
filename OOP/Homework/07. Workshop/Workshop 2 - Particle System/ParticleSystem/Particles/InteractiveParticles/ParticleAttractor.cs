namespace ParticleSystem
{
    // Attract the other particles
    public class ParticleAttractor : Particle
    {
        // Property
        public int AttractionPower { get; private set; }

        // Constructor
        public ParticleAttractor(MatrixCoords position, MatrixCoords speed, int attractionPower)
            : base(position, speed)
        {
            this.AttractionPower = attractionPower;
        }

        // Method
        public override char[,] GetImage()
        {
            return new char[,] { { '-' } };
        }
    }
}
