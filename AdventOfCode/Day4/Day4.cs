using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode {
	public class Day4 : IDisposable {

		private StreamReader _PuzzleInput;
		private List<string> _RequiredKeys = new List<string> {
			"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid",
		};

		private List<string> _ValidEyeColours = new List<string> {
			"amb", "blu", "brn", "gry", "grn", "hzl", "oth"
		};

		public Day4() {
			_PuzzleInput = new StreamReader("../../../Day4/input.txt");
		}

		public void Dispose() {
			_PuzzleInput.Close();
		}


		/// <summary>
		/// Find the number of valid "passports" in the batch file (input).
		/// Passports are made up of key-value pairs (e.g. byr:1969) and are separated by an empty line.
		/// Passports are valid if they contain all of the following 7 fields:
		/// byr, iyr, eyr, hgt, hcl, ecl, pid;
		/// they may also have an optional cid field. 
		/// 
		/// Part2 adds validation of the required fields' values. 
		/// </summary>
		/// <returns></returns>
		public int Solve(int part) {

			var validCount = 0;
			var passport = ParsePassport();

			while (passport.Count > 0) {
				if (IsPassportValid(passport, part)) {
					validCount++;
				}

				passport = ParsePassport();
			}

			return validCount;
		}

		private bool IsPassportValid(Dictionary<string, string> passport, int part) {
			var isValid = false;

			foreach (var reqKey in _RequiredKeys) {
				if (!passport.ContainsKey(reqKey)) {
					return false;
				}
			}

			if (part == 2) {
				foreach (var reqKey in _RequiredKeys) {
					if (!ValidateKeyValuePair(passport, reqKey)) {
						return false;
					}
				}
			}
			return true;
		}


		private bool ValidateKeyValuePair(Dictionary<string, string> passport, string keyToValidate) {
			var valToValidate = passport[keyToValidate];

			switch (keyToValidate) {
				case "byr":
					// byr (Birth Year) - four digits; at least 1920 and at most 2002.
					return ValidateYear(valToValidate, 1920, 2002);

				case "iyr":
					//	iyr (Issue Year) - four digits; at least 2010 and at most 2020.
					return ValidateYear(valToValidate, 2010, 2020);

				case "eyr":
					// eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
					return ValidateYear(valToValidate, 2020, 2030);

				case "hgt":
					// hgt (Height) - a number followed by either cm or in:
					// - If cm, the number must be at least 150 and at most 193.
					// - If in, the number must be at least 59 and at most 76.
					return ValidateHeight(valToValidate);

				case "hcl":
					// hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
					return ValidateHairColour(valToValidate);

				case "ecl":
					// ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
					return ValidateEyeColour(valToValidate);

				case "pid":
					// pid (Passport ID) - a nine-digit number, including leading zeroes.
					return ValidatePID(valToValidate);

				case "cid":
					// cid (Country ID) - ignored, missing or not.
					return true;

				default:
					return false;
			}
		}

		public void RefreshInput() {
			_PuzzleInput.Close();
			_PuzzleInput = new StreamReader("../../../Day4/input.txt");
		}

		private static bool ValidatePID(string valToValidate) {
			if (valToValidate.Length != 9) {
				return false;
			}
			if (!valToValidate.All(c => char.IsDigit(c))) {
				return false;
			}
			return true;
		}

		private bool ValidateEyeColour(string valToValidate) {
			if (_ValidEyeColours.Contains(valToValidate)) {
				return true;
			}
			return false;
		}

		private static bool ValidateHairColour(string valToValidate) {
			if (valToValidate[0] != '#') {
				return false;
			}
			if (valToValidate.Substring(1).Length != 6) {
				return false;
			}
			if (!valToValidate.Substring(1).All(c => char.IsLetterOrDigit(c))) {
				return false;
			}
			return true;
		}

		private static bool ValidateHeight(string valToValidate) {
			if (valToValidate.Length < 3) {
				return false;
			}
			var unit = valToValidate.Substring(valToValidate.Length - 2); // last 2 chars
			if (unit != "cm" && unit != "in") {
				return false;
			}
			var numberOfUnit = int.Parse(valToValidate.Substring(0, valToValidate.Length - 2));
			switch (unit) {
				case "cm":
					if (numberOfUnit < 150 || numberOfUnit > 193) {
						return false;
					}
					return true;

				case "in":
					if (numberOfUnit < 59 || numberOfUnit > 76) {
						return false;
					}
					return true;

				default:
					return false;
			}
		}

		private static bool ValidateYear(string valToValidate, int min, int max) {
			if (valToValidate.Length != 4) {
				return false;
			}
			if (!valToValidate.All(c => char.IsDigit(c))) {
				return false;
			}
			var year = int.Parse(valToValidate);
			if (year < min || year > max) {
				return false;
			}

			return true;
		}

		private Dictionary<string, string> ParsePassport() {
			var passport = new Dictionary<string, string>();

			string line = _PuzzleInput.ReadLine();

			while (line != null && line != string.Empty) {

				var splitBySpace = line.Split(' ');
				foreach (var keyValueString in splitBySpace) {
					var keyAndValue = keyValueString.Split(':');
					passport.Add(keyAndValue[0], keyAndValue[1]);
				}

				line = _PuzzleInput.ReadLine();
			}

			return passport;
		}
	}
}
