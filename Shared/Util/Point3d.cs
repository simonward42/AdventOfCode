using System.Text.RegularExpressions;

namespace Shared.Util;

public partial class Point3d
{
	public Point3d() { }

	public Point3d(int x, int y, int z)
	{
		X = x; Y = y; Z = z;
	}

	public Point3d(string commaSeparated)
	{
		var match = PointRegex().Match(commaSeparated);

		X = int.Parse(match.Groups[1].Value);
		Y = int.Parse(match.Groups[2].Value);
		Z = int.Parse(match.Groups[3].Value);
	}

	public int X { get; set; } = 0;
	public int Y { get; set; } = 0;
	public int Z { get; set; } = 0;

	public double Distance(Point3d p)
	{
		long dx = p.X - X;
		long dy = p.Y - Y;
		long dz = p.Z - Z;

		return Math.Sqrt(dx * dx + dy * dy + dz * dz);
	}

	public override string ToString()
	{
		return $"{X}, {Y}, {Z}";
	}

	[GeneratedRegex(@"(\d+),(\d+),(\d+)")]
	private static partial Regex PointRegex();
}
