namespace AcademyRPG
{
    public interface IResource : IWorldObject
    {
        // Properties
        int Quantity { get; }
        ResourceType Type { get; }
    }
}
