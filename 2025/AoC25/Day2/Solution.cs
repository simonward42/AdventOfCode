
using System.Text.RegularExpressions;

using Shared.Util;

namespace AoC25.Day2;

public class Solution : Puzzle<long>
{
	public Solution() : base(2)
	{
	}

	//input is a series of int ranges
	//check all ranges for values that are a twice-repeated sequence of digits (aka "invalid IDs")
	//e.g. 123123, 55, 222222
	//return the sum of all such values 
	protected override long SolvePart1()
	{
		var ranges = InputReader.ReadLine().Split(',');
		var invalidIds = new HashSet<long>();

		var invalidRegex = new Regex(@"^(\d+?)\1$");

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
				if (invalidRegex.IsMatch(id.ToString()))
				{
					invalidIds.Add(id);
				}
			}
		}
		return invalidIds.Sum();
	}

	//ids are now invalid if they are made solely of sequences repeated *at least* twice
	//e.g. 123123123, 11111, etc.
	//I think we need to check the prime-peats: i.e.
	//- is it a 2-peat? such as 123123
	//- is it a 3-peat? such as 123123123
	//- is it a 5-peat? such as 1212121212
	//- is it a 7-peat? such as 7777777
	//(Our max input id is 10 digits long, so no need to check for >7-peats. 
	protected override long SolvePart2()
	{
		var ranges = InputReader.ReadLine().Split(',');
		var invalidIds = new HashSet<long>();

		var invalidRegex = new Regex(@"^(\d+?)\1+$");

		var rangeEnds = new string[2];
		var rangeEndIds = new long[2];
		foreach (var range in ranges)
		{
			rangeEnds = [.. range.Split("-")];

			rangeEndIds = [.. rangeEnds.Select(long.Parse)];

			for (long id = rangeEndIds[0]; id <= rangeEndIds[1]; id++)
			{
				if (invalidRegex.IsMatch(id.ToString()))
				{
					invalidIds.Add(id);
				}
			}
		}
		return invalidIds.Sum();
	}
}