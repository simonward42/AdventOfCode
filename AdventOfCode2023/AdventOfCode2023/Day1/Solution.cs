using Shared;
using Shared.Util;

namespace AdventOfCode2023.Day1;

public class Solution : Puzzle<int>
{
	private int _solutionPart1 = 0;
	private int _solutionPart2 = 0;

	public Solution() : base(1)
	{
	}

	//for each line of input, find the first and last digit (they may be the same char)
	//these form a two-digit number for each line - the 'calibration value';
	//return the sum of all calibration vals. 
	protected override int SolvePart1()
	{
		while (InputReader.TryReadLine(out string? currentLine))
		{
			var digits = currentLine.GetDigits();
			var calibrationVal = _GetCalibrationVal(digits);
			_solutionPart1 += calibrationVal;
		}

		return _solutionPart1;
	}

	//turns out some digits are spelled out, e.g. "one", "two" etc up to "nine" are valid.
	//do the same as part one, but including these 'wordy' digits...
	protected override int SolvePart2()
	{
		while (InputReader.TryReadLine(out string? currentLine))
		{
			var digits = _ParseDigits(currentLine);
			var calibrationVal = _GetCalibrationVal(digits);
			_solutionPart2 += calibrationVal;
		}

		return _solutionPart2;
	}

	private static IEnumerable<int> _ParseDigits(string input)
	{
		var digits = new List<int>();

		for (int i = 0; i < input.Length; i++)
		{
			if (_DigitFoundAtStart(input[i..], out int digit))
			{
				digits.Add(digit);
			}
		}
		return digits;
	}

	private static bool _DigitFoundAtStart(string input, out int digit)
	{
		if (char.IsDigit(input[0]))
		{
			digit = int.Parse(input[0].ToString());
			return true;
		}
		if (input.StartsWith("one"))
		{
			digit = 1;
			return true;
		}
		if (input.StartsWith("two"))
		{
			digit = 2;
			return true;
		}
		if (input.StartsWith("three"))
		{
			digit = 3;
			return true;
		}
		if (input.StartsWith("four"))
		{
			digit = 4;
			return true;
		}
		if (input.StartsWith("five"))
		{
			digit = 5;
			return true;
		}
		if (input.StartsWith("six"))
		{
			digit = 6;
			return true;
		}
		if (input.StartsWith("seven"))
		{
			digit = 7;
			return true;
		}
		if (input.StartsWith("eight"))
		{
			digit = 8;
			return true;
		}
		if (input.StartsWith("nine"))
		{
			digit = 9;
			return true;
		}
		digit = 0;
		return false;
	}

	private static int _GetCalibrationVal(IEnumerable<int> digits)
	{
		return (digits.First() * 10) + digits.Last();
	}
}
