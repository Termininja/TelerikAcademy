using System;
using System.Collections.Generic;

namespace Point
{
    public class Path
    {
        // Hold a sequence of points in the 3D space
        public List<Point3D> Points = new List<Point3D>();

        // Adds a new point in the path
        public void Add(Point3D point)
        {
            Points.Add(point);
        }

        // Removes some point from the path
        public void RemoveAt(int position)
        {
            Points.RemoveAt(position);
        }

        // Clear the path
        public void Clear()
        {
            Points.Clear();
        }

        // Count the length of the path
        public int Count()
        {
            return Points.Count;
        }
    }
}