using System;
using System.IO;

namespace Point
{
    static class PathStorage
    {
        // To load paths from a text file
        public static Path LoadPath(string file)
        {
            StreamReader read = new StreamReader(file);     // reads some text file
            using (read)
            {
                Path points = new Path();                   // creates empty path of points

                string text = read.ReadLine();
                for (int line = 0; text != null; line++)
                {
                    // Splits the coordinates of each one point
                    string[] currentLine = text.Split(' ');

                    // Adds the current point in the list
                    points.Points.Add(new Point3D(
                        int.Parse(currentLine[0]),
                        int.Parse(currentLine[1]),
                        int.Parse(currentLine[2])
                        ));
                    text = read.ReadLine();                 // reads the next line
                }
                return points;
            }
        }

        // To save paths to a text file
        public static void SavePath(Path path)
        {
            // The location of output file
            StreamWriter write = new StreamWriter(@"..\..\output.txt");
            using (write)
            {
                // Exports all points in the path in different lines
                for (int i = 0; i < path.Points.Count; i++)
                    write.WriteLine(path.Points[i]);
            }
        }
    }
}