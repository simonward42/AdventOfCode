namespace AoC25.Tests.Day3;

using AoC25.Day3;

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
		var expectedAnswer = 357;
		var actualAnswer = _sut.GetPart1Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	[Test, Ignore("not implemented yet")]
	public void TestPart2()
	{
		//var expectedAnswer = 54446379122;
		//var actualAnswer = _sut.GetPart2Answer();
		//Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}
}