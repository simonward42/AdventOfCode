namespace AoC25.Tests.Day2;

using AoC25.Day2;

public class SolutionTests
{
	Solution _sut;

	[SetUp]
	public void Setup()
	{
		_sut = new Solution();
	}

	[TearDown]
	public void TearDown()
	{
		_sut.Dispose();
	}

	[Test]
	public void TestPart1()
	{
		var expectedAnswer = 1227775554;
		var actualAnswer = _sut.GetPart1Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	[Test]
	public void TestPart2()
	{
		var expectedAnswer = 4174379265;
		var actualAnswer = _sut.GetPart2Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}
}