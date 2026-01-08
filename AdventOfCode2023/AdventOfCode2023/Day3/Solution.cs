using System.Text.RegularExpressions;

using Shared;
using Shared.Util;

namespace AdventOfCode2023.Day3;

public partial class Solution : Puzzle<int>
{
	public Solution(IInputReader? reader = null) : base(3, reader)
	{
	}

	//Input is a representation of an engine schematic, consisting of numbers, symbols (e.g. '*', '$'), separated by periods '.'.
	//A number represents a *part number* if it is adjacent (even diagonally) to a symbol.
	//Find the sum of all part numbers in the schematic. 
	protected override int SolvePart1()
	{
		return FindPartNumbers().Sum();
	}

	//def(i) A *gear* is any '*' adjacent to exactly two part numbers. 
	//def(ii) Its *gear ratio* is the result of multiplying those two numbers together.
	//Find the gear ratio of every gear in the schematic and return the sum. 
	protected override int SolvePart2()
	{
		return FindGearRatios().Sum();
	}

	internal IReadOnlyCollection<int> FindGearRatios()
	{
		(var symbolPositions, var numberPositions) = _ParseSchematic();

		var ratios = new List<int>();

		foreach (var symbolLine in symbolPositions)
		{
			var line = symbolLine.Key;
			var gearSymbols = symbolLine.Value.Where(symbol => symbol.IsGear);
			if (!gearSymbols.Any()) continue;

			var adjacentNumberLines = new List<NumberPosition>();
			for (int i = -1; i <= 1; i++)
			{
				if (numberPositions.TryGetValue(line + i, out var numberLine))
				{
					adjacentNumberLines.AddRange(numberLine);
				}
			}

			foreach (var gearSymbol in gearSymbols)
			{
				var adjacentParts = adjacentNumberLines
					.Where(n => n.Adjacent(gearSymbol))
					.Select(n => n.Value);

				if (adjacentParts.Count() == 2) // gears are adjacent to exactly 2 parts
				{
					ratios.Add(adjacentParts.Aggregate((a, b) => a * b));
				}
			}
		}

		return ratios;
	}

	internal IReadOnlyCollection<int> FindPartNumbers()
	{
		(var symbolPositions, var numberPositions) = _ParseSchematic();

		return _FindNumbersAdjacentToSymbols(numberPositions, symbolPositions);
	}

	private (Dictionary<int, List<SymbolPosition>>, Dictionary<int, List<NumberPosition>>) _ParseSchematic()
	{
		var symbolPositions = new Dictionary<int /*line number*/, List<SymbolPosition>>();
		var numberPositions = new Dictionary<int /*line number*/, List<NumberPosition>>();
		var lineNumber = 0;
		while (InputReader.TryReadLine(out string? currentLine))
		{
			symbolPositions[lineNumber] = new List<SymbolPosition>();
			numberPositions[lineNumber] = new List<NumberPosition>();

			symbolPositions[lineNumber].AddRange(_ParseSymbols(lineNumber, currentLine));
			numberPositions[lineNumber].AddRange(_ParseNumbers(lineNumber, currentLine));

			lineNumber++;
		}
		return (symbolPositions, numberPositions);
	}

	private IReadOnlyCollection<int> _FindNumbersAdjacentToSymbols(
		Dictionary<int, List<NumberPosition>> numberPositions,
		Dictionary<int, List<SymbolPosition>> symbolPositions)
	{
		var numbersAdjacentSymbol = new List<int>();
		foreach (var numberLine in numberPositions)
		{
			var symbolPositionsForAdjacentLines = new List<SymbolPosition>();
			for (int i = -1; i <= 1; i++)
			{
				if (symbolPositions.TryGetValue(numberLine.Key + i, out var symbolLine))
				{
					symbolPositionsForAdjacentLines.AddRange(symbolLine);
				}
			}

			numbersAdjacentSymbol
				.AddRange(numberLine.Value
					.Where(number => symbolPositionsForAdjacentLines
						.Any(symbol => number.Adjacent(symbol)
					))
					.Select(number => number.Value));
		}

		return numbersAdjacentSymbol;
	}

	[GeneratedRegex(@"([^\d.])")] //neither a digit or a period
	private static partial Regex _symbolRegex();

	private IEnumerable<SymbolPosition> _ParseSymbols(int lineNumber, string currentLine)
	{
		var symbolMatches = _symbolRegex().Matches(currentLine);

		return symbolMatches.Select(symbol => new SymbolPosition
		{
			Symbol = symbol.Value[0],
			X = symbol.Index,
			Y = lineNumber
		});
	}

	[GeneratedRegex(@"(\d+)")] //one or more digit
	private static partial Regex _NumberRegex();

	private IEnumerable<NumberPosition> _ParseNumbers(int lineNumber, string currentLine)
	{
		var numberMatches = _NumberRegex().Matches(currentLine);

		return numberMatches.Select(number => new NumberPosition
		{
			Value = int.Parse(number.Value),
			X = number.Index,
			Y = lineNumber
		});
	}
}
