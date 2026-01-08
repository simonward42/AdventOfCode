using System.Text.RegularExpressions;

using Shared;

namespace AdventOfCode2023.Day2;

public class Solution : Puzzle<int>
{
	public Solution() : base(2)
	{
	}
	private int _solutionPart1 = 0;
	private int _solutionPart2 = 0;

	private const int _maxR = 12;
	private const int _maxG = 13;
	private const int _maxB = 14;

	//Input line format:
	//Game {ID}: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
	//separated by ';' handfuls of coloured cubes grabbed from the bag
	//need to find the IDs of the games that would be possible if there were certain numbers of each colour (given by the maxRed, maxGreen and maxBlue fields)
	//return the sum of the possible IDs.
	protected override int SolvePart1()
	{
		while (InputReader.TryReadLine(out string? currentLine))
		{
			var game = ParseGame(currentLine);

			if (game.IsPossible(_maxR, _maxG, _maxB))
			{
				_solutionPart1 += game.Id;
			}
		}

		return _solutionPart1;
	}

	//For each game:
	//def(i) the 'minimum set': the minimum set of cubes the bag would need to contain to make the game possibe, e.g. for
	//Game {ID}: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
	//the minumum set = {4 red, 2 green, 6 blue}
	//
	//def(ii) the 'power' of a set = red * green * blue
	//
	//find the powers of the minimum sets for each game, and return their sum.
	protected override int SolvePart2()
	{
		while (InputReader.TryReadLine(out string? currentLine))
		{
			var game = ParseGame(currentLine);

			_solutionPart2 += game.PowerOfMinimumSet;
		}
		return _solutionPart2;
	}

	internal static Game ParseGame(string gameLine)
	{
		var game = new Game();

		//get Id
		var idRegex = new Regex(@"Game (\d+):");
		var idMatch = idRegex.Match(gameLine);
		game.Id = int.Parse(idMatch.Groups[1].Value);

		//split string into rounds
		var roundsStr = gameLine.Split(':')[1];
		var rounds = roundsStr.Split(';');

		foreach (var roundStr in rounds)
		{
			var round = new Round
			{
				Red = _GetRed(roundStr),
				Green = _GetGreen(roundStr),
				Blue = _GetBlue(roundStr),
			};

			game.Rounds.Add(round);
		}

		return game;
	}

	private static int _GetRed(string roundStr)
	{
		var redRegex = new Regex(@"(\d+) red");
		var redMatch = redRegex.Match(roundStr);
		return redMatch.Success
			? int.Parse(redMatch.Groups[1].Value)
			: 0;
	}

	private static int _GetGreen(string roundStr)
	{
		var redRegex = new Regex(@"(\d+) green");
		var redMatch = redRegex.Match(roundStr);
		return redMatch.Success
			? int.Parse(redMatch.Groups[1].Value)
			: 0;
	}

	private static int _GetBlue(string roundStr)
	{
		var redRegex = new Regex(@"(\d+) blue");
		var redMatch = redRegex.Match(roundStr);
		return redMatch.Success
			? int.Parse(redMatch.Groups[1].Value)
			: 0;
	}
}
