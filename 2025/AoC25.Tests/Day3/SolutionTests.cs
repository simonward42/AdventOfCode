namespace AoC25.Tests.Day3;

using AoC25.Day3;

using Shared.Util;

public class SolutionTests
{
	Solution _sut;
	IInputReader _realInput = new InputFileReader(@"Day3/realInput.txt");

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

	[OneTimeTearDown]
	public void OneTimeTearDown()
	{
		_realInput.Dispose();
	}

	[Test]
	public void TestPart1()
	{
		var expectedAnswer = 357;
		var actualAnswer = _sut.GetPart1Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	[Test]
	public void TestPart1_RealInput()
	{
		_sut = new Solution(_realInput);

		var expectedAnswer = 17244;
		var actualAnswer = _sut.GetPart1Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	[Test]
	public void TestPart2()
	{
		var expectedAnswer = 3121910778619;
		var actualAnswer = _sut.GetPart2Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	[Test]
	public void TestPart2_RealInput()
	{
		_sut = new Solution(_realInput);

		var expectedAnswer = 171435596092638;
		var actualAnswer = _sut.GetPart2Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}
}