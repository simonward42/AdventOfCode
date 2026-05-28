namespace AoC25.Tests.Day9;

using AoC25.Day9;

using Shared.Util;

public class SolutionTests
{
	Solution _sut;
	IInputReader _realInput = new InputFileReader(@"Day9/realInput.txt");

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
		var expectedAnswer = 50;
		var actualAnswer = _sut.GetPart1Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	[Test]
	public void TestPart1_RealInput()
	{
		_sut = new Solution(_realInput);

		var expectedAnswer = 4741451444;
		var actualAnswer = _sut.GetPart1Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	[Test]
	public void TestPart2()
	{
		var expectedAnswer = 24;
		var actualAnswer = _sut.GetPart2Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	//[Test]
	//public void TestPart2_RealInput()
	//{
	//	_sut = new Solution(_realInput);
	//	_sut.Verbose = true;

	//	var expectedAnswer = 100011612;
	//	var actualAnswer = _sut.GetPart2Answer();
	//	Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	//}
}