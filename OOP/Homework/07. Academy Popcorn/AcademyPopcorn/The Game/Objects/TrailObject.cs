namespace AcademyPopcorn
{
    class TrailObject : GameObject
    {
        // Property
        private int Lifetime { get; set; }

        // Constructor
        public TrailObject(MatrixCoords topLeft, char[,] body, int lifetime)
            : base(topLeft, body)
        {
            this.Lifetime = lifetime;
        }

        // The TrailObject will disappear after a "lifetime" amount of turns
        public override void Update()
        {
            if (Lifetime == 0) this.IsDestroyed = true;
            Lifetime--;
        }
    }
}