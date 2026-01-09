namespace AoC25.Day1;

public class Solution : Puzzle<int>
{
	public Solution() : base(1)
	{
	}

	//dial 0-99
	//dial starts at 50
	//input  = rotations
	//how many times does the dial land on 0?
	protected override int SolvePart1()
	{
		var dial = new Dial();
		while (InputReader.TryReadLine(out string? currentLine))
		{
			dial.Turn(currentLine);
		}

		return dial.ZeroesLandedOn;
	}

	//how many times does the dial pass through 0?
	protected override int SolvePart2()
	{
		while (InputReader.TryReadLine(out string? currentLine))
		{

		}

		return 2;
	}
}
