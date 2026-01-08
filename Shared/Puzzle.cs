namespace Shared;

using Shared.Util;

public abstract class Puzzle<TAnswer> : IDisposable
{
	const string _inputFile = "input.txt";
	readonly int _day;

	public IInputReader InputReader;

	public Puzzle(int day, IInputReader? reader = null)
	{
		_day = day;

		if (reader == null)
		{
			_day = day;
			var inputPath = $"Day{_day}/{_inputFile}";
			InputReader = new InputFileReader(inputPath);
		}
		else
		{
			InputReader = reader;
		}
	}

	public string SolvePretty()
	{
		TAnswer part1 = GetPart1Answer();
		TAnswer part2 = GetPart2Answer();

		return $"+++ Day {_day}\n" +
			$"---- Part 1: {part1}\n" +
			$"---- Part 2: {part2}\n";
	}

	public TAnswer GetPart1Answer()
	{
		InputReader.Rewind();
		return SolvePart1();
	}

	public TAnswer GetPart2Answer()
	{
		InputReader.Rewind();
		return SolvePart2();
	}

	protected abstract TAnswer SolvePart1();
	protected abstract TAnswer SolvePart2();

	public void Dispose()
	{
		InputReader.Dispose();
		GC.SuppressFinalize(this);
	}
}