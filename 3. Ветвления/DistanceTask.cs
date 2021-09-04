using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            var acLength = Math.Sqrt((x - ax) * (x - ax) + (y - ay) * (y - ay));
            var bcLength = Math.Sqrt((x - bx) * (x - bx) + (y - by) * (y - by));
            var acabAngle = (x - ax) * (bx - ax) + (y - ay) * (by - ay);
            var bcbaAngle = (x - bx) * (ax - bx) + (y - by) * (ay - by);

            if (ax == bx && ay == by) return acLength;

            if (acabAngle < 0 || bcbaAngle < 0) 
                return Math.Min(acLength, bcLength);

            var height = Math.Abs((bx - ax) * (y - ay) - (by - ay) * (x - ax)) /
                Math.Sqrt((bx - ax) * (bx - ax) + (by - ay) * (by - ay));
            return height;
        }
    }
}