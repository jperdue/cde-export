using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cde.utils
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

		public static IEnumerable<string> GetLines(string filename)
		{
			using (var file = new StreamReader(filename))
			{
				var line = (String)null;
				while ((line = file.ReadLine()) != null)
				{
					yield return line;
				}
			}
		}

		public static IEnumerable<Row> GetRows(string filename)
		{
			string[] header = null;
			var first = true;
			int counter = 2;
			foreach(var line in GetLines(filename))
			{
				var parts = line.Split('\t');
				if(first)
				{
					header = line.Split('\t');
					first = false;
				}
				else
				{
					var row = new Row { LineNumber = counter };
					for (var i = 0; i < header.Length; i++)
					{
						row[header[i]] = parts[i].Replace("\"", "");
					}
					yield return row;
					counter++;
				}
			}
		}

		public static void EnumerateWith<T>(this IEnumerable<T> left, IEnumerable<T> right, Action<T, T> action)
		{
			using (IEnumerator<T> l = left.GetEnumerator(),
					r = right.GetEnumerator())
			{
				while (l.MoveNext() && r.MoveNext())
				{
					action(l.Current, r.Current);
				}
			}
		}
	}
}
