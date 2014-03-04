namespace SoftwareAcademy
{
    // Create some teacher or course
    public class CourseFactory : ICourseFactory
    {
        // Methods
        public ITeacher CreateTeacher(string name)
        {
            return new Teacher(name);
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            ILocalCourse localCourse = new LocalCourse(name, lab);
            localCourse.Teacher = teacher;
            return localCourse;
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            IOffsiteCourse offsiteCourse = new OffsiteCourse(name, town);
            offsiteCourse.Teacher = teacher;
            return offsiteCourse;
        }
    }
}
