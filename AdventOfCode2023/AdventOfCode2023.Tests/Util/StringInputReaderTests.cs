using FluentAssertions.Execution;

using Shared.Util;

namespace AdventOfCode2023.Tests.Util;

public class StringInputReaderTests
{
	readonly string _testInput =
		$"first line\r\n" +
		$"second line";

	readonly string[] _expectedLines = new string[]
	{
		"first line",
		"second line"
	};

	InputStringReader _sut;

	[SetUp]
	public void SetUp()
	{
		_sut = new InputStringReader(_testInput);
	}

	[Test]
	public void TestTryReadLine()
	{
		var firstLineRead = _sut.TryReadLine(out var firstLine);
		firstLineRead.Should().BeTrue();
		firstLine.Should().Be(_expectedLines[0]);

		var secondLineRead = _sut.TryReadLine(out var secondLine);
		secondLineRead.Should().BeTrue();
		secondLine.Should().Be(_expectedLines[1]);

		var thirdLineRead = _sut.TryReadLine(out var thirdLine);
		thirdLineRead.Should().BeFalse();
		thirdLine.Should().BeNull();
	}

	[Test]
	public void TestRewind()
	{
		_ = _sut.TryReadLine(out var firstLine);

		_sut.Rewind();

		_ = _sut.TryReadLine(out var nextLine);
		nextLine.Should().Be(firstLine);
	}

	[Test]
	public void TestReadLine()
	{
		var firstRead = _sut.ReadLine();
		var secondRead = _sut.ReadLine();
		var thirdRead = _sut.ReadLine();

		using (new AssertionScope())
		{
			firstRead.Should().Be(_expectedLines[0]);
			secondRead.Should().Be(_expectedLines[1]);
			thirdRead.Should().BeNull();
		}
	}
}