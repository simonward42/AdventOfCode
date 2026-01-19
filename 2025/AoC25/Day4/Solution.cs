namespace AoC25.Day4;

using Shared.Util;

public class Solution(IInputReader? reader = null) : Puzzle<int>(4, reader)
{
	//count the number of paper rolls ('@') in the input with fewer than 4 rolls in the eight adjacent positions
	protected override int SolvePart1()
	{
		var rows = InputReader.ReadUntilEmptyLine();
		var accessibleRollsCount = 0;

		string row;
		for (var y = 0; y < rows.Length; y++)
		{
			row = rows[y];
			for (var x = 0; x < row.Length; x++)
			{
				if (row[x] == '@' && _AdjacentRollsCount(rows, x, y, row.Length) < 4)
				{
					accessibleRollsCount++;
				}
			}
		}

		return accessibleRollsCount;
	}

	private int _AdjacentRollsCount(string[] rows, int x, int y, int rowLength)
	{
		var rollsCount = 0;
		for (int j = y - 1; j <= y + 1; j++)
		{
			//handle edges
			if (j < 0 || j >= rows.Length) continue;

			for (int i = x - 1; i <= x + 1; i++)
			{
				//don't self-count
				if (i == x && j == y) continue;

				//handle edges
				if (i < 0 || i >= rowLength) continue;

				if (rows[j][i] == '@')
					rollsCount++;
			}
		}

		return rollsCount;
	}

	//description
	protected override int SolvePart2()
	{
		while (InputReader.TryReadLine(out string? currentLine))
		{

		}

		return 0;
	}
}