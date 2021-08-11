using System;

namespace Vektor
{
    namespace GeometryTasks
    {
        public class Vector
        {
            public double X;
            public double Y;
        }

        public class Geometry
        {
            static public double GetLength(Vector vec)
            {
                double length = Math.Sqrt((vec.X * vec.X + vec.Y * vec.Y));
                return length;
            }

            static public Vector Add(Vector vectorOne, Vector vectorTwo)
            {
                var sumVector = new Vector();
                sumVector.X = vectorOne.X + vectorTwo.X;
                sumVector.Y = vectorOne.Y + vectorTwo.Y;
                return sumVector;
            }
        }
    }
}
