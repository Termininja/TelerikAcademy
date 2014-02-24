using System.Collections.Generic;

namespace AcademyPopcorn
{
    class ShootingRacket : Racket
    {
        private bool hasShoot = false;
        private int bullets = 10;

        // Constructor
        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width) { }

        public override IEnumerable<GameObject> ProduceObjects(int col)
        {
            List<GameObject> shoot = new List<GameObject>();
            if (this.hasShoot && bullets > 0)
            {
                shoot.Add(new Bullet(new MatrixCoords(this.topLeft.Row, this.topLeft.Col + this.Width / 2)));
                this.hasShoot = false;
                bullets--;
            }
            return shoot;
        }

        public void Shoot()
        {
            this.hasShoot = true;
        }
    }
}
