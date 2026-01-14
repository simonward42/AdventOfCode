namespace Shared.Tests.Util;

using Shared.Util;

public class Tests
{
	[TestCase("hi")]
	[TestCase("yes!")]
	[TestCase("12345678")]
	public void LengthChecks_WhenEven(string test)
	{
		Assert.That(test.HasEvenLength(), Is.True);
		Assert.That(test.HasOddLength(), Is.False);
	}

	[TestCase("123456789")]
	[TestCase("nah")]
	public void LengthChecks_WhenOdd(string test)
	{
		Assert.That(test.HasEvenLength(), Is.False);
		Assert.That(test.HasOddLength(), Is.True);
	}
}
