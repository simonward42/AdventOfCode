using Shared.Util;

namespace AdventOfCode2023.Day3
{
	internal class SymbolPosition : Point2d
	{
		const char _gearSymbol = '*';

		public char Symbol { get; set; } = ' ';

		public bool IsGear => Symbol == _gearSymbol;
	}
}
