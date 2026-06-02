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
			List<int[]> buttons = [];
			int l; //number of lights
			int b; //number of buttons

			var input = currentLine.Split(' ');

			//target parse
			l = _ParseTarget(out target, input);

			//buttons parse
			b = _ParseButtons(buttons, l, input);
		}

		return sumOfBest;
	}

	private static int _ParseButtons(List<int[]> buttons, int l, string[] input)
	{
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
		return buttons.Count;
	}

	private static int _ParseTarget(out int[] target, string[] input)
	{
		var targetRegex = new Regex(@"\[([.#]+)\]");

		var match = targetRegex.Match(input.First());
		target = [.. match.Groups[1].Value.Select(c => c == '#' ? 1 : 0)];

		return target.Length;
	}

	protected override int SolvePart2()
	{
		while (InputReader.TryReadLine(out string? currentLine))
		{

		}

		return 0;
	}
}