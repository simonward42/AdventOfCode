namespace AoC25.Tests.Day10;

using AoC25.Day10;

using Shared.Util;

public class SolutionTests
{
	const string _exampleFirstLine = "[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}";
	const string _exampleSecondLine = "[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}";
	const string _exampleThirdLine = "[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}";
	Solution _sut;
	IInputReader _realInput = new InputFileReader(@"Day10/realInput.txt");

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
	public void Repeat()
	{
		var repeated = Enumerable.Repeat<List<int>>([0, 1], 3);

		int[] range = [0, 1];
		var expected = new[] {
			range,
			range,
			range,
		};

		Assert.That(repeated, Is.EquivalentTo(expected));
	}

	[Test]
	public void CartesianProduct()
	{
		//# product('ABCD', 'xy') → Ax Ay Bx By Cx Cy Dx Dy
		//# product(range(2), repeat=3) → 000 001 010 011 100 101 110 111

		char[] abcd = ['A', 'B', 'C'];
		char[] xy = ['x', 'y'];
		IEnumerable<IEnumerable<char>> sequences = [abcd, xy];

		IEnumerable<IEnumerable<char>> expectedProduct = [['A', 'x'], ['A', 'y'], ['B', 'x'], ['B', 'y'], ['C', 'x'], ['C', 'y']];
		Assert.That(sequences.CartesianProduct(), Is.EqualTo(expectedProduct));

		//---

		int[] bit = [0, 1];
		var threeBits = Enumerable.Repeat(bit, 3);

		IEnumerable<IEnumerable<int>> expected = [
			[0, 0, 0],
			[0, 0, 1],
			[0, 1, 0],
			[0, 1, 1],
			[1, 0, 0],
			[1, 0, 1],
			[1, 1, 0],
			[1, 1, 1]];

		Assert.That(threeBits.CartesianProduct(), Is.EqualTo(expected));
	}


	[Test]
	public void CartesianProduct_with_repeat()
	{
		int[] bit = [0, 1];

		IEnumerable<IEnumerable<int>> expected = [
			[0, 0, 0],
			[0, 0, 1],
			[0, 1, 0],
			[0, 1, 1],
			[1, 0, 0],
			[1, 0, 1],
			[1, 1, 0],
			[1, 1, 1]];

		Assert.That(bit.CartesianProduct(repeat: 3), Is.EqualTo(expected));

	}

	[Test]
	public void TestPart1_FirstLine()
	{
		_sut = new Solution(new InputStringReader(_exampleFirstLine));
		var expectedAnswer = 2;
		var actualAnswer = _sut.GetPart1Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	[Test]
	public void TestPart1_SecondLine()
	{
		_sut = new Solution(new InputStringReader(_exampleSecondLine));
		var expectedAnswer = 3;
		var actualAnswer = _sut.GetPart1Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	[Test]
	public void TestPart1_ThirdLine()
	{
		_sut = new Solution(new InputStringReader(_exampleThirdLine));
		var expectedAnswer = 2;
		var actualAnswer = _sut.GetPart1Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	[Test]
	public void TestPart1()
	{
		var expectedAnswer = 7;
		var actualAnswer = _sut.GetPart1Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	[Test]
	public void TestPart1_RealInput()
	{
		_sut = new Solution(_realInput);

		var expectedAnswer = 477;
		var actualAnswer = _sut.GetPart1Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}


	[Test]
	public void TestPart2_FirstLine()
	{
		_sut = new Solution(new InputStringReader(_exampleFirstLine));
		var expectedAnswer = 10;
		var actualAnswer = _sut.GetPart2Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	[Test]
	public void TestPart2_SecondLine()
	{
		_sut = new Solution(new InputStringReader(_exampleSecondLine));
		var expectedAnswer = 12;
		var actualAnswer = _sut.GetPart2Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	[Test]
	public void TestPart2_ThirdLine()
	{
		_sut = new Solution(new InputStringReader(_exampleThirdLine));
		var expectedAnswer = 11;
		var actualAnswer = _sut.GetPart2Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	[Test]
	public void TestPart2()
	{
		var expectedAnswer = 33;
		var actualAnswer = _sut.GetPart2Answer();
		Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	}

	//[Test]
	//[CancelAfter(0)]
	//[Explicit] // takes ~1min to execute
	//public void TestPart2_RealInput()
	//{
	//	_sut = new Solution(_realInput);

	//	var expectedAnswer = 1562459680;
	//	var actualAnswer = _sut.GetPart2Answer();
	//	Assert.That(actualAnswer, Is.EqualTo(expectedAnswer));
	//}
}