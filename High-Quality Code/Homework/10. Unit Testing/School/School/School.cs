namespace School
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        /// <summary>
        /// List of courses for this school.
        /// </summary>
        private List<Course> courses;

        /// <summary>
        /// The list of all students in the school.
        /// </summary>
        private List<Student> students;

        /// <summary>
        /// Initializes a new instance of class School.
        /// </summary>
        /// <param name="name">The name of the school.</param>
        public School(string name)
        {
            students = new List<Student>();
            courses = new List<Course>();
            this.Name = name;
        }

        /// <summary>
        /// The name of the school.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// List of courses for this school.
        /// </summary>
        public List<Course> Courses
        {
            get { return this.courses; }
        }

        /// <summary>
        /// Add some course to the school.
        /// </summary>
        /// <param name="course">The course name.</param>
        public void AddCourse(Course newCourse)
        {
            var courseIndex = this.courses.IndexOf(newCourse);

            foreach (var course in this.courses)
            {
                if (course.Name == newCourse.Name)
                {
                    throw new ArgumentException("This course already exist in the school!");
                }
            }

            this.courses.Add(newCourse);
        }
    }
}