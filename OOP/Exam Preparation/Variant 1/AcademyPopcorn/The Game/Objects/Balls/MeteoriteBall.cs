using System.Collections.Generic;

namespace AcademyPopcorn
{
    class MeteoriteBall : Ball
    {
        // Constructor
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            // The symbol of meteorite ball
            this.body[0, 0] = '♦';
        }

        // The meteorite ball will leave a trail of TrailObject objects
        public override IEnumerable<GameObject> ProduceObjects(int col)
        {
            Queue<GameObject> trail = new Queue<GameObject>();
            trail.Enqueue(new TrailObject(this.topLeft, new char[,] { { '.' } }, 3));
            return trail;
        }
    }
}