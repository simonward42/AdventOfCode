namespace AoC25.Day8;

using System.Linq;

using Shared.Util;

public class Solution(IInputReader? reader = null) : Puzzle<int>(8, reader)
{
	public int JunctionsToConnect = 1000;

	//description
	protected override int SolvePart1()
	{
		var junctionBoxes = new List<JunctionBox>();
		while (InputReader.TryReadLine(out string? line))
		{
			junctionBoxes.Add(new JunctionBox(new Point3d(line)));
		}

		var pairDistances = new Dictionary<double, (JunctionBox, JunctionBox)>();

		var exclude = new List<JunctionBox>();
		foreach (var box1 in junctionBoxes)
		{
			exclude.Add(box1);
			foreach (var box2 in junctionBoxes.Except(exclude))
			{
				var box1To2 = box1.Position.Distance(box2.Position);
				pairDistances.Add(box1To2, (box1, box2));
			}
		}

		var circuits = new List<Circuit>();
		var boxStack = new Stack<(JunctionBox, JunctionBox)>(
			pairDistances
				.OrderByDescending(x => x.Key)
				.Select(x => x.Value));
		Circuit? circuit1;
		Circuit? circuit2;
		for (int i = 0; i < JunctionsToConnect; i++)
		{
			var (box1, box2) = boxStack.Pop();
			circuit1 = box1.Circuit;
			circuit2 = box2.Circuit;

			Console.WriteLine($"connection {i + 1}: {box1.Position} and {box2.Position}");

			//if directly connected, continue
			//if (box1.Connections.Contains(box2))
			//{
			//	Console.WriteLine("already connected");
			//	i--;
			//	continue;
			//}

			//box1.Connect(box2);

			if (circuit1 is null && circuit2 is null)
			{
				var circuit = new Circuit(box1, box2);
				circuits.Add(circuit);
				Console.WriteLine($"neither are in circuits, creating new circuit {circuit.Label}");
			}
			else if (circuit2 is null)
			{
				Console.WriteLine($"b1 is in a circuit");
				circuit1!.JunctionBoxes.Add(box2);
				box2.Circuit = circuit1;
			}
			else if (circuit1 is null)
			{
				Console.WriteLine($"b2 is in a circuit");

				circuit2!.JunctionBoxes.Add(box1);
				box1.Circuit = circuit2;
			}
			else if (circuit1 == circuit2)
			{
				Console.WriteLine($"in same circuit");
			}
			else
			{
				if (i + 1 == 258)
				{
					Console.WriteLine("here!");
				}
				Console.WriteLine($"both are in different circuits");

				if (!circuits.Remove(box1.Circuit!)) throw new Exception();
				if (!circuits.Remove(box2.Circuit!)) throw new Exception();
				var circuit = new Circuit(box1.Circuit!, box2.Circuit!);
				circuits.Add(circuit);

				box1.Circuit = circuit;
				box2.Circuit = circuit;
			}
			var remaining = junctionBoxes.Where(x => x.Circuit is null).Count();
			var circuitSizes = circuits.OrderByDescending(x => x.Size).Select(x => x.Size);
			Console.WriteLine($"circuits: {circuits.Count}, remaining: {remaining}");
			Console.WriteLine($"circuit sizes: {string.Join(',', circuitSizes)}");
			Console.WriteLine();

			if (remaining + circuitSizes.Sum() != junctionBoxes.Count)
			{
				throw new Exception($"remaining ({remaining}) + circuit size sum ({circuitSizes.Sum()}) does not equal total num boxes: {junctionBoxes.Count}");
			}
		}

		Console.WriteLine($"{circuits.Count} circuits");
		var top3Circuits = circuits
			.OrderByDescending(x => x.Size)
			.Take(3);

		return top3Circuits.Aggregate(1, (result, x) => result * x.Size);
	}

	class Circuit
	{
		public Circuit() { }
		public Circuit(Circuit c1, Circuit c2)
		{
			JunctionBoxes.AddRange(c1.JunctionBoxes.Union(c2.JunctionBoxes));
			foreach (JunctionBox box in JunctionBoxes)
			{
				box.Circuit = this;
			}
		}
		public Circuit(JunctionBox b1, JunctionBox b2)
		{
			JunctionBoxes.AddRange([b1, b2]);
			b1.Circuit = this;
			b2.Circuit = this;
		}

		public List<JunctionBox> JunctionBoxes = [];

		public int Size => JunctionBoxes.Count;

		public string Label { get; init; } = Guid.NewGuid().ToString();
	}

	class JunctionBox
	{
		public JunctionBox(Point3d position)
		{
			Position = position;
		}

		public Point3d Position { get; init; }
		public Circuit? Circuit { get; set; }
		public List<JunctionBox> Connections { get; init; } = [];

		internal void Connect(JunctionBox other)
		{
			this.Connections.Add(other);
			other.Connections.Add(this);
		}
	}

	//description
	protected override int SolvePart2()
	{
		while (InputReader.TryReadLine(out string? currentLine))
		{

		}

		return 0;
	}
}