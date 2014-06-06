﻿namespace InheritanceAndPolymorphism
 {
     using System;
     using System.Collections.Generic;
     using System.Text;

     public abstract class Course
     {
         /// <summary>
         /// The name of the course.
         /// </summary>
         private string name;

         /// <summary>
         /// The name of the teacher.
         /// </summary>
         private string teacherName;

         /// <summary>
         /// The list of students.
         /// </summary>
         private IList<string> students = new List<string>();

         /// <summary>
         /// Initializes a new instance of class Course by given name.
         /// </summary>
         /// <param name="name">The name of the course.</param>
         protected Course(string name)
         {
             this.Name = name;
         }

         /// <summary>
         /// Initializes a new instance of class Course by given course name and teacherName.
         /// </summary>
         /// <param name="name">The name of the course.</param>
         /// <param name="teacherName">The name of the teacher.</param>
         protected Course(string name, string teacherName)
             : this(name)
         {
             this.TeacherName = teacherName;
         }

         /// <summary>
         /// Initializes a new instance of class Course by given course name, teacherName and list of students.
         /// </summary>
         /// <param name="name">The name of the course.</param>
         /// <param name="teacherName">The name of the teacher.</param>
         /// <param name="students">The list of students.</param>
         protected Course(string name, string teacherName, IList<string> students)
             : this(name, teacherName)
         {
             this.Students = students;
         }

         /// <summary>
         /// The name of the course.
         /// </summary>
         public string Name
         {
             get
             {
                 return this.name;
             }

             set
             {
                 if (value != null)
                 {
                     this.name = value;
                 }
                 else
                 {
                     throw new ArgumentNullException("Name cannot be null!");
                 }
             }
         }

         /// <summary>
         /// The name of the teacher.
         /// </summary>
         public string TeacherName
         {
             get
             {
                 return this.teacherName;
             }

             set
             {
                 if (value != null)
                 {
                     this.teacherName = value;
                 }
                 else
                 {
                     throw new ArgumentNullException("Teacher name cannot be null!");
                 }
             }
         }

         /// <summary>
         /// The list of students.
         /// </summary>
         public IList<string> Students
         {
             get
             {
                 return this.students;
             }

             set
             {
                 if (value != null)
                 {
                     this.students = value;
                 }
                 else
                 {
                     throw new ArgumentNullException("Students list cannot be null!");
                 }
             }
         }

         /// <summary>
         /// Gets the students from the course.
         /// </summary>
         /// <returns>Returns a string of students.</returns>
         protected string GetStudentsAsString()
         {
             if (this.Students == null || this.Students.Count == 0)
             {
                 return "{ }";
             }

             return "{ " + string.Join(", ", this.Students) + " }";
         }

         /// <summary>
         /// Gets the all information about the course.
         /// </summary>
         /// <returns>Returns the course information like string.</returns>
         public override string ToString()
         {
             StringBuilder result = new StringBuilder();
             result.Append(this.GetType().Name + " { Name = " + this.Name);

             if (this.TeacherName != null)
             {
                 result.Append("; Teacher = " + this.TeacherName);
             }

             result.Append("; Students = " + this.GetStudentsAsString());

             return result.ToString();
         }
     }
 }