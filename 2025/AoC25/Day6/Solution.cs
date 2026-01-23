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
		var lines = InputReader.ReadUntilEmptyLine();
		var operatorRx = new Regex(@"([+*]+)+");
		var operators = operatorRx.Matches(lines.Last())
			.Select(x => x.Value)
			.ToArray();

		//parse operands...
		//for each operator we have a variable-length list of int operands
		var operands = new List<long>[operators.Length];
		var opIx = operands.Length - 1;
		operands[opIx] = [];

		for (var i = lines[0].Length - 1; i >= 0; i--)
		{
			var opString = "";

			foreach (var line in lines[..(lines.Length - 1)])
			{
				opString += line[i];
			}

			if (opString.IsWhiteSpace())
			{
				opIx--;
				operands[opIx] = [];
			}
			else
			{
				operands[opIx].Add(long.Parse(opString));
			}
		}

		long resultSum = 0;
		for (var i = 0; i < operators.Length; i++)
		{
			resultSum += operators[i] switch
			{
				"+" => operands[i].Sum(),
				"*" => operands[i].Aggregate((a, b) => a * b),
				_ => throw new NotImplementedException()
			};
		}

		return resultSum;
	}
}