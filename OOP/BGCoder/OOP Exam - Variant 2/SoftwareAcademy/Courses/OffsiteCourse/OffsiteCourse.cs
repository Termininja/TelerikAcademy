namespace SoftwareAcademy
{
    public class OffsiteCourse : Course, IOffsiteCourse
    {
        // Property
        public string Town { get; set; }

        // Constructor
        public OffsiteCourse(string name, string town)
            : base(name)
        {
            this.Town = town;
        }
    }
}
