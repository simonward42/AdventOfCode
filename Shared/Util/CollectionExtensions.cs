namespace Shared.Util;

public static class CollectionExtensions
{
	public static Dictionary<(T, T), M> CalculatePairwiseMetric<T, M>(this ICollection<T> collection, Func<T, T, M> metricFunc)
	{
		var metricValues = new Dictionary<(T, T), M>();

		var exclude = new List<T>();
		foreach (var item1 in collection)
		{
			exclude.Add(item1);
			foreach (var item2 in collection.Except(exclude))
			{
				var metric = metricFunc(item1, item2);
				metricValues.Add((item1, item2), metric);
			}
		}

		return metricValues;
	}
}
