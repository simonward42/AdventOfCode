namespace AoC25.Tests.Day8;

using AoC25.Day8;

using Shared.Util;

public class SolutionTests
{
	Solution _sut;
	IInputReader _realInput = new InputFileReader(@"Day8/realInput.txt");

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
		_sut.JunctionsToConnect = 10;
		var expectedAnswer = 40;
		var actualAnswer = _sut.GetPart1Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	[Test]
	public void TestPart1_RealInput()
	{
		_sut = new Solution(_realInput);

		var expectedAnswer = 102816;
		var actualAnswer = _sut.GetPart1Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	//[Test]
	//public void TestPart2()
	//{
	//	_sut.Draw = true;
	//	var expectedAnswer = 40;
	//	var actualAnswer = _sut.GetPart2Answer();
	//	Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	//}

	//[Test]
	//public void TestPart2_RealInput()
	//{
	//	_sut = new Solution(_realInput);

	//	var expectedAnswer = 10357305916520;
	//	var actualAnswer = _sut.GetPart2Answer();
	//	Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	//}
}