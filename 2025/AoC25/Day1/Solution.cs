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
			dial.Turn1(currentLine);
		}

		return dial.Part1Answer;
	}

	//how many times does the dial pass through 0?
	protected override int SolvePart2()
	{
		var dial = new Dial();
		while (InputReader.TryReadLine(out string? currentLine))
		{
			dial.Turn2(currentLine);
		}

		return dial.Part2Answer;
	}
}
