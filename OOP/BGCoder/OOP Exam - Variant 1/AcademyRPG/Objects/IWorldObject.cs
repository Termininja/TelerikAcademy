namespace AcademyRPG
{
    public interface IWorldObject
    {
        // Properties
        bool IsDestroyed { get; }
        int HitPoints { get; set; }
        Point Position { get; }
    }
}
