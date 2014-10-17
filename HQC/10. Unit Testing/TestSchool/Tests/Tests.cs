namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class Tests
    {
        private School school;
        private Course firstCourse;
        private Course secondCourse;
        private Student firstStudent;
        private Student secondStudent;

        [TestInitialize]
        public void InitializeSchool()
        {
            school = new School("School");
            firstCourse = new Course("Math");
            secondCourse = new Course("Bio");
            firstStudent = new Student("Ivan", 20000);
            secondStudent = new Student("Maria", 20000);

            firstCourse.AddStudent(firstStudent);
            school.AddCourse(firstCourse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentNameShouldNotbeNull()
        {
            firstStudent.Name = null;
        }

        [TestMethod]
        public void StudentNameShouldBeAvailable()
        {
            string studentName = firstStudent.Name;
            Assert.AreEqual("Ivan", studentName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentShouldHaveUniqueID()
        {
            firstCourse.AddStudent(secondStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentIDShouldBeInRange()
        {
            firstStudent.ID = 9999;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentsShouldBeLessThan30InOneCourse()
        {
            for (int i = 0; i < 100; i++)
            {
                firstCourse.AddStudent(new Student("Ivan", 10000 + i));
            }
        }

        [TestMethod]
        public void StudentShouldBeRemovedCorrectlyFromCourse()
        {
            firstCourse.RemoveStudent(firstStudent);
            Assert.AreEqual(0, firstCourse.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MissingStudentShouldBeNotRemovedFromCourse()
        {
            firstCourse.RemoveStudent(secondStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullStudentShouldBeNotRemovedFromCourse()
        {
            firstCourse.RemoveStudent(null);
        }

        [TestMethod]
        public void NewCourseShouldBeAdded()
        {
            school.AddCourse(secondCourse);
            Assert.AreEqual(2, school.Courses.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SameCourseNameShouldNotBeAddedInSchool()
        {
            secondCourse.Name = "Math";
            school.AddCourse(secondCourse);
        }

        [TestMethod]
        public void StudentShouldBePrintedByMainMethod()
        {
            Program.Main();
        }
    }
}
