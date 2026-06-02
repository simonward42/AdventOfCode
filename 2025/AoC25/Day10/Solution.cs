namespace AoC25.Day10;

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
		while (InputReader.TryReadLine(out string? currentLine))
		{

		}

		return 0;
	}

	protected override int SolvePart2()
	{
		while (InputReader.TryReadLine(out string? currentLine))
		{

		}

		return 0;
	}
}