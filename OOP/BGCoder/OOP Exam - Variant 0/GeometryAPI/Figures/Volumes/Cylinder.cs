using System;

namespace GeometryAPI
{
    public class Cylinder : Figure, IAreaMeasurable, IVolumeMeasurable
    {
        // Properties
        public double Radius { get; private set; }
        public double Height { get; private set; }

        // Constructor
        public Cylinder(Vector3D O1, Vector3D O2, double radius)
            : base(O1, O2)
        {
            this.Radius = radius;
            this.Height = (this.vertices[1] - this.vertices[0]).Magnitude;
        }

        // Methods
        public double GetArea()
        {
            return 2 * Math.PI * this.Radius * (this.Radius + this.Height);
        }

        public double GetVolume()
        {
            return Math.PI * this.Radius * this.Radius * this.Height;
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetVolume();
        }
    }
}
