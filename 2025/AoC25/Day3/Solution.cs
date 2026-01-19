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
		while (InputReader.TryReadLine(out string? currentLine))
		{

		}

		return 0;
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