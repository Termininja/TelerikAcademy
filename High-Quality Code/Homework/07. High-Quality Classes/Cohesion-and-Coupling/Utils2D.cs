﻿namespace CohesionAndCoupling
 {
     using System;

     public static class Utils2D
     {
         public static double CalculateDistance2D(double x1, double y1, double x2, double y2)
         {
             double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));

             return distance;
         }

         public static double CalculateDiagonal(double firstSide, double secondSide)
         {
             double distance = Math.Sqrt((firstSide * firstSide) + (secondSide * secondSide));

             return distance;
         }
     }
 }