namespace AoC25.Day1;

public class Dial
{
	int _dial = 50;
	int _zeroesCount = 0;
	int _zeroesPassedThrough = 0;

	public int ZeroCount => _zeroesCount;

	public static bool Verbose { get; set; } = false;

	/// <summary>
	/// Turns by the given number of "clicks" in the given direction.
	/// Increments <see cref="ZeroCount"/> if the dial lands on 0 at the end of the turn./>
	/// </summary>
	/// <param name="dir">Either "L" or "R"</param>
	/// <param name="dist">The number of "clicks" to turn by</param>
	public void Turn(string dir, int dist)
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