namespace AoC25.Tests.Day5;

using AoC25.Day5;

using Shared.Util;

public class SolutionTests
{
	Solution _sut;
	IInputReader _realInput = new InputFileReader(@"Day5/realInput.txt");

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
		var expectedAnswer = 3;
		var actualAnswer = _sut.GetPart1Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	[Test]
	public void TestPart1_RealInput()
	{
		_sut = new Solution(_realInput);

		var expectedAnswer = 607;
		var actualAnswer = _sut.GetPart1Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	//[Test]
	//public void TestPart2()
	//{
	//	var expectedAnswer = 43;
	//	var actualAnswer = _sut.GetPart2Answer();
	//	Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	//}

	//[Test]
	//public void TestPart2_RealInput()
	//{
	//	_sut = new Solution(_realInput);

	//	var expectedAnswer = 8707;
	//	var actualAnswer = _sut.GetPart2Answer();
	//	Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	//}
}