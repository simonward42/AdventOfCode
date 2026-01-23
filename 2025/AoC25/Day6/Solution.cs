namespace AoC25.Day6;

using System.Text.RegularExpressions;

using Shared.Util;

public class Solution(IInputReader? reader = null) : Puzzle<long>(6, reader)
{
	//input is vertically aligned operands (ints) followed by an operator (+ or *),
	//goal is to sum the results of all operations
	protected override long SolvePart1()
	{
		var lines = InputReader.ReadUntilEmptyLine();

		var operatorRx = new Regex(@"([+*]+)+");
		var operandRx = new Regex(@"(\d+)+");

		var operators = operatorRx.Matches(lines.Last())
			.Select(x => x.Value)
			.ToArray();

		var operands = lines[..(lines.Length - 1)]
			.Select(x => operandRx.Matches(x)
				.Select(y => long.Parse(y.Value)).ToArray())
			.ToArray();

		long resultSum = 0;
		for (var i = 0; i < operators.Length; i++)
		{
			resultSum += operators[i] switch
			{
				"+" => operands.Select(x => x[i]).Sum(),
				"*" => operands.Select(x => x[i]).Aggregate((a, b) => a * b),
				_ => throw new NotImplementedException()
			};
		}

		return resultSum;
	}

	//description
	protected override long SolvePart2()
	{
		while (InputReader.TryReadLine(out string? currentLine))
		{

		}

		return 0;
	}
}