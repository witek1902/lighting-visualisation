namespace LightingVisualization.Model
{
    using System;

    /// <summary>
    /// Wektor
    /// </summary>
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Normalizacja wektora
        /// </summary>
        public void Normalize()
        {
            var length = Math.Sqrt(X*X + Y*Y + Z*Z);
            if(length != 0 && !Double.IsNaN(length))
            { 
                X = X/length;
                Y = Y/length;
                Z = Z/length;
            }
            else
            {
                X = 0;
                Y = 0;
                Z = 0;
            }
        }

        /// <summary>
        /// Mnożenie wektora przez wektor
        /// </summary>
        /// <param name="vector">Wektor</param>
        /// <returns>Liczba wynikowa</returns>
        public double Multiply(Vector vector)
        {
            return vector.X*X + vector.Y*Y + vector.Z*Z;
        }

        /// <summary>
        /// Mnożenie wektora przez liczbę
        /// </summary>
        /// <param name="value">Liczba</param>
        /// <returns>Nowy wektor</returns>
        public Vector Multiply(double value)
        {
            return new Vector(X*value,Y*value,Z*value);        
        }
    }
}
