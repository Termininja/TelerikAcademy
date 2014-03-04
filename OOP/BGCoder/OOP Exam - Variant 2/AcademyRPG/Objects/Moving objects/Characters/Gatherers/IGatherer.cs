namespace AcademyRPG
{
    public interface IGatherer : IControllable
    {
        // Method
        bool TryGather(IResource resource);
    }
}
