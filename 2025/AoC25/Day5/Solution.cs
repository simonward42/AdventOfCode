namespace AoC25.Day5;

using System.Text.RegularExpressions;

using Shared.Util;

public class Solution : Puzzle<int>
{
	private List<InclusiveRange<ulong>> _ranges;

	public Solution(IInputReader? reader = null) : base(5, reader)
	{
		var rangesInput = InputReader.ReadUntilEmptyLine();

		if (_ranges != null) return;

		_ranges = [];
		var rangeRegex = new Regex(@"(\d+)-(\d+)");
		Match match;
		foreach (var line in rangesInput)
		{
			match = rangeRegex.Match(line);
			_ranges.Add(new(
				min: ulong.Parse(match.Groups[1].Value),
				max: ulong.Parse(match.Groups[2].Value)));
		}
	}

	//input: ranges of fresh ingredient IDs; blank line; list of available ingredient IDs
	//return the number of available ingredient IDs that are fresh
	protected override int SolvePart1()
	{
		var freshIngredientCount = 0;

		//loop thru the id list, compare with ranges and count those that fall within
		InputReader.ReadUntilEmptyLine();
		while (InputReader.TryReadLine(out string? currentLine))
		{
			var currentId = ulong.Parse(currentLine);
			if (_ranges.Any(r => r.Contains(currentId)))
			{
				freshIngredientCount++;
			}
		}

		return freshIngredientCount;
	}

	//now the second part of the input is irrelevant - we need to return a count of all the IDs included
	//in the ranges. numbers could get big here...
	protected override int SolvePart2()
	{
		var freshIdCount = 0;

		//merge ranges until there are no more overlapping
		//then sum the sizes of all ranges

		return freshIdCount;
	}
}