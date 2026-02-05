namespace AoC25.Day8;

using System.Linq;

using Shared.Util;

public class Solution(IInputReader? reader = null) : Puzzle<int>(8, reader)
{
	public int JunctionsToConnect = 1000;

	public bool Verbose = false;

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
		List<JunctionBox> junctionBoxes = [];
		while (InputReader.TryReadLine(out string? line))
		{
			junctionBoxes.Add(new JunctionBox(new Point3d(line)));
		}

		var boxPairs = _BoxPairsOrderedByDistanceDescending(junctionBoxes);

		var circuits = new List<Circuit>();
		for (int i = 0; i < JunctionsToConnect; i++)
		{
			_MakeShortestConnection(junctionBoxes, circuits, boxPairs, i + 1);
		}

		return circuits
			.OrderByDescending(x => x.Size)
			.Take(3)
			.Aggregate(1, (result, x) => result * x.Size);
	}

	/// <summary>
	/// Continue part 1's connection loop until all boxes are within a single circuit. 
	/// </summary>
	/// <returns>The product of the X coordinates of the final box pair connected.</returns>
	protected override int SolvePart2()
	{
		List<JunctionBox> junctionBoxes = [];

		while (InputReader.TryReadLine(out string? line))
		{
			junctionBoxes.Add(new JunctionBox(new Point3d(line)));
		}

		var boxPairs = _BoxPairsOrderedByDistanceDescending(junctionBoxes);

		var circuits = new List<Circuit>();

		int totalCircuits;
		int connectionCount = 0;
		int circuitsCount = 0;
		int unconnected = junctionBoxes.Count;
		JunctionBox box1;
		JunctionBox box2;
		do
		{
			(box1, box2) = _MakeShortestConnection(junctionBoxes, circuits, boxPairs, ++connectionCount);

			circuitsCount = circuits.Count;
			unconnected = junctionBoxes.Where(x => x.Circuit is null).Count();

			totalCircuits = circuitsCount + unconnected;
		} while (totalCircuits != 1);

		return box1.Position.X * box2.Position.X;
	}

	private Stack<(JunctionBox, JunctionBox)> _BoxPairsOrderedByDistanceDescending(ICollection<JunctionBox> junctionBoxes)
	{
		var pairDistances = junctionBoxes.CalculatePairwiseMetric((x, y) => x.Position.Distance(y.Position));

		return new Stack<(JunctionBox, JunctionBox)>(
			pairDistances
				.OrderByDescending(x => x.Value)
				.Select(x => x.Key));
	}

	private (JunctionBox, JunctionBox) _MakeShortestConnection(List<JunctionBox> junctionBoxes, List<Circuit> circuits, Stack<(JunctionBox, JunctionBox)> boxPairs, int connectionCount)
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

		return (box1, box2);
	}
}