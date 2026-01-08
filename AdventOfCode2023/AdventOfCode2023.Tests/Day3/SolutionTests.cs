using System.Text.RegularExpressions;

using AdventOfCode2023.Day3;

using Shared.Util;

namespace AdventOfCode2023.Tests.Day3;

public class SolutionTests
{
	//(i)
	// In this schematic, two numbers are not part numbers because they are not adjacent to a symbol:
	// 114 (top right) and 58 (middle right).
	// Every other number is adjacent to a symbol and so is a part number; their sum is 4361.
	//
	//(ii)
	// In this schematic, there are two gears: top left, with part numbers 467 & 35, so its gear ratio is 467*35=16345.
	// The second is in the lower right with ratio 451490. The sum of ratios is 467835.
	readonly string _testInput =
		"467..114..\r\n" +
		"...*......\r\n" +
		"..35..633.\r\n" +
		"......#...\r\n" +
		"617*......\r\n" +
		".....+.58.\r\n" +
		"..592.....\r\n" +
		"......755.\r\n" +
		"...$.*....\r\n" +
		".664.598..";

	InputStringReader? _reader;

	[SetUp]
	public void SetUp()
	{
		_reader = new InputStringReader(_testInput);
	}

	#region Part1

	[Test]
	public void TestPartNumberParsing()
	{
		var expectedPartNumberSum = 4361;
		var partNumbers = new Solution(_reader).FindPartNumbers();

		partNumbers.Sum().Should().Be(expectedPartNumberSum);
	}

	[Test]
	public void TestRegexMatches()
	{
		var testString = "$.617*..12..+.";
		var numberRegexStr = @"(\d+)"; //one or more digits
		var symbolRegexStr = @"([^\d.])"; //not digit or period

		var numberRegex = new Regex(numberRegexStr);
		var symbolRegex = new Regex(symbolRegexStr);

		var numberMatches = numberRegex.Matches(testString);
		var symbolMatches = symbolRegex.Matches(testString);

		numberMatches.Count.Should().Be(2);
		symbolMatches.Count.Should().Be(3);

		numberMatches[0].Value.Should().Be("617");
		numberMatches[0].Index.Should().Be(2);

		numberMatches[1].Value.Should().Be("12");
		numberMatches[1].Index.Should().Be(8);
	}

	[Test]
	public void TestPart1()
	{
		var expectedAnswer = 533775;

		var actualAnswer = new Solution().GetPart1Answer();

		actualAnswer.Should().Be(expectedAnswer);
	}

	#endregion
	#region Part2

	[Test]
	public void TestGearRatioParsing()
	{
		var expectedGearRatioSum = 467835;
		var gearRatios = new Solution(_reader).FindGearRatios();

		gearRatios.Sum().Should().Be(expectedGearRatioSum);
	}

	[Test]
	public void TestPart2()
	{
		var expectedAnswer = 78236071;

		var actualAnswer = new Solution().GetPart2Answer();

		actualAnswer.Should().Be(expectedAnswer);
	}

	#endregion
}