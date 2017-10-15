using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CiliateLocalization.Utils
{
	public class IdMap<T>
		where T: struct, IComparable<T>
	{
		private readonly Stack<T> IdHoles;

		private T NextId;

		private readonly Dictionary<string, T> _Ids;

		private readonly Func<T, T> Increment;

		internal IReadOnlyDictionary<string, T> Ids => _Ids;

		/// <summary>
		/// ...
		/// </summary>
		/// <param name="ids"></param>
		/// <param name="increment">Returns the next value (i.e. value + 1)</param>
		/// <param name="equals"></param>
		public IdMap(Dictionary<string, T> ids, Func<T, T> increment, Func<T,int,bool> equals)
		{
			_Ids = ids; Increment = increment;
			var vals = ids.Values.ToArray();
			Array.Sort(vals);
			IdHoles = new Stack<T>(Collections.Holes(vals, increment, equals));
		}

		public T GetOrAddId(string key)
		{
			if (_Ids.ContainsKey(key))
				return _Ids[key];
			if (IdHoles.Count != 0)
				return IdHoles.Pop();
			var ret = NextId;
			NextId = Increment(NextId);
			return ret;
		}

		public T GetId(string key)
		{
			if (_Ids.ContainsKey(key))
				return _Ids[key];
			throw new KeyNotFoundException();
		}
	}
}
