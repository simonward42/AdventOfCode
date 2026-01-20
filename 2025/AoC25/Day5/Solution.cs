namespace AoC25.Day5;

using System.Text.RegularExpressions;

using Shared.Util;

public class Solution(IInputReader? reader = null) : Puzzle<int>(5, reader)
{
	//input: ranges of fresh ingredient IDs; blank line; list of available ingredient IDs
	//return the number of available ingredient IDs that are fresh
	protected override int SolvePart1()
	{
		var freshCount = 0;

		//read and parse the fresh ranges somehow
		//ranges can overlap. while building the list we could combine overlapping ranges to reduce the number we compare against.
		var rangesInput = InputReader.ReadUntilEmptyLine();
		var ranges = new List<Range<ulong>>();
		var rangeRegex = new Regex(@"(\d+)-(\d+)");
		Match match;
		foreach (var line in rangesInput)
		{
			match = rangeRegex.Match(line);
			ranges.Add(new(
				min: ulong.Parse(match.Groups[1].Value),
				max: ulong.Parse(match.Groups[2].Value)));
		}

		//loop thru the id list, compare with ranges and count those that fall within
		while (InputReader.TryReadLine(out string? currentLine))
		{
			var currentId = ulong.Parse(currentLine);
			if (ranges.Any(r => r.ContainsInclusive(currentId)))
			{
				freshCount++;
			}
		}

		return freshCount;
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