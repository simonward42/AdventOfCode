using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Shared.Util;

public interface IInputReader : IDisposable
{
	bool TryReadLine([NotNullWhen(true)] out string? line);
	void Rewind();

	/// <exception cref="EndOfInputException">Thrown when attempting to read when at the end of the input</exception>
	string ReadLine();

	/// <summary>
	/// Reads lines from the input until the first empty line is encountered.
	/// Does *not* expect to reach the end of the input. 
	/// </summary>
	/// <exception cref="EndOfInputException">Thrown when the end of the input is reached before an empty line</exception>
	string[] ReadUntilEmptyLine();
}

[Serializable]
internal class EndOfInputException : Exception
{
	public EndOfInputException()
	{
	}

	public EndOfInputException(string? message) : base(message)
	{
	}

	public EndOfInputException(string? message, Exception? innerException) : base(message, innerException)
	{
	}

	protected EndOfInputException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
	}
}