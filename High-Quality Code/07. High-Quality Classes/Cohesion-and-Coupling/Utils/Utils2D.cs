﻿namespace CohesionAndCoupling
 {
     using System;

     /// <summary>
     /// Class for work with 2D figures.
     /// </summary>
     public static class Utils2D
     {
         /// <summary>
         /// Calculate the distance between two points X(x1,y1) and Y(x2,y2).
         /// </summary>
         /// <param name="x1">The 'x' coordinate of the first point.</param>
         /// <param name="y1">The 'y' coordinate of the first point.</param>
         /// <param name="x2">The 'x' coordinate of the second point.</param>
         /// <param name="y2">The 'y' coordinate of the second point.</param>
         /// <returns>Returns the distance between both points.</returns>
         public static double CalculateDistance2D(double x1, double y1, double x2, double y2)
         {
             double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));

             return distance;
         }

         /// <summary>
         /// Calculates the diagonal of some rectangle.
         /// </summary>
         /// <param name="firstSide">The first side of the rectangle.</param>
         /// <param name="secondSide">The second side of the rectangle.</param>
         /// <returns>Returns the diagonal of the rectangle.</returns>
         public static double CalculateDiagonal(double firstSide, double secondSide)
         {
             double diagonal = Math.Sqrt((firstSide * firstSide) + (secondSide * secondSide));

             return diagonal;
         }
     }
 }