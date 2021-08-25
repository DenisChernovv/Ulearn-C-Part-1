using System;

namespace ReadOnlyVectorTask
{
	public class ReadOnlyVector
	{
		public double X;
		public double Y;

		public double GetLength()
		{
			return Geometry.GetLength(this);
		}

		public ReadOnlyVector Add(ReadOnlyVector vector)
		{
			return Geometry.Add(this, vector);
		}

		public bool Belongs(Segment segment)
		{
			return Geometry.IsVectorInSegment(this, segment);
		}
	}

	public class Geometry
	{
		static public double GetLength(ReadOnlyVector vec)
		{
			double length = Math.Sqrt(vec.X * vec.X + vec.Y * vec.Y);
			return length;
		}

		static public double GetLength(Segment segment)
		{
			var length = Math.Sqrt((segment.End.X - segment.Begin.X) * (segment.End.X - segment.Begin.X)
				+ (segment.End.Y - segment.Begin.Y) * (segment.End.Y - segment.Begin.Y));
			return length;
		}

		static public bool IsVectorInSegment(ReadOnlyVector point, Segment segment)
		{
			bool isPointOnSegment = false;
			var segmentBeginToPoint = new Segment { Begin = segment.Begin, End = point };
			var segmentPointToEnd = new Segment { Begin = point, End = segment.End };

			var lengthSegment = Geometry.GetLength(segment);
			var lengthBeginPoint = Geometry.GetLength(segmentBeginToPoint);
			var lengthPointEnd = Geometry.GetLength(segmentPointToEnd);

			if (lengthBeginPoint + lengthPointEnd == lengthSegment) isPointOnSegment = true;

			return isPointOnSegment;
		}

		static public ReadOnlyVector Add(ReadOnlyVector vectorOne, ReadOnlyVector vectorTwo)
		{
			var sumVector = new ReadOnlyVector();
			sumVector.X = vectorOne.X + vectorTwo.X;
			sumVector.Y = vectorOne.Y + vectorTwo.Y;
			return sumVector;
		}
	}

	public class Segment
	{
		public ReadOnlyVector Begin;
		public ReadOnlyVector End;
		public double GetLength()
		{
			return Geometry.GetLength(this);
		}
		public bool Contains(ReadOnlyVector vector)
		{
			return Geometry.IsVectorInSegment(vector, this);
		}
	}
}
