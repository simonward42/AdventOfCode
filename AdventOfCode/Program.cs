﻿using System;

namespace AdventOfCode {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("Hello World!");

			bool quit;

			do {
				var dayChoice = AskForInput(out quit);
				if (quit) {
					continue;
				}

				PrintSolution(dayChoice);
			}
			while (!quit);

		}

		static int AskForInput(out bool quit) {

			string choiceString;
			quit = false;

			Console.WriteLine("Which day's solution would you like to run? Type a number from 1 - 25...");
			Console.WriteLine("Alternatively, type Q to quit");
			Console.WriteLine("...or try X for fun bonus stuff!");

			choiceString = Console.ReadLine();
			if (string.Equals(choiceString, "Q", StringComparison.CurrentCultureIgnoreCase)) {
				quit = true;
				return 0;
			}

			if (string.Equals(choiceString, "X", StringComparison.CurrentCultureIgnoreCase)) {
				return 99;
			}

			int.TryParse(choiceString, out int choiceDay);

			while (choiceDay < 1 || choiceDay > 25) {
				Console.WriteLine("\nSorry, didn't quite catch that; please enter a number between 1 and 25 (inclusive)...");
				Console.WriteLine("Or type Q to quit (X for fun stuff!)");

				choiceString = Console.ReadLine();
				if (string.Equals(choiceString, "Q", StringComparison.CurrentCultureIgnoreCase)) {
					quit = true;
					return 0;
				}
				int.TryParse(choiceString, out choiceDay);
			}

			return choiceDay;
		}

		static void PrintSolution(int day) {
			switch (day) {
				case 1:
					Console.WriteLine("\nSolving Day 1....");
					Console.WriteLine($"Solution to part 1: {Day1.SolvePart1()}\n");
					Console.WriteLine($"Solution to part 2: {Day1.SolvePart2()}\n");
					break;

				case 2:
					Console.WriteLine("\nSolving Day 2....");
					Console.WriteLine($"Solution to part 1: {Day2.Solve(1)}\n");
					Console.WriteLine($"Solution to part 2: {Day2.Solve(2)}\n");
					break;

				case 3:
					Console.WriteLine("\nSolving Day 3....");
					Console.WriteLine($"Solution to part 1: {Day3.SolvePart1()}\n");
					Console.WriteLine($"Solution to part 2: {Day3.SolvePart2()}\n");
					break;

				case 4:
					Console.WriteLine("\nSolving Day 4....");

					var day4 = new Day4();
					Console.WriteLine($"Solution to part 1: {day4.Solve(1)}\n");

					day4.RefreshInput();
					Console.WriteLine($"Solution to part 2: {day4.Solve(2)}\n");
					break;

				case 5:
					Console.WriteLine("\nSolving Day 5....");

					var day5 = new Day5();
					Console.WriteLine($"Solution to part 1: {day5.Solve()}\n");

					day5.RefreshInput();
					Console.WriteLine($"Solution to part 2: {day5.SolvePart2()}\n");
					break;

				case 6:
					Console.WriteLine("\nSolving Day 6....");

					var day6 = new Day6();
					Console.WriteLine($"Solution to part 1: {day6.Solve()}\n");

					day6.RefreshInput();
					Console.WriteLine($"Solution to part 2: {day6.SolvePart2()}\n");
					break;

				case 7:
					Console.WriteLine("\nSolving Day 7....");

					var day7 = new Day7();
					Console.WriteLine($"Solution to part 1: {day7.Solve()}\n");

					day7.RefreshInput();
					Console.WriteLine($"Solution to part 2: {day7.SolvePart2()}\n");
					break;

				case 99:
					Console.WriteLine("\nDoing custom fun stuff....");

					var quiz = new Quiz();
					Console.WriteLine($"Number of occurrences of \"make it so\" in all of TNG: {quiz.FindInTng("make it so")}");
					
					quiz = new Quiz();
					Console.WriteLine($"Number of occurrences of \"earl grey\" in all of TNG: {quiz.FindInTng("earl grey")}");

					quiz = new Quiz();
					Console.WriteLine($"Number of occurrences of \"earl grey hot\" in all of TNG: {quiz.FindInTng("earl grey hot")}");

					quiz = new Quiz();
					Console.WriteLine($"Number of occurrences of \"tea earl grey hot\" in all of TNG: {quiz.FindInTng("tea earl grey hot")}");

					quiz = new Quiz();
					Console.WriteLine($"Number of occurrences of \"shut up\" in all of TNG: {quiz.FindInTng("shut up")}");

					quiz = new Quiz();
					Console.WriteLine($"Number of occurrences of \"shut up wesley\" in all of TNG: {quiz.FindInTng("shut up wesley")}");

					break;

				default:
					break;
			}
		}
	}
}
