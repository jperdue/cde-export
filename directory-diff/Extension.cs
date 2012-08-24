using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace directory_diff
{
	public static class Extension
	{
		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			foreach (T t in source)
			{
				action(t);
			}
		}
	}
}
