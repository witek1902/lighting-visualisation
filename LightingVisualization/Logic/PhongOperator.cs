namespace LightingVisualization.Logic
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using Model;
    using Helpers;

    public class PhongOperator
    {
        public Point3D Source = new Point3D(0,0,200);
        public Vector Observator = new Vector(0, 0, 200);
        /// <summary>
        /// Natężenie światła w otoczeniu obiektu (jednakowe dla wszystkich obiektów)
        /// </summary>
        public const double Ia = 100;
        /// <summary>
        /// Natężenie światła punktowego
        /// </summary>
        public const double Ip = 60000;
        /// <summary>
        /// Współczynnik odbicia światła otoczenia (tła)
        /// </summary>
        public const double Ka = 0.4;
        /// <summary>
        /// Krok
        /// </summary>
        public const int Step = 10;

        public Bitmap PhongAlgorithm(Bitmap image, Surface material)
        {
            Observator.Normalize();

            var newImage = new Bitmap(500, 500, PixelFormat.Format24bppRgb);
            var lockBitmap = new LockBitmap(image);
            lockBitmap.LockBits();
            var newLockBitmap = new LockBitmap(newImage);
            newLockBitmap.LockBits();

            for (var i = 0; i < 500; i++)
            {
                for (var j = 0; j < 500; j++)
                {
                    var pixelColor = lockBitmap.GetPixel(j,i);

                    if (pixelColor != Color.Black)
                    {
                        //Cieniowanie Phonga
                        //Wyznaczamy wierzchołek
                        var point = ComputeZ(i - 250, j - 250);
                        //Obliczony punkt przekształcamy na wektor
                        var l = point.ToVector();
                        //Normalizujemy obliczony wektor
                        l.Normalize();
                        //Od źródła odejmujemy obliczony punkt i normalizujemy powstały wektor
                        var n = ComputeVector(point, Source);
                        n.Normalize();

                        //Model odbicia Phonga
                        var I = CalculateLightReflection(material, Scalar(n, l), 
                                    CalculateCosAlpha(ComputeVector(Source, point), l), point);

                        //Obliczanie nowych kolorów
                        var red = Check(pixelColor.R + I);
                        var green = Check(pixelColor.G + I);
                        var blue = Check(pixelColor.B + I);

                        newLockBitmap.SetPixel(j,i,Color.FromArgb(red, green, blue));
                    }
                }
            }
            lockBitmap.UnlockBits();
            newLockBitmap.UnlockBits();

            return newImage;
        }

        public void MoveRight()
        {
            Source.X = Source.X - Step;
        }

        public void MoveLeft()
        {
            Source.X = Source.X + Step;
        }

        public void Forward()
        {
            Source.Z = Source.Z - Step;
        }

        public void Backward()
        {
            Source.Z = Source.Z + Step;
        }

        public void Up()
        {
            Source.Y = Source.Y - Step;
        }

        public void Down()
        {
            Source.Y = Source.Y + Step;

        }

        private static int Check(double i)
        {
            if (i < 0)
            {
                return 0;
            }
            else if (i > 255)
            {
                return 255;
            }
            else
            {
                return (int)i;
            }
        }

        private double CalculateLightReflection(Surface surface, double scalar, double cosAlpha, Point3D point)
        {
            return Ia * Ka
                    + Fatt(point) * Ip * surface.Kd * scalar
                    + Fatt(point) * Ip * surface.Ks * Math.Pow(cosAlpha, surface.N);
        }

        private static Point3D ComputeZ(int x, int y)
        {
            return new Point3D(x, y, (int)Math.Sqrt(150 * 150 - x * x - y * y));
        }

        private static Vector ComputeVector(Point3D start, Point3D end)
        {
            return new Vector(end.X - start.X, end.Y - start.Y, end.Z - start.Z);
        }

        private static double Scalar(Vector v, Vector b)
        {
            return v.X * b.X + v.Y * b.Y + v.Z * b.Z;
        }

        /// <summary>
        /// Funkcja cos^n(a) opisuje odbicie kierunkowe
        /// Im większa wartość N (wykorzystana później przy obliczaniu)
        /// tym bardziej powierzchnia zbliża się do powierzchni lustrzanej.
        /// Dla N rzędu kilkuset mamy do czynienia z dobrym lustrem.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static double CalculateCosAlpha(Vector v, Vector b)
        {
            var distance = Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z) * Math.Sqrt(b.X * b.X + b.Y * b.Y + b.Z * b.Z);
            if (Scalar(v, b) > 0) return 0;
            return Scalar(v, b) / distance;
        }

        /// <summary>
        /// Współczynnik tłumienia źródła światła z odległością
        /// Strumień światła pochodzący z punktowego źródła światła
        /// maleje z kwadratem odległości jaką przebywa
        /// </summary>
        /// <param name="p">Punkt</param>
        /// <returns>Współczynnik</returns>
        private double Fatt(Point3D p)
        {
            var distance = Math.Pow(p.X + Source.X, 2) + Math.Pow(p.Y + Source.Y, 2) + Math.Pow(p.Z + Source.Z, 2);
            return 1.0 / Math.Sqrt(distance);
        }
    }
}
