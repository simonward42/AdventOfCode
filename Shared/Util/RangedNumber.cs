namespace Shared.Util;

using System.Numerics;

public class RangedNumber<T> where T : IBinaryInteger<T>
{
	public T Value { get; set; } = T.Zero;
	public T Range { get; set; } = T.Zero;

	public RangedNumber() { }

	public RangedNumber(T value, T range)
	{
		Value = value;
		Range = range;
	}
}
