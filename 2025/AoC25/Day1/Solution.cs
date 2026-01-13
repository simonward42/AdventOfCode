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
		var dial = new Dial();
		while (InputReader.TryReadLine(out string? currentLine))
		{
			(var dir, var dist) = _ParseTurn(currentLine);
			dial.Turn(dir, dist); //dial keeps track of how many times it lands on 0 after each turn
		}

		return dial.ZeroCount;
	}

	//how many times does the dial pass through 0?
	protected override int SolvePart2()
	{
		var dial = new Dial();
		while (InputReader.TryReadLine(out string? currentLine))
		{
			(var dir, var dist) = _ParseTurn(currentLine);

			//by turning the dial 1 click at a time, the existing zero count will include the number of times it passes through 0
			for (int i = 0; i < dist; i++)
			{
				dial.Turn(dir, 1);
			}
		}

		return dial.ZeroCount;
	}

	Regex _turnRegex = new Regex(@"([LR])(\d+)");

	private (string dir, int dist) _ParseTurn(string turnStr)
	{
		var turn = _turnRegex.Match(turnStr);
		if (!turn.Success)
		{
			throw new Exception("Parse error");
		}
		return (turn.Groups[1].Value, int.Parse(turn.Groups[2].Value));
	}
}
