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
			b = buttons.Length;

			//solving
			//construct button matrix from button vectors
			int[,] mB = buttons.ToRectangular();

			//solving linear algebra equation: (mB.p)mod 2 = t,
			//where:
			//  mB is button matrix
			//  p is the press vector (0 or 1 presses for each button i.e. column vector of length b where elements are [0,1])
			//  t is the target light state vector (on/off for each light i.e. column vector of length l where elems are [0,1])

			//we will brute force by constructing every possible press vector
			//for each p that solves the equation, count the number of presses => sum its elements
			//return the smallest of these sums => the smallest number of presses that reaches the target state
		}

		return sumOfBest;
	}

	private static int[][] _ParseButtons(int l, string[] input)
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
		return buttons.ToArray();
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