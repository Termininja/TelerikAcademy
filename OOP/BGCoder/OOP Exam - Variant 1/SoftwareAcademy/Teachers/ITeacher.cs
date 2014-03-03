namespace SoftwareAcademy
{
    public interface ITeacher
    {
        // Property
        string Name { get; set; }

        // Methods
        void AddCourse(ICourse course);
        string ToString();
    }
}
