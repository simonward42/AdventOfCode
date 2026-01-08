namespace Shared.Util;

public static class StringExtensions
{
	public static IEnumerable<int> GetDigits(this string currentLine)
	{
		return currentLine
			.Where(char.IsDigit)
			.Select(x => int.Parse(x.ToString()));
	}
}
