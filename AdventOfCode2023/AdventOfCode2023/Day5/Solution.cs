using System.Text.RegularExpressions;

using Shared;
using Shared.Util;

namespace AdventOfCode2023.Day5;

public partial class Solution : Puzzle<ulong>
{
	public const int day = 5;
	public Solution(IInputReader? reader = null) : base(day, reader)
	{
	}

	//hard to summarize... just read https://adventofcode.com/2023/day/5#part1 !
	protected override ulong SolvePart1()
	{
		//1. parse seeds to input into almanac later
		//2. parse maps into almanac's dictionaries
		//3. feed seeds through almanac to get locations
		//4. return minimum location

		var seedLine = InputReader.ReadLine();
		var seeds = _GetSeedsPart1(seedLine);

		_ = InputReader.ReadLine(); //throw away line break

		var almanac = new Almanac();

		_FillAlmanacMaps(almanac);

		var seedLocations = seeds.Select(almanac.GetLocationForSeed);

		return seedLocations.Min();
	}

	//Turns out we've got to consider seed *ranges* this time.
	//The seed input line consists of pairs: the seed range start followed by the range length. 
	//Considering every seed in all the ranges this time, again find the minimum mapped location...
	protected override ulong SolvePart2()
	{
		//Ranges are far too big to consider each seed individually.
		//We'll need to consider the range as a whole, and get the Almanac to return the min location for each range. 

		//1. parse seed ranges
		//2. build almanac as before
		//3. get min location for each range by being smart with the almanac 
		//4. return min location

		var seedLine = InputReader.ReadLine();
		var seeds = _GetSeedsPart2(seedLine);

		return 0;
	}

	private void _FillAlmanacMaps(Almanac almanac)
	{
		_ = InputReader.ReadLine(); //seed-to-soil map:
		var mapInput = InputReader.ReadUntilEmptyLine();
		almanac.InitializeMap(Almanac.MapType.SeedToSoil, mapInput);

		_ = InputReader.ReadLine(); //soil-to-fertilizer map:
		mapInput = InputReader.ReadUntilEmptyLine();
		almanac.InitializeMap(Almanac.MapType.SoilToFertilizer, mapInput);

		_ = InputReader.ReadLine(); //fertilizer-to-water map:
		mapInput = InputReader.ReadUntilEmptyLine();
		almanac.InitializeMap(Almanac.MapType.FertilizerToWater, mapInput);

		_ = InputReader.ReadLine(); //water-to-light map:
		mapInput = InputReader.ReadUntilEmptyLine();
		almanac.InitializeMap(Almanac.MapType.WaterToLight, mapInput);

		_ = InputReader.ReadLine(); //light-to-temperature map:
		mapInput = InputReader.ReadUntilEmptyLine();
		almanac.InitializeMap(Almanac.MapType.LightToTemperature, mapInput);

		_ = InputReader.ReadLine(); //temperature-to-humidity map:
		mapInput = InputReader.ReadUntilEmptyLine();
		almanac.InitializeMap(Almanac.MapType.TemperatureToHumidity, mapInput);

		_ = InputReader.ReadLine(); //humidity-to-location map:
		mapInput = InputReader.ReadUntilEmptyLine();
		almanac.InitializeMap(Almanac.MapType.HumidityToLocation, mapInput);
	}

	private static ulong[] _GetSeedsPart1(string seedLine)
	{
		var seedNumbers = seedLine.Split(':')[1].Trim();
		return seedNumbers.Split(' ').Select(ulong.Parse).ToArray();
	}

	private static RangedNumber<ulong>[] _GetSeedsPart2(string seedLine)
	{
		var pairRegex = new Regex(@"(\d+) (\d+)");
		var matches = pairRegex.Matches(seedLine);

		var seedRanges = matches.Select(s => new RangedNumber<ulong>(
			ulong.Parse(s.Groups[1].Value),
			ulong.Parse(s.Groups[2].Value)));

		return seedRanges.ToArray();
	}
}
