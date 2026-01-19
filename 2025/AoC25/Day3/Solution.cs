
using Shared.Util;

namespace AoC25.Day3;

public class Solution : Puzzle<long>
{
	public Solution(IInputReader? reader = null) : base(3, reader)
	{
	}

	//for each bank of batteries (aka line of puzzle input), 
	//find the digits to make the largest possible 2-digit number (maintaining order)
	//e.g. 818181911112111 => 92
	//return the sum of these 'joltages' for all banks
	protected override long SolvePart1()
	{
		int totalJoltage = 0;
		while (InputReader.TryReadLine(out string? currentLine))
		{
			var joltage = int.Parse(_LargestNumberOfLength(currentLine, length: 2));
			totalJoltage += joltage;
		}

		return totalJoltage;
	}

	private string _LargestNumberOfLength(string str, int length)
	{
		if (length == 0)
			return "";

		//excluding the final length-1 of the line, find the largest digit for the most significant decimal place
		int msdIndex = 0;
		char msd = str[msdIndex];

		for (int i = 1; i < str.Length - (length - 1); i++)
		{
			if (str[i] > msd)
			{
				msdIndex = i;
				msd = str[msdIndex];
			}
		}

		var joltage = msd + _LargestNumberOfLength(str[(msdIndex + 1)..], length - 1);

		return joltage;
	}

	//same as part 1, but this time we're finding 12-digit numbers
	protected override long SolvePart2()
	{
		long totalJoltage = 0;
		while (InputReader.TryReadLine(out string? currentLine))
		{

		}

		return totalJoltage;
	}
}