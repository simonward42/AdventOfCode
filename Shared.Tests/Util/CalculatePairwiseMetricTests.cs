namespace Shared.Tests.Util;

public class CalculatePairwiseMetricTests
{
	[Test]
	public void Value_type_collection()
	{
		var valTypeCollection = new int[]
		{
			1, 2, 3
		};

		static int metricFunc(int x, int y) => x + y;

		var expectedDict = new Dictionary<(int, int), int>
		{
			{(1, 2), 3},
			{(1, 3), 4},
			{(2, 3), 5},
		};

		var pairMetrics = valTypeCollection.CalculatePairwiseMetric(metricFunc);

		Assert.That(pairMetrics, Is.EquivalentTo(expectedDict));
	}

	[Test]
	public void Reference_type_collection()
	{
		var valTypeCollection = new Point2d[]
		{
			new(0, 0),
			new(3, 4)
			//the ends of the hypotenuse of a 3,4,5 right triangle 
		};

		static double metricFunc(Point2d x, Point2d y) => x.Distance(y);

		var expectedDict = new Dictionary<(Point2d, Point2d), double>
		{
			{ (new(0,0), new(3,4)), 5}
		};

		var pairMetrics = valTypeCollection.CalculatePairwiseMetric(metricFunc);

		Assert.That(pairMetrics, Is.EquivalentTo(expectedDict));
	}
}
