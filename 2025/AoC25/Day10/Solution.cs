namespace AoC25.Day10;

using System.Text.RegularExpressions;

using Shared.Util;

public class Solution(IInputReader? reader = null) : Puzzle<int>(10, reader)
{
	protected override int SolvePart1()
	{
		int sumOfBest = 0;
		while (InputReader.TryReadLine(out string? currentLine))
		{
			int[] t; //target light state
			int l; //number of lights
			int b; //number of buttons

			var input = currentLine.Split(' ');

			//target parse
			t = _ParseTarget(input);
			l = t.Length;

			//buttons parse
			var buttons = _ParseButtons(l, input);
			b = buttons.Length;

			//solving
			//construct button matrix from button vectors
			int[,] mB = buttons.ToRectangular();

			//solving linear algebra equation: (mB.p)mod2=t 
			//where:
			//  mB is button matrix
			//  p is the press vector (0 or 1 presses for each button i.e. column vector of length b where elements are [0,1])
			//  t is the target light state vector (on/off for each light i.e. column vector of length l where elems are [0,1])

			//we will brute force by constructing every possible press vector
			//for each p that solves the equation, count the number of presses => sum its elements
			//return the smallest of these sums => the smallest number of presses that reaches the target state

			//1. generate the set of press vector possibilities
			//each button can be pressed 0 or 1 times: more than 1 press is redundant as 2 presses is the same as 0, i.e. we're working mod 2
			//the press vectors are the Cartesian product of b [0,1] vectors
			var pCandidates = Enumerable.Range(0, 2) //[0,1]
				.CartesianProduct(repeat: b)
				.Skip(1) //first element is 0 presses which will never be the solution
				.Select(p => p.ToArray());

			//2. for each candidate p that satisfies the equation, find the least number of presses, i.e. lowest sum of elements
			//NB addition mod 2 is equivalent to XOR:
			//x+ymod2 = x^y
			int? best = null;
			foreach (var p in pCandidates)
			{
				//early skip: no need to check for solution if presses are already worse
				var presses = p.Sum();
				if (best != null && presses >= best)
					continue;

				//Does p solve?
				var solves = true; //until proven otherwise...
				for (int r = 0; r < l && solves; r++)
				{
					int sum = 0;

					for (int c = 0; c < b; c++)
					{
						sum ^= mB[c, r] * p[c]; //I think I'm needing to transpose the matrix here: [c,r] rather than [r,c] but I might be crazy
					}

					if (sum != t[r])
						solves = false;
				}

				if (solves)
					best = presses; //already would have skipped if presses > best, so p must be best
			}
			sumOfBest += best!.Value;
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