﻿namespace InheritanceAndPolymorphism
 {
     using System;
     using System.Collections.Generic;

     public class LocalCourse : Course
     {
         /// <summary>
         /// The lab of the local course.
         /// </summary>
         private string lab;

         public LocalCourse(string name)
             : base(name) { }

         public LocalCourse(string name, string teacherName)
             : base(name, teacherName) { }

         public LocalCourse(string name, string teacherName, IList<string> students)
             : base(name, teacherName, students) { }

         public LocalCourse(string name, string teacherName, IList<string> students, string lab)
             : base(name, teacherName, students)
         {
             this.Lab = lab;
         }

         /// <summary>
         /// The lab of the local course.
         /// </summary>
         public string Lab
         {
             get
             {
                 return this.lab;
             }

             set
             {
                 if (value != null)
                 {
                     this.lab = value;
                 }
                 else
                 {
                     throw new ArgumentNullException("Lab cannot be null!");
                 }
             }
         }

         /// <summary>
         /// Gets the all information about the local course.
         /// </summary>
         /// <returns>Returns the local course information like string.</returns>
         public override string ToString()
         {
             if (this.Lab != null)
             {
                 string result = base.ToString() + string.Format("; Lab = {0}", this.Lab) + " }";

                 return result;
             }

             return base.ToString() + " }";
         }
     }
 }