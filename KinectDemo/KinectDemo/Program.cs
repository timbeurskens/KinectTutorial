using System;

namespace KinectDemo
{
    internal class Program
    {
        private static void Main()
        {
            Vector v1 = new Vector(2, 5, 7);
            Vector v2 = new Vector(-5, 9, 3);

            Console.WriteLine(v1.GetAngle(v2));
            Console.WriteLine(Vector.GetAngle(v1, v2));
            Console.ReadKey();
        }
    }

    internal class Vector
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

        public double GetAngle(Vector v)
        {
            var dot = X * v.X + Y * v.Y + Z * v.Z;
            var ln = GetLength() * v.GetLength();
            return Math.Acos(dot / ln);
        }

        public double GetLength()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public static double GetAngle(Vector v1, Vector v2)
        {
            return v1.GetAngle(v2);
        }
    }
}
