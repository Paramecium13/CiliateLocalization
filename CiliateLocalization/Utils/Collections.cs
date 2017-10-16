using System;
using System.Collections.Generic;
using System.Text;

namespace CiliateLocalization.Utils
{
	public static class Collections
	{
		public static IEnumerable<T> Holes<T>(T[] sortedValues, Func<T, T> increment, Func<T, int, bool> equals)
			where T: IComparable<T>
		{
			if (sortedValues == null)
				throw new ArgumentNullException(nameof(sortedValues));
			if (sortedValues.Length < 2)
				return sortedValues;
			if (increment == null)
				throw new ArgumentNullException(nameof(increment));
			if (equals == null)
				throw new ArgumentNullException(nameof(equals));

			var max = sortedValues[sortedValues.Length - 1];
			if (equals(max,sortedValues.Length - 1))
				return new List<T>(0);

			var holes = new List<T>();
			var expected = default(T);
			for (int i = 0; i < sortedValues.Length; i++)
			{
				while (!expected.Equals(sortedValues[i]))
				{
					holes.Add(expected);
					expected = increment(expected);
				}
				expected = increment(expected);
			}
			return holes;
		}
	}
}
