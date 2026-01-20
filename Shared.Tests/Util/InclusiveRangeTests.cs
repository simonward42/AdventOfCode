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
	public void Merge_TODO()
	{
		var rangeA = new InclusiveRange<int>(1, 10);
		var rangeB = new InclusiveRange<int>(5, 15);

		var merged = rangeA.Merge(rangeB);

		Assert.That(merged.Min, Is.EqualTo(1));
		Assert.That(merged.Max, Is.EqualTo(15));
	}

	[Test]
	public void Merge_TODO_2()
	{
		var rangeA = new InclusiveRange<int>(1, 10);
		var rangeB = new InclusiveRange<int>(-5, 15);

		var merged = rangeA.Merge(rangeB);

		Assert.That(merged.Min, Is.EqualTo(-5));
		Assert.That(merged.Max, Is.EqualTo(15));
	}
}
