namespace SoftwareAcademy
{
    public class LocalCourse : Course, ILocalCourse
    {
        // Property
        public string Lab { get; set; }

        // Constructor
        public LocalCourse(string name, string lab)
            : base(name)
        {
            this.Lab = lab;
        }
    }
}
