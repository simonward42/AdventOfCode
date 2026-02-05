namespace AoC25.Day9;

using Shared.Util;

public class Solution(IInputReader? reader = null) : Puzzle<long>(9, reader)
{
	//using the input 2D coordinates, find the rectangle of greatest area that can 
	//be formed using any pair of input points as opposite corners. 
	protected override long SolvePart1()
	{
		List<Point2d> tilePositions = [];
		while (InputReader.TryReadLine(out string? line))
		{
			tilePositions.Add(new Point2d(line));
		}

		var pairAreas = tilePositions.CalculatePairwiseMetric((a, b) =>
		{
			//tiles have size 1x1
			long width = Math.Abs(a.X - b.X) + 1;
			long height = Math.Abs(a.Y - b.Y) + 1;
			return width * height;
		});

		return pairAreas.Max(x => x.Value);
	}

	//description
	protected override long SolvePart2()
	{
		while (InputReader.TryReadLine(out string? currentLine))
		{

		}

		return 0;
	}
}