namespace Shared.Util;

using System.Numerics;

public class InclusiveRange<T> where T : IBinaryInteger<T>
{
	public T Min { get; set; } = T.Zero;
	public T Max { get; set; } = T.Zero;

	public InclusiveRange() { }

	public InclusiveRange(T min, T max)
	{
		Min = min;
		Max = max;
	}

	public bool Contains(T testValue)
	{
		return Min <= testValue && testValue <= Max;
	}

	public T Size => Max - Min + T.One;

	public bool Overlaps(InclusiveRange<T> testRange)
	{
		return testRange.Contains(Min)
			|| testRange.Contains(Max)
			|| this.Contains(testRange.Min)
			|| this.Contains(testRange.Max);
	}

	public InclusiveRange<T> Merge(InclusiveRange<T> rangeToMerge)
	{
		if (!this.Overlaps(rangeToMerge))
		{
			throw new InvalidOperationException("Cannot merge ranges that do not overlap");
		}

		var mergedMin = Min < rangeToMerge.Min ? Min : rangeToMerge.Min;
		var mergedMax = Max > rangeToMerge.Max ? Max : rangeToMerge.Max;

		return new InclusiveRange<T>(mergedMin, mergedMax);
	}
}
