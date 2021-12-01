using System.IO;

namespace AoC2021 {
	public class Day1 {

		//Common stuff => inherit!
		private StreamReader _PuzzleInput;
		private const string _InputPath = "../../../Day1/input.txt";

		public Day1() {
			_PuzzleInput = new StreamReader(_InputPath);
		}

		//part1
		private int _DepthIncreaseCount = 0;

		public int Solve() {
			var currentDepth = GetNextDepthValue();
			var previousDepth = currentDepth; //So we don't count the first val

			while (currentDepth > 0) {
				if (currentDepth > previousDepth) {
					_DepthIncreaseCount++;
				}

				previousDepth = currentDepth;
				currentDepth = GetNextDepthValue();
			}

			return _DepthIncreaseCount;
		}
		//

		//part2
		private int _WindowSumIncreaseCount = 0;
		public int SolvePart2() {

			var buffer = new DepthBuffer();
			buffer.Push(GetNextDepthValue());
			buffer.Push(GetNextDepthValue());
			buffer.Push(GetNextDepthValue());

			var previousWindowSum = buffer.Sum();

			while (!buffer.Stop()) {
				if (buffer.Sum() > previousWindowSum) {
					_WindowSumIncreaseCount++;
				}

				previousWindowSum = buffer.Sum();

				buffer.Push(GetNextDepthValue());
			}

			return _WindowSumIncreaseCount;
		}
		//

		private int GetNextDepthValue() {
			var line = _PuzzleInput.ReadLine();

			if (line == null) {
				return -1;
			}

			return int.Parse(line);
		}

		class DepthBuffer {
			// first-in, first-out
			private int _Depth0;
			private int _Depth1;
			private int _Depth2;

			public void Push(int depth) {
				_Depth0 = _Depth1;
				_Depth1 = _Depth2;
				_Depth2 = depth;
			}

			public int Sum() {
				return _Depth0 + _Depth1 + _Depth2;
			}

			public bool Stop() {
				return _Depth2 == -1;
			}
		}
	}
}
