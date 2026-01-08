using AdventOfCode2023.Day5;

using FluentAssertions.Execution;

using Shared.Util;

namespace AdventOfCode2023.Tests.Day5;

public class SolutionTests
{
	//(i)
	// Map each seed value through each map to find its location. Return the minimum.
	// Expected answer: 35
	//
	//(ii)
	// This time the seed line is seed *ranges*. First val of each pair is the start val, the second is the range length. 
	// This time we've got to consider every seed in each range. 
	// Expected answer: 46
	readonly string _testInput =
		"seeds: 79 14 55 13\r\n" +
		"\r\n" +
		"seed-to-soil map:\r\n" +
		"50 98 2\r\n" +
		"52 50 48\r\n" +
		"\r\n" +
		"soil-to-fertilizer map:\r\n" +
		"0 15 37\r\n" +
		"37 52 2\r\n" +
		"39 0 15\r\n" +
		"\r\n" +
		"fertilizer-to-water map:\r\n" +
		"49 53 8\r\n" +
		"0 11 42\r\n" +
		"42 0 7\r\n" +
		"57 7 4\r\n" +
		"\r\n" +
		"water-to-light map:\r\n" +
		"88 18 7\r\n" +
		"18 25 70\r\n" +
		"\r\n" +
		"light-to-temperature map:\r\n" +
		"45 77 23\r\n" +
		"81 45 19\r\n" +
		"68 64 13\r\n" +
		"\r\n" +
		"temperature-to-humidity map:\r\n" +
		"0 69 1\r\n" +
		"1 0 69\r\n" +
		"\r\n" +
		"humidity-to-location map:\r\n" +
		"60 56 37\r\n" +
		"56 93 4\r\n" +
		"\r\n";

	ulong _expectedPart1ExampleAnswer = 35;
	ulong _expectedPart2ExampleAnswer = 46;

	InputStringReader? _reader;

	[SetUp]
	public void SetUp()
	{
		_reader = new InputStringReader(_testInput);
	}

	#region Part1

	[Test]
	public void TestRangedMap()
	{
		var exampleSeedToSoilMapInput = new string[]
		{
			"50 98 2",
			"52 50 3"
		};

		var expectedMappings = new (ulong, ulong)[]
		{
			(1, 1),
			(2, 2),
			(3, 3),
			//...
			(49, 49),
			(50, 52),
			(51, 53),
			(52, 54),
			(53, 53),
			//...
			(97, 97),
			(98, 50),
			(99, 51),
			(100, 100),
		};

		var map = new RangedMap(exampleSeedToSoilMapInput);

		using (new AssertionScope())
		{
			foreach (var mapping in expectedMappings)
			{
				map.GetDestination(mapping.Item1).Should().Be(mapping.Item2);
			}
		}
	}

	[Test]
	public void TestPart1Example()
	{
		var actualAnswer = new Solution(_reader).GetPart1Answer();

		actualAnswer.Should().Be(_expectedPart1ExampleAnswer);
	}

	[Test]
	public void TestPart1()
	{
		var expectedAnswer = 178159714ul;

		var actualAnswer = new Solution().GetPart1Answer();

		actualAnswer.Should().Be(expectedAnswer);
	}

	#endregion
	#region Part2

	[Test]
	[Ignore("TODO")]
	public void TestPart2Example()
	{
		var actualAnswer = new Solution(_reader).GetPart2Answer();

		actualAnswer.Should().Be(_expectedPart2ExampleAnswer);
	}

	[Test]
	public void TestPart2()
	{
		//var expectedAnswer = TODO;

		//var actualAnswer = new Solution().GetPart2Answer();

		//actualAnswer.Should().Be(expectedAnswer);
	}

	#endregion
}