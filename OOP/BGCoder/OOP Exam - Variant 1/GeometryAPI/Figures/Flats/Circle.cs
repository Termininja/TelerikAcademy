using System;

namespace GeometryAPI
{
    public class Circle : Figure, IFlat, IAreaMeasurable
    {
        // Fields
        private Vector3D A;
        private Vector3D B;

        // Property
        public double Radius { get; private set; }

        // Constructor
        public Circle(Vector3D center, double radius)
            : base(center)
        {
            this.Radius = radius;
            A = new Vector3D(center.X + this.Radius, center.Y, center.Z);
            B = new Vector3D(center.X, center.Y + this.Radius, center.Z);
        }

        // Methods
        public Vector3D GetNormal()
        {
            Vector3D normal = Vector3D.CrossProduct(A - this.GetCenter(), B - this.GetCenter());
            normal.Normalize();
            return normal;
        }

        public double GetArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetArea();
        }
    }
}
