namespace AoC25.Tests.Day7;

using AoC25.Day7;

using Shared.Util;

public class SolutionTests
{
	Solution _sut;
	IInputReader _realInput = new InputFileReader(@"Day7/realInput.txt");

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
		_sut.Draw = true;
		var expectedAnswer = 21;
		var actualAnswer = _sut.GetPart1Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	[Test]
	public void TestPart1_RealInput()
	{
		_sut = new Solution(_realInput);

		var expectedAnswer = 1622;
		var actualAnswer = _sut.GetPart1Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	//[Test]
	//public void TestPart2()
	//{
	//	var expectedAnswer = 3263827;
	//	var actualAnswer = _sut.GetPart2Answer();
	//	Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	//}

	//[Test]
	//public void TestPart2_RealInput()
	//{
	//	_sut = new Solution(_realInput);

	//	var expectedAnswer = 10600728112865;
	//	var actualAnswer = _sut.GetPart2Answer();
	//	Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	//}
}