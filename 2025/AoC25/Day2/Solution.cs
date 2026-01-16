
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
				if (_IsATwoPeat(id.ToString()))
				{
					invalidIds.Add(id);
				}
			}
		}

		//Console.WriteLine(string.Join("\n", ranges));
		return invalidIds.Sum();
	}

	/// <summary>
	/// By 2-peat I mean a sequence repeated e.g. 123123 
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	private static bool _IsATwoPeat(string idStr)
	{
		//invalid IDs all have an even number of digits
		if (idStr.HasOddLength())
			return false;

		var firstHalf = idStr[..(idStr.Length / 2)];
		var secondHalf = idStr[(idStr.Length / 2)..];
		//Console.WriteLine($"{idStr}: {firstHalf} {secondHalf}");
		return firstHalf == secondHalf;
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

		var rangeEnds = new string[2];
		var rangeEndIds = new long[2];
		foreach (var range in ranges)
		{
			rangeEnds = [.. range.Split("-")];

			rangeEndIds = [.. rangeEnds.Select(long.Parse)];

			for (long id = rangeEndIds[0]; id <= rangeEndIds[1]; id++)
			{
				var idStr = id.ToString();
				if (_IsATwoPeat(idStr) || _IsAThreePeat(idStr) || _IsAFivePeat(idStr) || _IsASevenPeat(idStr))
				{
					invalidIds.Add(id);
				}
			}
		}

		return invalidIds.Sum();
	}

	private static bool _IsAThreePeat(string idStr)
	{
		if (idStr.Length % 3 != 0)
			return false;

		var thirdLen = idStr.Length / 3;

		var firstThird = idStr[..thirdLen];
		var secondThird = idStr[thirdLen..(2 * thirdLen)];
		var thirdThird = idStr[(2 * thirdLen)..];

		return (firstThird == secondThird)
			&& (secondThird == thirdThird);
	}

	private static bool _IsAFivePeat(string idStr)
	{
		if (idStr.Length % 5 != 0)
			return false;

		var fifthLen = idStr.Length / 5;

		var firstFifth = idStr[..fifthLen];
		var secondFifth = idStr[fifthLen..(2 * fifthLen)];
		var thirdFifth = idStr[(2 * fifthLen)..(3 * fifthLen)];
		var fourthFifth = idStr[(3 * fifthLen)..(4 * fifthLen)];
		var fifthFifth = idStr[(4 * fifthLen)..];

		return (firstFifth == secondFifth)
			&& (secondFifth == thirdFifth)
			&& (thirdFifth == fourthFifth)
			&& (fourthFifth == fifthFifth);
	}

	private static bool _IsASevenPeat(string idStr)
	{
		if (idStr.Length % 7 != 0)
			return false;

		var seventhLen = idStr.Length / 7;

		var firstSeventh = idStr[..seventhLen];
		var secondSeventh = idStr[seventhLen..(2 * seventhLen)];
		var thirdSeventh = idStr[(2 * seventhLen)..(3 * seventhLen)];
		var fourthSeventh = idStr[(3 * seventhLen)..(4 * seventhLen)];
		var fifthSeventh = idStr[(4 * seventhLen)..(5 * seventhLen)];
		var sixthSeventh = idStr[(5 * seventhLen)..(6 * seventhLen)];
		var sevenSeventh = idStr[(6 * seventhLen)..];

		return (firstSeventh == secondSeventh)
			&& (firstSeventh == thirdSeventh)
			&& (firstSeventh == fourthSeventh)
			&& (firstSeventh == fifthSeventh)
			&& (firstSeventh == sixthSeventh)
			&& (firstSeventh == sevenSeventh);
	}
}