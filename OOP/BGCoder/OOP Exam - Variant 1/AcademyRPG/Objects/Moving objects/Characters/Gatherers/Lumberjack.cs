namespace AcademyRPG
{
    public class Lumberjack : Character, IGatherer
    {
        // Constructor
        public Lumberjack(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 50;
        }

        // Method
        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber) return true;
            return false;
        }
    }
}
