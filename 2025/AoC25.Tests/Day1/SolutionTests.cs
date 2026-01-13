namespace AoC25.Tests.Day1;

using AoC25.Day1;

public class SolutionTests
{
	Solution _sut;

	[SetUp]
	public void Setup()
	{
		_sut = new Solution();
		Dial.Verbose = true;
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
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	[Test]
	public void TestPart2()
	{
		var expectedAnswer = 6;
		var actualAnswer = _sut.GetPart2Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}


	[Test]
	public void sdlkfjsfd()
	{
		Console.WriteLine(10.01 % 10);
	}
}