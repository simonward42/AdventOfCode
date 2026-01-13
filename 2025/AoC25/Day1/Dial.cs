using System.Text.RegularExpressions;

namespace AoC25.Day1;

public class Dial
{
	int _dial = 50;
	int _zeroesCount = 0;
	int _zeroesPassedThrough = 0;
	Regex _turnRegex = new Regex(@"([LR])(\d+)");

	public int DialPosition => _dial;
	public int ZeroesLandedOn => _zeroesCount;
	public int ZeroesPassedThrough => _zeroesPassedThrough;
	public int Part1Answer => _zeroesCount;
	public int Part2Answer => _zeroesCount;
	public static bool Verbose { get; set; } = false;

	public void Turn1(string turnStr)
	{
		(var dir, var dist) = _ParseTurn(turnStr);
		_Click(dir, dist);
	}

	public void Turn2(string turnStr)
	{
		(var dir, var dist) = _ParseTurn(turnStr);

		// by clicking the dial for each step of the distance,
		// the existing zeroes count should include any passed through zeroes
		for (int i = 0; i < dist; i++)
		{
			_Click(dir, 1);
		}
	}
	private (string dir, int dist) _ParseTurn(string turnStr)
	{
		var turn = _turnRegex.Match(turnStr);
		if (!turn.Success)
		{
			throw new Exception("Parse error");
		}
		return (turn.Groups[1].Value, int.Parse(turn.Groups[2].Value));
	}

	private void _Click(string dir, int dist)
	{
		switch (dir)
		{
			case "L":
				_dial = _dial - dist;
				break;
			case "R":
				_dial = _dial + dist;
				break;
			default:
				Console.WriteLine($"Invalid direction {dir}");
				break;
		}

		if (_dial % 100 == 0) _zeroesCount++;
		_Log(dir, dist);
	}

	private void _Log(string dir, int dist)
	{
		if (Verbose)
		{
			Console.WriteLine($"Turned {dir}{dist}, now at {_dial}");
			Console.WriteLine($"{_zeroesPassedThrough} 0s passed through, {_zeroesCount} 0s landed on");
			Console.WriteLine($"\n");
		}
	}
}