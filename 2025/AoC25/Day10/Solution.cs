namespace AoC25.Day10;

using System.Text.RegularExpressions;

using Shared.Util;

public class Solution(IInputReader? reader = null) : Puzzle<int>(10, reader)
{
	/*
	 from itertools import product

	def brute_force_min(A, b):
		n = len(A[0])
		best = None

		for x in product([0,1], repeat=n):
			if all(
				sum(A[r][c] * x[c] for c in range(n)) % 2 == b[r]
				for r in range(len(A))
			):
				presses = sum(x)
				if best is None or presses < best:
					best = presses

		return best
	 */
	protected override int SolvePart1()
	{
		int sumOfBest = 0;
		while (InputReader.TryReadLine(out string? currentLine))
		{
			int[] target; //target light state
			int l; //number of lights
			int b; //number of buttons

			var input = currentLine.Split(' ');

			//target parse
			target = _ParseTarget(input);
			l = target.Length;

			//buttons parse
			var buttons = _ParseButtons(l, input);
			b = buttons.Count;
		}

		return sumOfBest;
	}

	private static List<int[]> _ParseButtons(int l, string[] input)
	{
		List<int[]> buttons = [];

		var buttonWords = input[1..(input.Length - 1)];
		foreach (var buttonWord in buttonWords)
		{
			var indices = buttonWord
				.Trim('(', ')')
				.Split(',')
				.Select(int.Parse)
				.ToHashSet();

			buttons.Add(Enumerable
				.Range(0, l)
				.Select(i => indices.Contains(i) ? 1 : 0)
				.ToArray());
		}
		return buttons;
	}

	private static int[] _ParseTarget(string[] input)
	{
		var targetRegex = new Regex(@"\[([.#]+)\]");

		var match = targetRegex.Match(input.First());
		return [.. match.Groups[1].Value.Select(c => c == '#' ? 1 : 0)];
	}

	protected override int SolvePart2()
	{
		while (InputReader.TryReadLine(out string? currentLine))
		{

		}

		return 0;
	}
}