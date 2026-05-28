using System.Text.RegularExpressions;

namespace Shared.Util;

public class Point2d
{
	public Point2d() { }

	public Point2d(int x, int y)
	{
		X = x; Y = y;
	}

	public Point2d(string commaSeparated)
	{
		var match = new Regex(@"(\d+),(\d+)").Match(commaSeparated);

		X = int.Parse(match.Groups[1].Value);
		Y = int.Parse(match.Groups[2].Value);
	}

	public int X { get; set; } = 0;
	public int Y { get; set; } = 0;

	public double Distance(Point2d p)
	{
		long dx = p.X - X;
		long dy = p.Y - Y;

		return Math.Sqrt(dx * dx + dy * dy);
	}

	public override string ToString()
	{
		return $"({X},{Y})";
	}

	public override bool Equals(object? obj)
	{
		if (obj is not Point2d point) return false;

		return point.X == X && point.Y == Y;
	}

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}
