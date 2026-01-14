namespace Shared.Util;

public static class StringExtensions
{
	public static IEnumerable<int> GetDigits(this string currentLine)
	{
		return currentLine
			.Where(char.IsDigit)
			.Select(x => int.Parse(x.ToString()));
	}

	public static bool HasEvenLength(this string str)
	{
		return str.Length % 2 == 0;
	}

	public static bool HasOddLength(this string str)
	{
		return !str.HasEvenLength();
	}
}
