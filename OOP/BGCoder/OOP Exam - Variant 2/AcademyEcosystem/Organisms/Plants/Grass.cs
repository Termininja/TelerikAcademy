namespace AcademyEcosystem
{
    public class Grass : Plant
    {
        // Constructor
        public Grass(Point location) : base(location, 2) { }

        // Method
        public override void Update(int time)
        {
            if (this.IsAlive) this.Size += time;
            base.Update(time);
        }
    }
}
