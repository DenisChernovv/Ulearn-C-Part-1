using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
		private static void Main()
		{
			var array = new[]
			{
				new Point { X = 1, Y = 0 },
				new Point { X = -1, Y = 0 },
				new Point { X = 0, Y = 1 },
				new Point { X = 0, Y = -1 },
				new Point { X = 0.01, Y = 1 }
			};

			Array.Sort(array, new ClockwiseComparer());
			foreach (Point e in array)
				Console.WriteLine("{0} {1}", e.X, e.Y);
		}

		public class Point
		{
			public double X;
			public double Y;
		}

		public class ClockwiseComparer : IComparer
		{
			public int Compare(object x, object y)
			{
				var xClock = (Point)x;
				var yClock = (Point)y;
				
				var angleX = Math.Atan2(xClock.X, xClock.Y);
				var angleY = Math.Atan2(yClock.X, yClock.Y);

				if (angleX < 0 && angleY >= 0) return 1;
				else if (angleX >= 0 && angleY < 0) return -1;
				else if (angleX >= 0 && angleY >= 0) return angleX.CompareTo(angleY);
				else return angleX.CompareTo(angleY);

			}
		}
	}
}
