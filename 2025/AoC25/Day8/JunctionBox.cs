namespace AoC25.Day8;

using Shared.Util;

public class JunctionBox(Point3d position)
{
	public Point3d Position { get; init; } = position;
	public Circuit? Circuit { get; set; }
}
