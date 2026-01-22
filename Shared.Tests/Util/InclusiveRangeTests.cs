namespace Shared.Tests.Util;

using Shared.Util;

public class InclusiveRangeTests
{
	[Test]
	public void Contains_IsTrue_WhenTestValueIsWithinRangeLimits()
	{
		var testRange = new InclusiveRange<int>(1, 10);

		for (int i = 1; i <= 10; i++)
		{
			Assert.That(testRange.Contains(i), Is.True);
		}
	}

	[Test]
	public void Contains_IsFalse_WhenTestValueIsOutsideRangeLimits()
	{
		var testRange = new InclusiveRange<int>(1, 10);

		var outsideVals = new int[] { -3, -2, -1, 0, 11, 12, 13 };

		foreach (var i in outsideVals)
		{
			Assert.That(testRange.Contains(i), Is.False);
		}
	}

	[Test]
	public void Overlaps_IsTrue_WhenRangesOverlap_And_WorksBothWays()
	{
		var testRange = new InclusiveRange<int>(1, 10);

		var overlappingRanges = new InclusiveRange<int>[]
		{
			new(8, 15), // overlaps upper bound of testRange
			new(-5, 5), // overlaps lower bound of testRange
			new(-5, 15), //range contains all of testRange
		};

		foreach (var range in overlappingRanges)
		{
			Assert.That(testRange.Overlaps(range), Is.True);
			Assert.That(range.Overlaps(testRange), Is.True);
		}
	}

	[Test]
	public void Overlaps_IsFalse_WhenRangesDoNotOverlap_And_WorksBothWays()
	{
		var testRange = new InclusiveRange<int>(1, 10);

		var nonOverlappingRanges = new InclusiveRange<int>[]
		{
			new(11, 15), // above upper bound of testRange
			new(-5, 0), // below lower bound of testRange
		};

		foreach (var range in nonOverlappingRanges)
		{
			Assert.That(testRange.Overlaps(range), Is.False);
			Assert.That(range.Overlaps(testRange), Is.False);
		}
	}

	[Test]
	public void Merge_ThrowsErrorWhenRangesDoNotOverlap()
	{
		var rangeA = new InclusiveRange<int>(1, 10);
		var rangeB = new InclusiveRange<int>(11, 15);

		Assert.That(() => rangeA.Merge(rangeB),
			Throws.InstanceOf<InvalidOperationException>());
	}

	[TestCaseSource(nameof(MergeTestCases))]
	public InclusiveRange<int> Merge_ReturnsCombinedRange_OfOverlappingRanges(
		InclusiveRange<int> rangeA,
		InclusiveRange<int> rangeB)
	{
		return rangeA.Merge(rangeB);
	}

	public static IEnumerable<TestCaseData> MergeTestCases
	{
		get
		{
			yield return new TestCaseData(
				new InclusiveRange<int>(2, 6),
				new InclusiveRange<int>(4, 9))
				.Returns(new InclusiveRange<int>(2, 9));

			yield return new TestCaseData(
				new InclusiveRange<int>(2, 6),
				new InclusiveRange<int>(-3, 5))
				.Returns(new InclusiveRange<int>(-3, 6));

			yield return new TestCaseData(
				new InclusiveRange<int>(2, 6),
				new InclusiveRange<int>(1, 7))
				.Returns(new InclusiveRange<int>(1, 7));
		}
	}

	[Test]
	public void MergeAll_ReturnsRangeWithMinimumMin_AndMaximumMax()
	{
		var rangeA = new InclusiveRange<int>(1, 10);
		var rangeB = new InclusiveRange<int>(-10, 5);
		var rangec = new InclusiveRange<int>(6, 15);

		var expectedRange = new InclusiveRange<int>(-10, 15);

		Assert.That(() => rangeA.MergeAll([rangeB, rangec]),
			Is.EqualTo(expectedRange));
	}
}
