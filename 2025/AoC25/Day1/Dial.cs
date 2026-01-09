using System.Text.RegularExpressions;

namespace AoC25.Day1;

public class Dial
{
	int _dial = 50;
	int _zeroesLandedOn = 0;
	int _zeroesPassedThrough = 0;
	Regex _turnRegex = new Regex(@"([LR])(\d+)");

	public int DialPosition => _dial;
	public int ZeroesLandedOn => _zeroesLandedOn;
	public int ZeroesPassedThrough => _zeroesPassedThrough;

	public void Turn(string turnStr)
	{
		var turn = _turnRegex.Match(turnStr);
		if (!turn.Success)
		{
			throw new Exception("Parse error");
		}
		var dir = turn.Groups[1].Value;
		var dist = int.Parse(turn.Groups[2].Value);

		switch (dir)
		{
			case "L":
				_dial = (_dial - dist) % 100;
				if (_dial == 0) _zeroesLandedOn++;
				break;
			case "R":
				_dial = (_dial + dist) % 100;
				if (_dial == 0) _zeroesLandedOn++;
				break;
			default:
				break;
		}
	}
}