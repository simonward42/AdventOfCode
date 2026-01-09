namespace AoC25.Tests.Day1;

using AoC25.Day1;

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
		var expectedAnswer = 3;
		var actualAnswer = _sut.GetPart1Answer();
		actualAnswer.Should().Be(expectedAnswer);
	}

	[Test]
	public void TestPart2()
	{
		//var expectedAnswer = 3;
		//var actualAnswer = _sut.GetPart2Answer();
		//actualAnswer.Should().Be(expectedAnswer);
	}
}