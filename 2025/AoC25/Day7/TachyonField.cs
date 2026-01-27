namespace AoC25.Day7;

using System;

public partial class Solution
{
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

		public int SplitCount { get; private set; } = 0;

		public TachyonField(char[][] space)
		{
			_space = space;
			_height = _space.Length;
			_width = _space[0].Length;

			Amplitude = new long[_height, _width];
			Amplitude[0, _space[0].IndexOf(_source)] = 1; //source adds 1 to Amp at its position
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
								SplitCount++;
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

		public long SumAmplitude(int y)
		{
			long sum = 0;
			for (int i = 0; i < _width; i++)
			{
				sum += Amplitude[y, i];
			}

			return sum;
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

		public void Draw()
		{
			for (int y = 0; y < _space.Length - 1; y++)
			{
				Console.WriteLine($"{Draw(y)}");
			}
		}
	}
}