using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace cde.district.validation
{
	public class Differ
	{
		public IEnumerable<Result> CompareFiles(string filename1, string filename2)
		{
			return DiffRows(Extension.GetRows(filename1), Extension.GetRows(filename2));
		}

		public IEnumerable<Result> CompareFiles(Stream stream1, Stream stream2)
		{
			return DiffRows(Extension.GetRows(stream1), Extension.GetRows(stream2));
		}

		IEnumerable<Result> DiffRows(IEnumerable<Row> rows1, IEnumerable<Row> rows2)
		{
			var rows = rows1.Join(rows2, r => r.Name, r => r.Name, (r1, r2) => new Tuple<Row, Row>(r1, r2));
			var errors = rows.Select(t => DiffRows(t.Item1, t.Item2)).SelectMany(i => i);

			return errors.GroupBy(e => e.Column).Select(g => new Result { Title = g.Key, Errors = g.Select(e => e.Message).Distinct().ToList() });
		}

		IEnumerable<Error> DiffRows(Row row1, Row row2)
		{
			if (row1.Count != row2.Count)
			{
				yield return new Error(row1.Name, "Mismatch", "Different column counts");
			}
			var smaller = row1.Count < row2.Count ? row1 : row2;
			var bigger = row1.Count >= row2.Count ? row1 : row2;
			foreach (var pair in smaller)
			{
				if (!bigger.ContainsKey(pair.Key))
				{
					yield return new Error(row1.Name, pair.Key, "Missing Column: '" + pair.Key + "' (" + row1.Name + ")");
				}
				else if (bigger[pair.Key].ToLower() != pair.Value.ToLower())
				{
					yield return new Error(row1.Name, pair.Key, "Mismatched value: ('" + pair.Value + "', '" + bigger[pair.Key] + "') (" + row1.Name + ")");
				}
			}
		}
	}
}
