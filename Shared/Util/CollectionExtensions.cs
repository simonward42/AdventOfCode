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

	public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
	{
		IEnumerable<IEnumerable<T>> emptyProduct = [[]];

		return sequences.Aggregate(
			emptyProduct,
			(accumulator, sequence) =>
				from acc in accumulator
				from item in sequence
				select acc.Concat([item]));
	}

	public static string PrettyPrint<T>(this ICollection<T> collection)
	{
		return $"[{string.Join(", ", collection)}]";
	}

	public static T[,] ToRectangular<T>(this T[][] source)
	{
		int rows = source.Length;
		int cols = source[0].Length;

		if (source.Any(r => r.Length != cols))
			throw new ArgumentException("All rows must have equal length");

		var result = new T[rows, cols];

		for (int i = 0; i < rows; i++)
			for (int j = 0; j < cols; j++)
				result[i, j] = source[i][j];

		return result;
	}
}
