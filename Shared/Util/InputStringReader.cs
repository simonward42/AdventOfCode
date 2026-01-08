namespace Shared.Util;

public class InputStringReader : InputTextReader, IInputReader
{
	private readonly string _input;
	private StringReader _reader;

	protected override TextReader Reader => _reader;

	public InputStringReader(string input)
	{
		_reader = new StringReader(input);
		_input = input;
	}

	public override void Rewind()
	{
		_reader.Dispose();
		_reader = new StringReader(_input);
	}
}
