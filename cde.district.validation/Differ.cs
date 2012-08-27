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
			return rows.Select(t => DiffRows(t.Item1, t.Item2)).Where(r => r != null);			
		}

		Result DiffRows(Row row1, Row row2)
		{
			var errors = new List<string>();
			if (row1.Count != row2.Count)
			{
				errors.Add("Different column counts");
			}
			var smaller = row1.Count < row2.Count ? row1 : row2;
			var bigger = row1.Count >= row2.Count ? row1 : row2;
			foreach (var pair in smaller)
			{
				if (!bigger.ContainsKey(pair.Key))
				{
					errors.Add("Missing column: " + pair.Key);
				}
				else if (bigger[pair.Key].ToLower() != pair.Value.ToLower())
				{
					errors.Add("Mismatched value on column: " + pair.Key + "(" + pair.Value + "," + bigger[pair.Key] + ")");
				}
			}
			if (errors.Count > 0)
			{
				return new Result
				{
					Title = row1.ToString(),
					Errors = errors
				};
			}
			return null;
		}
	}
}
