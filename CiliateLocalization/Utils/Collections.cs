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
			for (int i = 1; i < sortedValues.Length; i++)
			{
				if (!increment(sortedValues[i - 1]).Equals(sortedValues[i]))
				{
					var val = increment(sortedValues[i - 1]);
					while (!val.Equals(sortedValues[i]))
					{
						holes.Add(val);
						val = increment(val);
					}
				}
			}
			return holes;
		}
	}
}
