using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cde.district.validation
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

		public static IEnumerable<string> GetLines(Stream stream)
		{
			using (var file = new StreamReader(stream))
			{
				var line = (String)null;
				while ((line = file.ReadLine()) != null)
				{
                    if (line.Length > 0)
                    {
                        yield return line;
                    }
				}
			}
		}

		public static IEnumerable<string> GetLines(string filename)
		{
			using (var file = new StreamReader(filename))
			{
				var line = (String)null;
				while ((line = file.ReadLine()) != null)
				{
                    if (line.Length > 0)
                    {
                        yield return line;
                    }
				}
			}
		}

		public static IEnumerable<Row> GetRows(string filename)
		{
			return GetRows(GetLines(filename));
		}

		public static IEnumerable<Row> GetRows(Stream stream)
		{
			return GetRows(GetLines(stream));
		}

		public static IEnumerable<Row> GetRows(IEnumerable<string> lines)
		{
			string[] header = null;
			var first = true;
			int counter = 2;
			foreach(var line in lines)
			{
				var parts = line.Split('\t');
                if (parts.Length == 1)
                {
                    throw new Exception("Only one column defined (data must be tab separated)");
                }
				if(first)
				{
					header = line.Split('\t');
					first = false;
				}
				else
				{
					var type = header[0].StartsWith("RDPF_") ? EDataType.District : EDataType.School;
					var row = new Row { LineNumber = counter, Type = type };
					for (var i = 0; i < header.Length; i++)
					{
                        var columnHeader = header[i];
                        if (columnHeader.Length > 5)
                        {
                            columnHeader = columnHeader.Substring(5);
                        }
						row[columnHeader] = parts[i].Replace("\"", "");
					}
					yield return row;
					counter++;
				}
			}
		}

		public static IEnumerable<R> EnumerateWith<T, R>(this IEnumerable<T> left, IEnumerable<T> right, Func<T, T, R> selector)
		{
			using (IEnumerator<T> l = left.GetEnumerator(),
					r = right.GetEnumerator())
			{
				while (l.MoveNext() && r.MoveNext())
				{
					yield return selector(l.Current, r.Current);
				}
			}
		}

		public static string SplitCamelCase(this string value)
		{
			return Regex.Replace(
				Regex.Replace(
					value,
					@"(\P{Ll})(\P{Ll}\p{Ll})",
					"$1 $2"
				),
				@"(\p{Ll})(\P{Ll})",
				"$1 $2"
			);
		}

		public static string Format(this double value)
		{
			return value.ToString("{0:0.0}");
		}
	}
}
