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
			if (row.Type == EDataType.District)
			{
				Columns.ForEach(t => AssertRating(row, t.Item1, t.Item2, RatingDistrict, errors));
			}
			else
			{
				Columns.ForEach(t => AssertRating(row, t.Item1, t.Item2, GetSchoolRating(row), errors));				
			}
		}

		Func<double, string> GetSchoolRating(Row row)
		{
			var level = row.Level;
			var emhCode = row["INCLUDED_EMH_FOR_A"];
			if (level == "H") return RatingHighRubric;
			if (level == "M" || level == "E") return RatingElementaryMiddleRubric;
			if (emhCode.Contains("H")) return RatingHighRubric;
			return RatingElementaryMiddleRubric;
		}

		string RatingDistrict(double value)
		{
			if (value < 42.0) return "Turnaround";
			if (value < 52.0) return "Priority Improvement";
			if (value < 64.0) return "Improvement";
			if (value < 80.0) return "Performance";
			return "Distinction";
		}

		string RatingElementaryMiddleRubric(double value)
		{
			if (value < 37.0) return "Turnaround Plan";
			if (value < 47.0) return "Priority Improvement Plan";
			if (value < 59.0) return "Improvement Plan";
			return "Performance Plan";
		}

		string RatingHighRubric(double value)
		{
			if (value < 33.0) return "Turnaround Plan";
			if (value < 47.0) return "Priority Improvement Plan";
			if (value < 60.0) return "Improvement Plan";
			return "Performance Plan";
		}
	}
}
