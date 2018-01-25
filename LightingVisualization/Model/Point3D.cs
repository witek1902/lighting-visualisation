namespace LightingVisualization.Model
{
    using System;

    public class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D()
        {

        }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector ToVector()
        {
            return new Vector(X,Y,Z);
        }

        public override string ToString()
        {
            return String.Format("Point 3D [x='{0}', y='{1}', z='{2}'", X, Y, Z);
        }
    }
}
