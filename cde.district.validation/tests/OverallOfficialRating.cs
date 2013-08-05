using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class OverallOfficialRating : BaseTest
	{
        const string IncludedEMHForA = "INCLUDED_EMH_FOR_A";

		IEnumerable<Tuple<string, string>> Columns
		{
			get
			{
				yield return new Tuple<string, string>("A_TTL_DPF_RATING_CALC", "1_3_TOTAL_PCT_PTS_EARN");
				yield return new Tuple<string, string>("A_TTL_DPF_RATING_OFFICIAL", "1_3_TOTAL_PCT_PTS_EARN");
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
                if(AssertDefined(row, IncludedEMHForA, errors))
                {
    				Columns.ForEach(t => AssertRating(row, t.Item1, t.Item2, GetSchoolRating(row), errors));
                }
			}
		}

		protected override bool AssertRating(Row row, string ratingColumn, string valueColumn, Func<double, string> ratingLookup, Errors errors, bool passIfBlank = false)
		{
            if (row.Type == EDataType.School)
            {
                ratingColumn = ratingColumn.Replace("_DPF_", "_SPF_");
            }

            return base.AssertRating(row, ratingColumn, valueColumn, ratingLookup, errors, passIfBlank);
		}

		Func<double, string> GetSchoolRating(Row row)
		{
			var level = row.Level;
			var emhCode = row[IncludedEMHForA];
			if (level == "H") return RatingHighRubric;
			if (level == "M" || level == "E") return RatingElementaryMiddleRubric;
			if (emhCode.Contains("H")) return RatingHighRubric;
			return RatingElementaryMiddleRubric;			
		}

		string RatingDistrict(double value)
		{
			if (value < 42.0) return "Accredited with Turnaround Plan";
			if (value < 52.0) return "Accredited w/Priority Improvement Plan";
			if (value < 64.0) return "Accredited with Improvement Plan";
			if (value < 80.0) return "Accredited";
			return "Accredited with Distinction";
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
