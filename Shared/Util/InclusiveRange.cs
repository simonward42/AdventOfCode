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

	public InclusiveRange<T> MergeAll(IEnumerable<InclusiveRange<T>> rangesToMerge)
	{
		if (!rangesToMerge.Any())
		{
			return this;
		}

		if (!rangesToMerge.All(r => r.Overlaps(this)))
		{
			throw new InvalidOperationException("Cannot merge ranges that do not overlap");
		}

		var toMerge = rangesToMerge.Concat([this]);

		var mergedMin = toMerge.Select(x => x.Min).Min();
		var mergedMax = toMerge.Select(x => x.Max).Max();

		return new InclusiveRange<T>(mergedMin, mergedMax);
	}

	public override bool Equals(object? obj)
	{
		if (obj is not InclusiveRange<T> compareRange)
			return false;

		return Min == compareRange.Min
			&& Max == compareRange.Max;
	}

	public override int GetHashCode()
	{
		return Min.GetHashCode() ^ Max.GetHashCode();
	}

	public override string ToString()
	{
		return $"{Min}-{Max}";
	}
}
