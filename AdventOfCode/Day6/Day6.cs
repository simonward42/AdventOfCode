
using System;
using System.IO;
using System.Linq;

namespace AdventOfCode {
	public class Day6 : IDisposable {

		private StreamReader _PuzzleInput;
		private const string _InputPath = "../../../Day6/input.txt";

		public Day6() {
			_PuzzleInput = new StreamReader(_InputPath);
		}

		public void Dispose() {
			_PuzzleInput.Close();
		}


		/// <summary>
		/// Find the number of questions answered "yes" by anyone in each group, and sum them.
		/// </summary>
		/// <returns></returns>
		public int Solve() {

			var line = _PuzzleInput.ReadLine();
			int currentGroupSum, sumOfGroups = 0;

			while (line != null) {
				currentGroupSum = GetGroupSum(line);
				sumOfGroups += currentGroupSum;

				line = _PuzzleInput.ReadLine();
			}

			return sumOfGroups;
		}

		/// <summary>
		/// Find the number of questions answered "yes" by everyone in each group, and sum them.
		/// </summary>
		/// <returns></returns>
		public int SolvePart2() {

			var line = _PuzzleInput.ReadLine();
			int currentGroupCount, sumOfCounts = 0;

			while (line != null) {
				currentGroupCount = GetGroupCount(line);
				sumOfCounts += currentGroupCount;

				line = _PuzzleInput.ReadLine();
			}

			return sumOfCounts;
		}

		/// <summary>
		/// Sum of letters which appear on each line until empty line.
		/// </summary>
		/// <param name="line"></param>
		/// <returns></returns>
		private int GetGroupCount(string line) {

			var lines = "";
			var lineCount = 0;

			while (!string.IsNullOrWhiteSpace(line)) {
				lines += line;
				lineCount++;
				line = _PuzzleInput.ReadLine();
			}

			return lines
				.Where(x => lines.Count(y => y == x) == lineCount)
				.Distinct()
				.Count();
		}

		/// <summary>
		/// Sum of distinct letters in this and subsequent lines until empty line.
		/// </summary>
		/// <param name="line"></param>
		/// <returns></returns>
		private int GetGroupSum(string line) {

			var lines = "";

			while (!string.IsNullOrWhiteSpace(line)) {
				lines += line;
				line = _PuzzleInput.ReadLine();
			}

			return lines.Distinct().Count();
		}

		public void RefreshInput() {
			_PuzzleInput.Close();
			_PuzzleInput = new StreamReader(_InputPath);
		}

	}
}
