namespace AoC25.Day7;

using System;

using Shared.Util;

public class Solution(IInputReader? reader = null) : Puzzle<long>(7, reader)
{
	const char _splitter = '^';
	const char _beam = '|';
	const char _source = 'S';
	const char _empty = '.';

	public bool Draw { get; set; } = false;

	//how many beam splitters are hit?
	//OR, how many beams terminate on a splitter?
	protected override long SolvePart1()
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

	//path integral (sort of?)
	protected override long SolvePart2()
	{
		var space = InputReader.ReadAs2dCharArray();

		var field = new TachyonField(space);
		field.Propagate();

		for (int y = 0; y < space.Length - 1; y++)
		{
			if (Draw)
			{
				Console.WriteLine($"{field.Draw(y)}");
			}
		}

		return field.SumAmplitude(space.Length - 1);
	}

	class TachyonField
	{
		const char _splitter = '^';
		const char _beam = '|';
		const char _source = 'S';
		const char _empty = '.';
		readonly int _height;
		readonly int _width;
		readonly char[][] _space;

		public long[,] Amplitude { get; set; }

		public TachyonField(char[][] space)
		{
			_space = space;
			_height = _space.Length;
			_width = _space[0].Length;

			Amplitude = new long[_height, _width];
			Amplitude[0, _space[0].IndexOf(_source)] = 1; //source adds 1 to Amp at its position
		}

		public string Draw(int y)
		{
			var slice = "";
			for (int i = 0; i < _width; i++)
			{
				slice += $"{Amplitude[y, i]} ";
			}

			return $"{new string(_space[y])} {slice}";
		}

		public long SumAmplitude(int y)
		{
			long sum = 0;
			for (int i = 0; i < _width; i++)
			{
				sum += Amplitude[y, i];
			}

			return sum;
		}

		public void Propagate()
		{
			int dy;
			for (int y = 0; y < _height - 1; y++)
			{
				dy = y + 1;
				for (int x = 0; x < _width; x++)
				{
					if (Amplitude[y, x] != 0)
					{
						switch (_space[dy][x])
						{
							case _empty:
							case _beam:
								Amplitude[dy, x] += Amplitude[y, x];
								_space[dy][x] = _beam;
								break;

							case _splitter:
								Amplitude[dy, x - 1] += Amplitude[y, x];
								Amplitude[dy, x + 1] += Amplitude[y, x];
								_space[dy][x + 1] = _beam;
								_space[dy][x - 1] = _beam;

								break;
						}
					}
				}
			}
		}
	}
}