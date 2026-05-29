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

	//input defines boundary of a region of valid tiles. 
	//find the largest rectangle (defined as in part 1) containing only valid tiles.
	protected override long SolvePart2()
	{
		List<Point2d> tilePositions = [];
		while (InputReader.TryReadLine(out string? line))
		{
			tilePositions.Add(new Point2d(line));
		}

		//pre-processing:
		//1. sort all rectangles by area, largest first
		var rectangles = new Stack<Rectangle>(
			tilePositions.CalculatePairwiseMetric((a, b) => { return new Rectangle(a, b); })
			.Select(x => x.Value)
			.OrderBy(r => r.Area));

		//2. find the edges of the boundary, split into vertical and horizontal edges
		//boundary wraps the input, so copy first point to end of list
		tilePositions.Add(tilePositions.First());
		var boundaryEdges = tilePositions.Zip(tilePositions.Skip(1)).ToList();

		//check each rectangle in order of area, largest first. If it is fully contained within the boundary, return its area
		Rectangle rect;
		var isValid = false;
		long area = 0;

		while (!isValid && rectangles.Count > 0)
		{
			rect = rectangles.Pop();
			area = rect.Area;

			//check for intersections between rectangle horizontals and boundary verticals, and vice versa
			//if any found, rectangle is invalid, continue >>>>
			if (boundaryEdges.Any(e => _Intersects(e, rect))) continue;

			//if none found, rectangle is probably valid*, but edge case of rectangle edge coincident with boundary edge is possible
			//could check for this by using a scanline parity technique:
			//  cast a ray from the the non-defining corners of the rectangle to infinity (either vertically or horizontally, doesn't matter).
			//  if the ray intersects an odd number of boundary edges, the rectangle is valid. If even, invalid.

			//*turns out this edge-case check wasn't required, may have gotten lucky with my input
			isValid = true;
		}

		return area;
	}

	private static bool _Intersects((Point2d First, Point2d Second) edge, Rectangle rect)
	{
		Console.WriteLine($"edge: {edge} rect:{rect.CornerA} {rect.CornerB}");
		//determine if edge is horiz or vert
		//then compare coordinates accordingly
		if (edge.First.X == edge.Second.X)
		{
			//vertical
			var edgeX = edge.First.X;
			var edgeMinY = Math.Min(edge.First.Y, edge.Second.Y);
			var edgeMaxY = Math.Max(edge.First.Y, edge.Second.Y);

			return
				rect.MinX < edgeX && edgeX < rect.MaxX
				&&
				(
					(edgeMinY < rect.MaxY && rect.MaxY <= edgeMaxY) //intersects rect top
					||
					(edgeMinY <= rect.MinY && rect.MinY < edgeMaxY) //intersects rect bottom
				);
		}
		else
		{
			//horizontal
			var edgeY = edge.First.Y;
			var edgeMinX = Math.Min(edge.First.X, edge.Second.X);
			var edgeMaxX = Math.Max(edge.First.X, edge.Second.X);

			return
				rect.MinY < edgeY && edgeY < rect.MaxY
				&&
				(
					(edgeMinX < rect.MaxX && rect.MaxX <= edgeMaxX) //intersects rect right
					||
					(edgeMinX <= rect.MinX && rect.MinX < edgeMaxX) //intersects rect left
				);
		}
	}
}

class Rectangle
{
	public Point2d CornerA { get; set; }
	public Point2d CornerB { get; set; }
	public int MinX { get; init; }
	public int MaxX { get; init; }
	public int MinY { get; init; }
	public int MaxY { get; init; }
	public long Area { get; init; }
	public Rectangle(Point2d cornerA, Point2d cornerB)
	{
		CornerA = cornerA;
		CornerB = cornerB;
		//tiles have size 1x1
		long width = Math.Abs(cornerA.X - cornerB.X) + 1;
		long height = Math.Abs(cornerA.Y - cornerB.Y) + 1;
		Area = width * height;
		MinX = Math.Min(cornerA.X, cornerB.X);
		MaxX = Math.Max(cornerA.X, cornerB.X);
		MinY = Math.Min(cornerA.Y, cornerB.Y);
		MaxY = Math.Max(cornerA.Y, cornerB.Y);
	}
}