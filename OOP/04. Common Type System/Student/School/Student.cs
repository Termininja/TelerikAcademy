namespace Student
{
    using System;

    public class Student : ICloneable, IComparable<Student>
    {
        public Student(
            string firstName, string middleName, string lastName,
            int ssn, string permanentAddress, string mobilePhone, string email, string course,
            University university, Faculty faculty, Specialty specialty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.University = university;
            this.Faculty = faculty;
            this.Specialty = specialty;
        }

        public string FirstName { get; private set; }

        public string MiddleName { get; private set; }

        public string LastName { get; private set; }

        public int SSN { get; private set; }

        public string PermanentAddress { get; private set; }

        public string MobilePhone { get; private set; }

        public string Email { get; private set; }

        public string Course { get; private set; }

        public University University { get; private set; }

        public Faculty Faculty { get; private set; }

        public Specialty Specialty { get; private set; }

        // Overrides the standard Equals()
        public override bool Equals(object obj)
        {
            var student = obj as Student;
            var result =
                this.FirstName == student.FirstName &&
                this.MiddleName == student.MiddleName &&
                this.LastName == student.LastName &&
                this.SSN == student.SSN;

            return result;
        }

        // Overrides the standard operator ==
        public static bool operator ==(Student student1, Student student2)
        {
            return student1.Equals(student2);
        }

        // Overrides the standard operator !=
        public static bool operator !=(Student student1, Student student2)
        {
            return !student1.Equals(student2);
        }

        // Overrides the standard GetHashCode()
        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.SSN.GetHashCode();
        }

        // Overrides the standard ToString()
        public override string ToString()
        {
            var result = String.Format("Name: {0} {1} {2}\n", this.FirstName, this.MiddleName, this.LastName) +
                String.Format("SSN: {0}\n", this.SSN) +
                String.Format("Permanent Address: {0}\n", this.PermanentAddress) +
                String.Format("Mobile Phone: {0}\n", this.MobilePhone) +
                String.Format("Email: {0}\n", this.Email) +
                String.Format("Course: {0}\n", this.Course) +
                String.Format("University: {0}\n", this.University) +
                String.Format("Faculty: {0}\n", this.Faculty) +
                String.Format("Specialty: {0}\n", this.Specialty);

            return result;
        }

        // Deeply copy of all object's fields into a new object of type Student
        public object Clone()
        {
            var student = new Student(
                this.FirstName, this.MiddleName, this.LastName,
                this.SSN, this.PermanentAddress, this.MobilePhone, this.Email, this.Course,
                this.University, this.Faculty, this.Specialty);

            return student;
        }

        // Compares two students by names and after that by SSN
        public int CompareTo(Student student)
        {
            if (this.FirstName != student.FirstName)
            {
                return this.FirstName.CompareTo(student.FirstName);
            }
            if (this.MiddleName != student.MiddleName)
            {
                return this.MiddleName.CompareTo(student.MiddleName);
            }
            if (this.LastName != student.LastName)
            {
                return this.LastName.CompareTo(student.LastName);
            }
            if (this.SSN != student.SSN)
            {
                return this.SSN.CompareTo(student.SSN);
            }

            return 0;
        }
    }
}