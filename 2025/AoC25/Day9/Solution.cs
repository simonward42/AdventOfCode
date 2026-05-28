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
        var boundaryVerticals = boundaryEdges.Where(e => e.First.X == e.Second.X).ToList();
        var boundaryHorizontals = boundaryEdges.Except(boundaryVerticals).ToList();

        //check each rectangle in order of area, largest first. If it is fully contained within the boundary, return its area
        Rectangle rectangle;
        var isValid = false;
        long area = 0;

        while (!isValid && rectangles.Count > 0)
        {
            rectangle = rectangles.Pop();
            area = rectangle.Area;

            //check for intersections between rectangle horizontals and boundary verticals, and vice versa
            //if any found, rectangle is invalid, continue >>>>
            //if none found, rectangle is probably valid, but edge case of rectangle edge coincident with boundary edge is possible
            //can check for this by using a scanline parity technique:
            //  cast a ray from the the non-defining corners of the rectangle to infinity (either vertically or horizontally, doesn't matter).
            //  if the ray intersects an odd number of boundary edges, the rectangle is valid. If even, invalid.

            isValid = true;
        }

        return area;
    }
}

class Rectangle
{
    public Point2d CornerA { get; set; }
    public Point2d CornerB { get; set; }
    public long Area { get; init; }
    public Rectangle(Point2d cornerA, Point2d cornerB)
    {
        CornerA = cornerA;
        CornerB = cornerB;
        //tiles have size 1x1
        long width = Math.Abs(cornerA.X - cornerB.X) + 1;
        long height = Math.Abs(cornerA.Y - cornerB.Y) + 1;
        Area = width * height;
    }
}