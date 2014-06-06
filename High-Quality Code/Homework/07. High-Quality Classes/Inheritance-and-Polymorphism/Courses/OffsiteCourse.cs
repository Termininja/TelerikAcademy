﻿namespace InheritanceAndPolymorphism
 {
     using System;
     using System.Collections.Generic;

     public class OffsiteCourse : Course
     {
         /// <summary>
         /// The town of the offsite course.
         /// </summary>
         private string town;

         public OffsiteCourse(string name)
             : base(name) { }

         public OffsiteCourse(string name, string teacherName)
             : base(name, teacherName) { }

         public OffsiteCourse(string name, string teacherName, IList<string> students)
             : base(name, teacherName, students) { }

         public OffsiteCourse(string name, string teacherName, IList<string> students, string town)
             : base(name, teacherName, students)
         {
             this.Town = town;
         }

         /// <summary>
         /// The town of the offsite course.
         /// </summary>
         public string Town
         {
             get
             {
                 return this.town;
             }

             set
             {
                 if (value != null)
                 {
                     this.town = value;
                 }
                 else
                 {
                     throw new ArgumentNullException("Town cannot be null!");
                 }
             }
         }

         /// <summary>
         /// Gets the all information about the offsite course.
         /// </summary>
         /// <returns>Returns the offsite course information like string.</returns>
         public override string ToString()
         {
             if (this.Town != null)
             {
                 string result = base.ToString() + string.Format("; Town = {0}", this.Town) + " }";

                 return result;
             }

             return base.ToString() + " }";
         }
     }
 }