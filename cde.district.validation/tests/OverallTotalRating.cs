using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class OverallTotalRating : BaseTest
	{
		IEnumerable<Tuple<string, string>> Columns
		{
			get
			{				
				yield return new Tuple<string, string>("1_3_TOTAL_RATING", "1_3_TOTAL_PCT_PTS_EARN");
			}
		}

		public override void Test(Row row, Errors errors)
		{
			Columns.ForEach(t => AssertRating(row, t.Item1, t.Item2, Rating, errors));
		}

		string Rating(double value)
		{
			if (value < 42.0) return "Turnaround";
			if (value < 52.0) return "Priority Improvement";
			if (value < 64.0) return "Improvement";
			if (value < 80.0) return "Performance";
			return "Distinction";
		}
	}
}
