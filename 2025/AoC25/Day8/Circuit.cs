namespace AoC25.Day8;

public class Circuit
{
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