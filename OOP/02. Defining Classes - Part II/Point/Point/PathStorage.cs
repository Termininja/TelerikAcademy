namespace Point
{
    using System;
    using System.IO;

    public static class PathStorage
    {
        // Loads paths from a text file
        public static Path LoadPath(string file)
        {
            // Reads some text file
            using (var read = new StreamReader(file))
            {
                var points = new Path();
                var text = read.ReadLine();
                for (int line = 0; text != null; line++)
                {
                    // Splits the coordinates of each one point
                    string[] currentLine = text.Split(' ');

                    // Adds the current point in the list
                    points.Points.Add(new Point3D(
                        int.Parse(currentLine[0]),
                        int.Parse(currentLine[1]),
                        int.Parse(currentLine[2])));

                    // Reads the next line
                    text = read.ReadLine();
                }

                return points;
            }
        }

        // Saves some path to a text file
        public static void SavePath(Path path)
        {
            using (var write = new StreamWriter(@"..\..\output.txt"))
            {
                for (int i = 0; i < path.Points.Count; i++)
                {
                    write.WriteLine(path.Points[i]);
                }
            }
        }
    }
}