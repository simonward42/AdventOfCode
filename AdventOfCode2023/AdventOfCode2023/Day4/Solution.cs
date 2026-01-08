using Shared;
using Shared.Util;

namespace AdventOfCode2023.Day4;

public partial class Solution : Puzzle<int>
{
	public const int day = 4;
	public Solution(IInputReader? reader = null) : base(day, reader)
	{
	}

	//Our input represents a pile of scratch cards, with each line representing a single card, e.g.:
	//"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53"
	//A card consists of two sets of numbers separated by a vertical bar '|':
	// set 1: the winning numbers for this card
	// set 2: the numbers you have to match against the winners.
	//A card's point value is determined by the number of winning numbers you have in your set:
	// 1 for the first match, doubled by each subsequent match. 
	//How many points is our pile of cards worth? 
	protected override int SolvePart1()
	{
		var pointSum = 0;
		while (InputReader.TryReadLine(out var currentLine))
		{
			var card = new ScratchCard(currentLine);
			pointSum += card.PointValue;
		}

		return pointSum;
	}

	//Turns out points don't mean anything; scratch cards just win you... more scratch cards. 
	//It goes like this:
	// if card 1 has *two* matching numbers, I win a copy of the next *two* cards, i.e. card 2 and card 3.
	// My *two* copies of card 2 have, say, one matching number, so I win another *two* copies of card 3, giving four copies of card 3 in total
	// ...and so on. 
	//After going through this process with our whole pile, how many scratch cards in total do we end up with?
	protected override int SolvePart2()
	{
		var originalCards = new List<ScratchCard>();
		while (InputReader.TryReadLine(out var currentLine))
		{
			originalCards.Add(new ScratchCard(currentLine));
		}

		var cardSets = originalCards.Select(c => new ScratchCardSet(c)).ToArray();

		for (int i = 0; i < cardSets.Length; i++)
		{
			var currentSet = cardSets[i];
			var matches = currentSet.ScratchCard.WinningMatches;

			//for each copy of the card in the current set, increment the count of the next {matches} sets
			for (int j = i + 1; j <= i + matches && j < cardSets.Length; j++)
			{
				cardSets[j].AddToSet(currentSet.Count);
			}
		}

		return cardSets.Select(s => s.Count).Sum();
	}
}
