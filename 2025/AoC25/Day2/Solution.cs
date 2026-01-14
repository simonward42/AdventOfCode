
using Shared.Util;

namespace AoC25.Day2;

public class Solution : Puzzle<long>
{
	public Solution() : base(2)
	{
	}

	//input is a series of int ranges
	//check all ranges for values that are a twice-repeated sequence of digits (aka "invalid IDs"
	//e.g. 123123, 55, 222222
	//return the sum of all such values 
	protected override long SolvePart1()
	{
		var ranges = InputReader.ReadLine().Split(',');
		var invalidIds = new HashSet<long>();

		var rangeEnds = new string[2];
		var rangeEndIds = new long[2];
		foreach (var range in ranges)
		{
			rangeEnds = [.. range.Split("-")];
			//if the entire range has an odd number of digits, none can be invalid
			if (rangeEnds[0].HasOddLength() && rangeEnds[1].HasOddLength())
				continue;

			rangeEndIds = [.. rangeEnds.Select(long.Parse)];

			for (long id = rangeEndIds[0]; id <= rangeEndIds[1]; id++)
			{
				//do the isInvalid check and add to invalidIds
				if (_IsInvalid(id))
				{
					invalidIds.Add(id);
				}
			}
		}

		//Console.WriteLine(string.Join("\n", ranges));
		return invalidIds.Sum();
	}

	private bool _IsInvalid(long id)
	{
		//invalid IDs all have an even number of digits
		var idStr = id.ToString();
		if (idStr.HasOddLength())
			return false;

		var firstHalf = idStr[..(idStr.Length / 2)];
		var secondHalf = idStr[(idStr.Length / 2)..];
		//Console.WriteLine($"{idStr}: {firstHalf} {secondHalf}");
		return firstHalf == secondHalf;
	}

	//description
	protected override long SolvePart2()
	{
		while (InputReader.TryReadLine(out string? currentLine))
		{

		}

		return 0;
	}
}