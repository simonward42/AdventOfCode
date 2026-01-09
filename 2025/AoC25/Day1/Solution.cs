using System.Text.RegularExpressions;

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
		int dial = 50;
		int zeroCount = 0;
		var turnRegex = new Regex(@"([LR])(\d+)");
		while (InputReader.TryReadLine(out string? currentLine))
		{
			var turn = turnRegex.Match(currentLine);
			if (!turn.Success)
			{
				throw new Exception("Parse error");
			}
			var dir = turn.Groups[1].Value;
			var dist = int.Parse(turn.Groups[2].Value);

			switch (dir)
			{
				case "L":
					dial = (dial - dist) % 100;
					if (dial == 0) zeroCount++;
					break;
				case "R":
					dial = (dial + dist) % 100;
					if (dial == 0) zeroCount++;
					break;
				default:
					break;
			}
		}

		return zeroCount;
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

public class Dial
{
	int _dial;

	public Dial()
	{
		_dial = 50;
	}
}