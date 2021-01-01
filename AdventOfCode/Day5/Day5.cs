using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode {
	public class Day5 : IDisposable {

		private StreamReader _PuzzleInput;
		private const string _InputPath = "../../../Day5/input.txt";

		public Day5() {
			_PuzzleInput = new StreamReader(_InputPath);
		}

		public void Dispose() {
			_PuzzleInput.Close();
		}


		/// <summary>
		/// Find the highest seat ID in the list of boarding passes.
		/// The first 7 chars denote the row number (0-127) using binary space partitioning.
		/// The final 3 chars do the same for the column (0-8).
		/// The ID = 8 * row + column.
		/// </summary>
		/// <returns></returns>
		public int Solve() {

			var line = _PuzzleInput.ReadLine();
			int row, col, currentId, largestId = 0;

			while (line != null) {
				row = ParseRow(line);
				col = ParseCol(line);
				currentId = 8 * row + col;

				largestId = currentId > largestId ? currentId : largestId;

				line = _PuzzleInput.ReadLine();
			}

			return largestId;
		}

		/// <summary>
		/// Find your seat ID, which will be missing from the list. 
		/// There are some seats missing from either end of the IDs, but 
		/// my seat will be the missing ID from which seats with IDs + 1 and - 1
		/// both exist in the list.
		/// </summary>
		/// <returns></returns>
		public int SolvePart2() {

			var allIds = new List<int>();

			for (int i = 0; i <= 127 * 8 + 7; i++) {
				allIds.Add(i);
			}

			int row, col, currentId;
			var idsFound = new List<int>();

			var line = _PuzzleInput.ReadLine();

			while (line != null) {
				row = ParseRow(line);
				col = ParseCol(line);
				currentId = 8 * row + col;

				idsFound.Add(currentId);

				line = _PuzzleInput.ReadLine();
			}

			var missingIds = allIds.Except(idsFound);

			// My ID will be the only missing id x where x - 1 and x + 2 aren't missing
			return missingIds.Where(id => !missingIds.Contains(id - 1) && !missingIds.Contains(id + 1))
				.Single();
		}

		/// <summary>
		/// e.g. RLR: R = upper half, L = lower;
		/// R: upper half = 4 - 7
		/// RL: lower half of upper half = 4 - 5
		/// RLR: the upper = 5.
		/// This is just binary wher R = 1 and L = 0:
		/// 101 (bin) = 5 (dec)
		/// </summary>
		/// <param name="line"></param>
		/// <returns></returns>
		private int ParseCol(string line) {
			var chars = line.Substring(line.Length - 3);

			var binString = chars
				.Replace('L', '0')
				.Replace('R', '1');

			return Convert.ToInt32(binString, fromBase: 2);
		}

		/// <summary>
		/// Just binary, where B = 1 and F = 0.
		/// </summary>
		/// <param name="line"></param>
		/// <returns></returns>
		private int ParseRow(string line) {
			var chars = line.Substring(0, line.Length - 3);

			var binString = chars
				.Replace('F', '0')
				.Replace('B', '1');

			return Convert.ToInt32(binString, fromBase: 2);
		}

		public void RefreshInput() {
			_PuzzleInput.Close();
			_PuzzleInput = new StreamReader(_InputPath);
		}

	}
}
