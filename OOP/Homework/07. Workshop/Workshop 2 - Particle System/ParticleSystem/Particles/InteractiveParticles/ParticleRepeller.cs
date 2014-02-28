namespace ParticleSystem
{
    // Repel the other particles
    public class ParticleRepeller : ParticleAttractor
    {
        // Constructor
        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int repellentPower)
            : base(position, speed, -repellentPower) { }

        // Method
        public override char[,] GetImage()
        {
            return new char[,] { { '+' } };
        }
    }
}