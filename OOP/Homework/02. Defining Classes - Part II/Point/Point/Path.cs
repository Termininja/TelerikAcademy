using System;
using System.Collections.Generic;

namespace Point
{
    public class Path
    {
        // Hold a sequence of points in the 3D space
        public List<Point3D> Points = new List<Point3D>();

        // Methods
        public void Add(Point3D point) { Points.Add(point); }               // adds a new point in the path

        public void RemoveAt(int position) { Points.RemoveAt(position); }   // removes some point from the path

        public void Clear() { Points.Clear(); }                             // clear the path

        public int Count() { return Points.Count; }                         // count the length of the path
    }
}