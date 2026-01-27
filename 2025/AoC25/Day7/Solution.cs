namespace AoC25.Day7;

using Shared.Util;

public partial class Solution(IInputReader? reader = null) : Puzzle<long>(7, reader)
{
	public bool Draw { get; set; } = false;

	//how many beam splitters are hit?
	//OR, how many beams terminate on a splitter?
	protected override long SolvePart1()
	{
		var space = InputReader.ReadAs2dCharArray();
		var field = new TachyonField(space);

		field.Propagate();

		if (Draw)
		{
			field.Draw();
		}

		return field.SplitCount;
	}

	//path integral (sort of?)
	protected override long SolvePart2()
	{
		var space = InputReader.ReadAs2dCharArray();
		var field = new TachyonField(space);

		field.Propagate();

		if (Draw)
		{
			field.Draw();
		}

		return field.SumAmplitude(y: space.Length - 1);
	}
}