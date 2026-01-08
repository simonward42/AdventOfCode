using Shared.Util;

namespace AdventOfCode2023.Day3
{
	internal class NumberPosition : Point2d
	{
		public int Value { get; set; } = 0;

		public int Width { get => Value.ToString().Length; }

		public bool Adjacent(Point2d point)
		{
			return
				(X - 1 <= point.X && point.X <= X + Width)
				&&
				(Y - 1 <= point.Y && point.Y <= Y + 1);
		}
	}
}
