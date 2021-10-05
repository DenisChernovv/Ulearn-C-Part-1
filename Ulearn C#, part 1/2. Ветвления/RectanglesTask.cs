using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
			if (r1.Left > r2.Right)
				return false;
			if (r1.Right < r2.Left)
				return false;
			if (r1.Top > r2.Bottom)
				return false;
			if (r1.Bottom < r2.Top)
				return false;
			return true;
		}

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
			var left = Math.Max(r1.Left, r2.Left);
			var right = Math.Min(r1.Right, r2.Right);
			var width = right - left;

			var top = Math.Max(r1.Top, r2.Top);
			var bottom = Math.Min(r1.Bottom, r2.Bottom);
			var height = bottom - top;

			if (width < 0 || height < 0)
				return 0;

			var area = width * height;
			return area;
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			if (r1.Left >= r2.Left && r1.Right <= r2.Right)
				if (r1.Top >= r2.Top && r1.Bottom <= r2.Bottom)
					return 0;
			if (r2.Left >= r1.Left && r2.Right <= r1.Right)
				if (r2.Top >= r1.Top && r2.Bottom <= r1.Bottom)
					return 1;
			return -1;
		}
	}
}