namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        /// <summary>
        /// List of students for this course.
        /// </summary>
        private List<Student> students;

        /// <summary>
        /// Initializes a new instance of class Course
        /// </summary>
        /// <param name="name">The name of the course.</param>
        public Course(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
        }

        /// <summary>
        /// The course name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The list of the students int the course.
        /// </summary>
        public List<Student> Students
        {
            get { return this.students; }
        }

        /// <summary>
        /// Adds some student in the course.
        /// </summary>
        /// <param name="student">The name of the student.</param>
        public void AddStudent(Student newStudent)
        {
            if (this.students.Count < 29)
            {
                foreach (var student in this.students)
                {
                    if (student.ID == newStudent.ID)
                    {
                        throw new ArgumentException("This student already exist in the course!");
                    }
                }

                this.students.Add(newStudent);
            }
            else
            {
                throw new ArgumentOutOfRangeException("The students should be less than 30 in this course!");
            }
        }

        /// <summary>
        /// Removes some student from the course.
        /// </summary>
        /// <param name="student">The name of the student.</param>
        public void RemoveStudent(Student student)
        {
            if (student != null)
            {
                int studentIndex = this.students.IndexOf(student);
                if (studentIndex != -1)
                {
                    this.students.Remove(student);
                }
                else
                {
                    throw new ArgumentException("The student is not in the course!");
                }
            }
            else
            {
                throw new ArgumentNullException("The student cannot be null!");
            }
        }

    }
}
