using System;

namespace ReadOnlyVectorTask
{
	public class ReadOnlyVector
	{
		public readonly double X;
		public readonly double Y;

		public ReadOnlyVector(double x, double y)
		{
			X = x;
			Y = y;
		}

		public ReadOnlyVector Add(ReadOnlyVector other)
		{
			double x = this.X + other.X;
			double y = this.Y + other.Y;
			var sumVector = new ReadOnlyVector(x, y);
			return sumVector;
		}

		public ReadOnlyVector WithX(double x)
		{
			return new ReadOnlyVector(x, this.Y);
		}

		public ReadOnlyVector WithY(double y)
		{
			return new ReadOnlyVector(this.X, y);
		}
	}
}
