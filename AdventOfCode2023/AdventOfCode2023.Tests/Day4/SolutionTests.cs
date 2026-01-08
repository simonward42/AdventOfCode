using AdventOfCode2023.Day4;

using Shared.Util;

namespace AdventOfCode2023.Tests.Day4;

public class SolutionTests
{
	//(i)
	// In these examples, cards have five winning numbers and you have eight.
	// In card 1, four of our numbers are winning numbers, so it's worth 8 points
	// (1 for the first match, then doubled three times for each of the three remaining matches). 
	// The total number of points for this pile of cards is 13. 
	//
	//(ii)
	// ...
	readonly string _testInput =
		"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53\r\n" +
		"Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19\r\n" +
		"Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1\r\n" +
		"Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83\r\n" +
		"Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36\r\n" +
		"Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11";

	int _expectedPointTotal = 13;

	InputStringReader? _reader;

	[SetUp]
	public void SetUp()
	{
		_reader = new InputStringReader(_testInput);
	}

	#region Part1

	private static IEnumerable<(string, ScratchCard)> _CtorCases()
	{
		yield return (
			"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
			new ScratchCard(id: 1, winningNumbers: new[] { 41, 48, 83, 86, 17 }, yourNumbers: new[] { 83, 86, 6, 31, 17, 9, 48, 53 })
		);

		yield return (
			"Card   12: 34  6 |  9 14  3 34",
			new ScratchCard(id: 12, winningNumbers: new[] { 34, 6 }, yourNumbers: new[] { 9, 14, 3, 34 })
		);
	}

	[Test]
	[TestCaseSource(nameof(_CtorCases))]
	public void TestScratchCardCtor((string cardInput, ScratchCard expectedCard) testCase)
	{
		var card = new ScratchCard(testCase.cardInput);

		card.Should().BeEquivalentTo(testCase.expectedCard);
	}

	// examples from https://adventofcode.com/2023/day/4#part1
	private static IEnumerable<(string, int)> _PointValueCases()
	{
		yield return ("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 8);
		yield return ("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2);
		yield return ("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 2);
		yield return ("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", 1);
		yield return ("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 0);
		yield return ("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 0);
	}

	[Test]
	[TestCaseSource(nameof(_PointValueCases))]
	public void TestScratchCardPointValue((string cardInput, int expectedPointVal) testCase)
	{
		var card = new ScratchCard(testCase.cardInput);

		card.PointValue.Should().Be(testCase.expectedPointVal);
	}

	[Test]
	public void TestPart1()
	{
		var expectedAnswer = 17803;

		var actualAnswer = new Solution().GetPart1Answer();

		actualAnswer.Should().Be(expectedAnswer);
	}

	#endregion
	#region Part2

	[Test]
	public void TestPart2()
	{
		var expectedAnswer = 5554894;

		var actualAnswer = new Solution().GetPart2Answer();

		actualAnswer.Should().Be(expectedAnswer);
	}

	#endregion
}