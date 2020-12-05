using System.IO;
using System.Linq;

namespace AdventOfCode {
	public static class Day2 {

		public static int Solve(int part) {

			int validCounter = 0;
			string line;
			StreamReader puzzleInput = null;

			try {
				puzzleInput = new StreamReader("../../../Day2/input.txt");
				while ((line = puzzleInput.ReadLine()) != null) {
					if (part == 1) {
						if (IsPasswordValidForPart1(line)) {
							validCounter++;
						}
					}
					else if (part == 2) {
						if (IsPasswordValidForPart2(line)) {
							validCounter++;
						}
					}
				}
			}
			finally {
				puzzleInput.Close();
			}

			return validCounter;
		}

		/// <summary>
		/// Find the number of valid passwords in the input file. 
		/// Each line of the input starts with the policy at the time, followed by the password.
		/// Example: 1-3 b: cdefg
		/// This is invalid as cdefg does not contain between 1 and 3 'b's.
		/// </summary>
		/// <returns>The number of valid passwords</returns>
		private static bool IsPasswordValidForPart1(string line) {
			int requiredCharMin;
			int requiredCharMax;
			char requiredChar;
			string password;

			var splitOnSpace = line.Split(' ');

			var minAndMax = splitOnSpace[0].Split('-');
			requiredCharMin = int.Parse(minAndMax[0]);
			requiredCharMax = int.Parse(minAndMax[1]);

			requiredChar = splitOnSpace[1][0];
			password = splitOnSpace[2];

			var requiredCharOccurrences = password
				.Where(c => c == requiredChar)
				.Count();

			return requiredCharMin <= requiredCharOccurrences && requiredCharOccurrences <= requiredCharMax;
		}

		/// <summary>
		/// Find the number of valid passwords in the input file. 
		/// Each line of the input starts with the policy at the time, followed by the password.
		/// Example: 1-3 b: cdefg
		/// This is invalid as cdefg does not contain exactly 1 'b' in either the 1 and 3 positions (no index zero!).
		/// </summary>
		/// <returns>The number of valid passwords</returns>
		public static bool IsPasswordValidForPart2(string line) {
			int requiredPosition1;
			int requiredPosition2;

			var splitOnSpace = line.Split(' ');

			var positions = splitOnSpace[0].Split('-');
			requiredPosition1 = int.Parse(positions[0]);
			requiredPosition2 = int.Parse(positions[1]);

			var arrayPosition1 = requiredPosition1 - 1;
			var arrayPosition2 = requiredPosition2 - 1;

			var requiredChar = splitOnSpace[1][0];
			var password = splitOnSpace[2];

			var isInPosition1 = password[arrayPosition1] == requiredChar;
			var isInPosition2 = password[arrayPosition2] == requiredChar;

			return isInPosition1 ^ isInPosition2;
		}




	}
}
