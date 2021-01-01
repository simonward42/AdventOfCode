
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode {
	public class Day7 : IDisposable {

		private StreamReader _PuzzleInput;
		private const string _InputPath = "../../../Day7/input.txt";

		private const string _CanContainShinyGoldRegEx = @".*\d shiny gold.*\.";
		private List<string> _BagsHaveChecked = new List<string>();

		public Day7() {
			_PuzzleInput = new StreamReader(_InputPath);
		}

		public void Dispose() {
			_PuzzleInput.Close();
		}

		/// <summary>
		/// How many bag colors can eventually contain at least one shiny gold bag?
		/// </summary>
		/// <returns></returns>
		public int Solve() {
			return FindBagsCanContain("shiny gold");
		}

		private int FindBagsCanContain(string startingBag) {

			var currentBagRegEx = @".*\d " + startingBag + @".*\.";
			var bagsCanContainCurrentBag = new List<string>();

			RefreshInput();
			var line = _PuzzleInput.ReadLine();

			while (line != null) {
				if (Regex.IsMatch(line, currentBagRegEx)) {
					var bagArray = line.Split(" ").Take(2);
					var bag = string.Join(" ", bagArray);

					if (!_BagsHaveChecked.Contains(bag)) {
						_BagsHaveChecked.Add(bag);
						bagsCanContainCurrentBag.Add(bag);
					}
				}

				line = _PuzzleInput.ReadLine();
			}

			var canEventuallyContainCurrentBagCount = bagsCanContainCurrentBag.Count;
			foreach (var bag in bagsCanContainCurrentBag) {
				canEventuallyContainCurrentBagCount += FindBagsCanContain(bag);
			}

			return canEventuallyContainCurrentBagCount;
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
