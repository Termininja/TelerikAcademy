namespace GeometryAPI
{
    public class Vertex : Figure
    {
        // Property
        public Vector3D Location
        {
            get { return this.vertices[0]; }
            set { this.vertices[0] = value; }
        }

        // Constructor
        public Vertex(Vector3D location)
            : base(location)
        {
        }

        // Method
        public override double GetPrimaryMeasure()
        {
            return 0;
        }
    }
}
