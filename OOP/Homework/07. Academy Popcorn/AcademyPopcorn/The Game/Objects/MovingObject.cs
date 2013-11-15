namespace AcademyPopcorn
{
    // Object which can be moved
    public class MovingObject : GameObject
    {
        // The distance of the moving (the new coordinates after movings)
        public MatrixCoords Speed { get; protected set; }

        // Constructors
        public MovingObject(MatrixCoords topLeft, char[,] body, MatrixCoords speed)
            : base(topLeft, body)
        {
            this.Speed = speed;
        }

        // Adding of the new coordinates
        protected virtual void UpdatePosition()
        {
            this.TopLeft += this.Speed;
        }

        public override void Update()
        {
            this.UpdatePosition();
        }
    }
}
