namespace AoC25.Day7;

using Shared.Util;

public class Solution(IInputReader? reader = null) : Puzzle<int>(7, reader)
{
	private const char _splitter = '^';
	private const char _beam = '|';
	private const char _source = 'S';
	private const char _empty = '.';

	public bool Draw { get; set; } = false;

	//how many beam splitters are hit?
	//OR, how many beams terminate on a splitter?
	protected override int SolvePart1()
	{
		var field = InputReader.ReadAs2dCharArray();

		var beams = new List<int>(); // beam x positions
		var splitCount = 0;

		beams.Add(field[0].IndexOf(_source));

		for (int y = 0; y < field.Length; y++)
		{
			if (Draw)
				Console.WriteLine(new string(field[y]));

			beams = _Propagate(field, beams, y, ref splitCount);
		}

		return splitCount;
	}

	private List<int> _Propagate(char[][] field, List<int> beams, int y, ref int splitCount)
	{
		y++;
		if (y == field.Length)
		{
			return [];
		}

		var propagatedBeams = new List<int>();
		for (int i = 0; i < beams.Count; i++)
		{
			switch (field[y][beams[i]])
			{
				case _empty:
					field[y][beams[i]] = _beam;
					propagatedBeams.Add(beams[i]);
					break;

				case _splitter:
					splitCount++;
					if (field[y][beams[i] - 1] == _empty)
					{
						field[y][beams[i] - 1] = _beam;
						propagatedBeams.Add(beams[i] - 1);
					}
					if (field[y][beams[i] + 1] == _empty)
					{
						field[y][beams[i] + 1] = _beam;
						propagatedBeams.Add(beams[i] + 1);
					}
					break;

				default:
					break;
			}
		}

		return propagatedBeams;
	}

	//description
	protected override int SolvePart2()
	{
		while (InputReader.TryReadLine(out string? currentLine))
		{

		}

		return 0;
	}
}