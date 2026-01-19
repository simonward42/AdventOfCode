namespace AoC25.Day3;

public class Solution : Puzzle<int>
{
	public Solution() : base(3)
	{
	}

	//for each bank of batteries (aka line of puzzle input), 
	//find the digits to make the largest possible 2-digit number (maintaining order)
	//e.g. 818181911112111 => 92
	//return the sum of these 'joltages' for all banks
	protected override int SolvePart1()
	{
		int totalJoltage = 0;
		while (InputReader.TryReadLine(out string? currentLine))
		{
			//excluding the final char of the line, find the largest digit for the tens place
			char tens = currentLine[0];
			int tensIndex = 0;
			for (int i = 1; i < currentLine.Length - 1; i++)
			{
				if (currentLine[i] > tens)
				{
					tensIndex = i;
					tens = currentLine[tensIndex];
				}
			}

			//find the largest digit to the right of tensIndex for the ones place
			char ones = currentLine[tensIndex + 1];
			for (int i = tensIndex + 2; i < currentLine.Length; i++)
			{
				if (currentLine[i] > ones)
				{
					ones = currentLine[i];
				}
			}

			var joltage = int.Parse($"{tens}{ones}");
			totalJoltage += joltage;
		}

		return totalJoltage;
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