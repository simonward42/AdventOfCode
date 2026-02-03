namespace AoC25.Day8;

using System.Linq;

using Shared.Util;

public class Solution : Puzzle<int>
{
	public int JunctionsToConnect = 1000;

	public bool Verbose = false;

	private List<JunctionBox> _junctionBoxes = [];

	public Solution(IInputReader? reader = null) : base(8, reader)
	{
		InputReader.Rewind();

		while (InputReader.TryReadLine(out string? line))
		{
			_junctionBoxes.Add(new JunctionBox(new Point3d(line)));
		}

	}

	/// <summary>
	/// Solves part 1 of the problem by connecting junction boxes into circuits and calculating the product of the sizes of
	/// the three largest resulting circuits.
	/// </summary>
	/// <remarks>This method reads input lines representing junction box positions, connects boxes into circuits
	/// based on pairwise distances, and ensures that the number of connected and unconnected boxes remains consistent
	/// throughout the process. The number of junctions to connect is specified by the <see cref="JunctionsToConnect"/>
	/// property.</remarks>
	/// <returns>The product of the sizes of the three largest circuits formed after connecting the specified number of junctions.</returns>
	/// <exception cref="Exception">Thrown if an internal consistency check fails during circuit merging, indicating an unexpected state in the circuit
	/// collection.</exception>
	protected override int SolvePart1()
	{
		var boxPairs = _BuildPairDistanceStack();

		var circuits = new List<Circuit>();
		for (int i = 0; i < JunctionsToConnect; i++)
		{
			_MakeShortestConnection(_junctionBoxes, circuits, boxPairs, i + 1);
		}

		return circuits
			.OrderByDescending(x => x.Size)
			.Take(3)
			.Aggregate(1, (result, x) => result * x.Size);
	}

	//description
	protected override int SolvePart2()
	{
		while (InputReader.TryReadLine(out string? currentLine))
		{

		}

		return 0;
	}

	private Stack<(JunctionBox, JunctionBox)> _BuildPairDistanceStack()
	{
		var pairDistances = new Dictionary<double, (JunctionBox, JunctionBox)>();

		var exclude = new List<JunctionBox>();
		foreach (var box1 in _junctionBoxes)
		{
			exclude.Add(box1);
			foreach (var box2 in _junctionBoxes.Except(exclude))
			{
				var box1To2 = box1.Position.Distance(box2.Position);
				pairDistances.Add(box1To2, (box1, box2));
			}
		}

		return new Stack<(JunctionBox, JunctionBox)>(
			pairDistances
				.OrderByDescending(x => x.Key)
				.Select(x => x.Value));
	}

	private void _MakeShortestConnection(List<JunctionBox> junctionBoxes, List<Circuit> circuits, Stack<(JunctionBox, JunctionBox)> boxPairs, int connectionCount)
	{
		var (box1, box2) = boxPairs.Pop();
		var circuit1 = box1.Circuit;
		var circuit2 = box2.Circuit;

		if (Verbose) Console.WriteLine($"connection {connectionCount}: {box1.Position} and {box2.Position}");

		if (circuit1 is null && circuit2 is null)
		{
			var circuit = new Circuit(box1, box2);
			circuits.Add(circuit);
			if (Verbose) Console.WriteLine($"neither are in circuits, added new circuit {circuit.Label}");
		}
		else if (circuit2 is null)
		{
			if (Verbose) Console.WriteLine($"b1 is in a circuit, connecting b2");
			circuit1!.JunctionBoxes.Add(box2);
			box2.Circuit = circuit1;
		}
		else if (circuit1 is null)
		{
			if (Verbose) Console.WriteLine($"b2 is in a circuit, connecting b1");
			circuit2!.JunctionBoxes.Add(box1);
			box1.Circuit = circuit2;
		}
		else if (circuit1 == circuit2)
		{
			if (Verbose) Console.WriteLine($"b1 & b2 are in the same circuit");
		}
		else
		{
			if (Verbose) Console.WriteLine($"both are in separate circuits, all boxes in both circuits to be added to a new union circuit");
			circuits.Remove(box1.Circuit!);
			circuits.Remove(box2.Circuit!);
			var circuit = new Circuit(box1.Circuit!, box2.Circuit!);
			circuits.Add(circuit);
		}

		var remaining = junctionBoxes.Where(x => x.Circuit is null).Count();
		var circuitSizes = circuits.OrderByDescending(x => x.Size).Select(x => x.Size);
		var circuitSizeSum = circuitSizes.Sum();
		if (Verbose)
		{
			Console.WriteLine($"circuits: {circuits.Count}, remaining: {remaining}");
			Console.WriteLine($"circuit sizes: {string.Join(',', circuitSizes)}");
			Console.WriteLine();
		}

		if (remaining + circuitSizeSum != junctionBoxes.Count)
		{
			throw new Exception($"remaining ({remaining}) + circuit size sum ({circuitSizeSum}) " +
				$"does not equal box total: {junctionBoxes.Count}");
		}
	}
}