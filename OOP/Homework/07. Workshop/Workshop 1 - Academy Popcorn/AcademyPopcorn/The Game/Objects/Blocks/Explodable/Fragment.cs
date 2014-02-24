namespace AcademyPopcorn
{
    public class Fragment : MovingObject
    {
        // Constructor
        public Fragment(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] { { '`' } }, speed) { }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }

        public override void Update()
        {
            this.IsDestroyed = true;
        }
    }
}
