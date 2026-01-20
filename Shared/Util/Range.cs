namespace Shared.Util;

using System.Numerics;

public class Range<T> where T : IBinaryInteger<T>
{
	public T Min { get; set; } = T.Zero;
	public T Max { get; set; } = T.Zero;

	public Range() { }

	public Range(T min, T max)
	{
		Min = min;
		Max = max;
	}

	public bool ContainsInclusive(T testValue)
	{
		return Min <= testValue && testValue <= Max;
	}
}
