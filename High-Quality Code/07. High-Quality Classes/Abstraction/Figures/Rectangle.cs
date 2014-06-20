﻿namespace Abstraction
 {
     using System;

     /// <summary>
     /// Class rectangle of type figure.
     /// </summary>
     public class Rectangle : IFigure
     {
         /// <summary>
         /// The width of the rectangle.
         /// </summary>
         private double width;

         /// <summary>
         /// The height of the rectangle.
         /// </summary>
         private double height;

         /// <summary>
         /// Initializes a new instance of class Rectangle.
         /// </summary>
         /// <param name="width">The width of the rectangle.</param>
         /// <param name="height">The height of the rectangle.</param>
         public Rectangle(double width, double height)
         {
             this.Width = width;
             this.Height = height;
         }

         /// <summary>
         /// The width of the rectangle.
         /// </summary>
         public double Width
         {
             get
             {
                 return this.width;
             }

             set
             {
                 if (value > 0)
                 {
                     this.width = value;
                 }
                 else
                 {
                     throw new ArgumentOutOfRangeException("Invalid input data. Width must be positive!");
                 }
             }
         }

         /// <summary>
         /// The height of the rectangle.
         /// </summary>
         public double Height
         {
             get
             {
                 return this.height;
             }

             set
             {
                 if (value > 0)
                 {
                     this.height = value;
                 }
                 else
                 {
                     throw new ArgumentOutOfRangeException("Invalid input data. Height must be positive!");
                 }
             }
         }

         /// <summary>
         /// Calculates the perimeter of the rectangle.
         /// </summary>
         /// <returns>Returns the perimeter.</returns>
         public double CalculatePerimeter()
         {
             double perimeter = 2 * (this.Width + this.Height);

             return perimeter;
         }

         /// <summary>
         /// Calculates the surface of the rectangle.
         /// </summary>
         /// <returns>Returns the surface.</returns>
         public double CalculateSurface()
         {
             double surface = this.Width * this.Height;

             return surface;
         }
     }
 }
