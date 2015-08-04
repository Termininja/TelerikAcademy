namespace Point
{
    using System;
    using System.Collections.Generic;

    public class Path
    {
        // Holds a sequence of points in the 3D space
        public List<Point3D> Points = new List<Point3D>();

        // Adds a new point in the path
        public void Add(Point3D point)
        {
            this.Points.Add(point);
        }

        // Removes some point from the path
        public void RemoveAt(int position)
        {
            this.Points.RemoveAt(position);
        }

        // Clears the path
        public void Clear()
        {
            this.Points.Clear();
        }

        // Counts the length of the path
        public int Count()
        {
            return this.Points.Count;
        }
    }
}