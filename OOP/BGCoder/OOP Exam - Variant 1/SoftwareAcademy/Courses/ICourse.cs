namespace SoftwareAcademy
{
    public interface ICourse
    {
        // Properties
        string Name { get; set; }
        ITeacher Teacher { get; set; }

        // Methods
        void AddTopic(string topic);
        string ToString();
    }
}
