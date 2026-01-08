namespace Shared.Util;

public class InputFileReader : InputTextReader, IDisposable, IInputReader
{
	private readonly string _inputPath;
	private StreamReader _reader;

	protected override TextReader Reader => _reader;

	public InputFileReader(string inputPath)
	{
		_inputPath = inputPath;
		_reader = new StreamReader(_inputPath);
	}

	public override void Rewind()
	{
		_reader.Dispose();
		_reader = new StreamReader(_inputPath);
	}
}

