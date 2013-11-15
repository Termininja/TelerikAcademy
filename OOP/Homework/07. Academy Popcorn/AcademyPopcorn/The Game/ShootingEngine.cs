namespace AcademyPopcorn
{
    public class ShootingEngine : Engine
    {
        // Constructor
        public ShootingEngine(IRenderer renderer, IUserInterface userInterface, byte speed)
            : base(renderer, userInterface, speed) { }

        public void ShootPlayerRacket()
        {
            if (this.playerRacket is ShootingRacket)
            {
                (this.playerRacket as ShootingRacket).Shoot();
            }
        }
    }
}