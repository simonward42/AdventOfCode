using System.IO;

namespace AdventOfCode {
	public static class Day3 {

		/// <summary>
		/// Part1: Today we're counting trees as we toboggan down the slope (input)
		/// at a specific angle: right 3 down 1 (the slope wraps right-left).
		/// </summary>
		/// <param name="part"></param>
		/// <returns>The number of trees (#) we hit.</returns>
		public static int SolvePart1() {

			int treeCounter = 0;
			string line;
			StreamReader puzzleInput = null;

			try {
				puzzleInput = new StreamReader("../../../Day3/input.txt");
				var position = 0;
				while ((line = puzzleInput.ReadLine()) != null) {
					treeCounter += (line[position] == '#') ? 1 : 0;
					position = (position + 3) % line.Length;
				}
			}
			finally {
				puzzleInput.Close();
			}

			return treeCounter;
		}

		/// Part2: Find the product of the # of trees encountered for various slopes:
		/// * r1, d1
		/// * r3, d1
		/// * r5, d1
		/// * r7, d1
		/// * r1, d2
		public static int SolvePart2() {
			var slope1 = TraverseSlopeAndCountTrees(right: 1, down: 1);
			var slope2 = TraverseSlopeAndCountTrees(right: 3, down: 1);
			var slope3 = TraverseSlopeAndCountTrees(right: 5, down: 1);
			var slope4 = TraverseSlopeAndCountTrees(right: 7, down: 1);
			var slope5 = TraverseSlopeAndCountTrees(right: 1, down: 2);

			return slope1 * slope2 * slope3 * slope4 * slope5;
		}

		private static int TraverseSlopeAndCountTrees(int right, int down) {
			int treeCounter = 0;
			string line;
			StreamReader puzzleInput = null;

			try {
				puzzleInput = new StreamReader("../../../Day3/input.txt");
				var horiz = 0;
				var vert = 0;

				while ((line = puzzleInput.ReadLine()) != null) {

					if (vert % down == 0) {
						treeCounter += (line[horiz] == '#') ? 1 : 0;
						horiz = (horiz + right) % line.Length;
					}

					vert++;
				}
			}
			finally {
				puzzleInput.Close();
			}

			return treeCounter;
		}
	}
}
