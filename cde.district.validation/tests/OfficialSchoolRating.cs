using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class OfficialSchoolRating : BaseTest
	{
        const string IncludedEMHForA = "INCLUDED_EMH_FOR_A";

		IEnumerable<Tuple<string, string>> Columns
		{
			get
			{
                yield return new Tuple<string, string>("A_TTL_SPF_RATING_CALC", "1_3_TOTAL_PCT_PTS_EARN");
                yield return new Tuple<string, string>("A_TTL_SPF_RATING_OFFICIAL", "1_3_TOTAL_PCT_PTS_EARN");
            }
		}

		public override void Test(Row row, Errors errors)
		{
            if (row.Type == EDataType.District || row.Level != "A")
            {
                return;
            }

            if(AssertDefined(row, IncludedEMHForA, errors))
            {
    			Columns.ForEach(t => AssertRating(row, t.Item1, t.Item2, GetSchoolRating(row), errors));				
            }
		}

        protected override bool AssertRating(Row row, string ratingColumn, string valueColumn, Func<double, string> ratingLookup, Errors errors, bool passIfBlank = false)
        {
            if (ratingColumn == "A_TTL_SPF_RATING_OFFICIAL")
            {
                if (row["ALTERNATIVE_ED_CAMPUS_YN"] == "Y")
                {
                    return AssertTrue(row, row[ratingColumn] == "Pending AEC SPF", "Incorrect rating '" + ratingColumn + "' should be 'Pending AEC SPF'", errors);
                }

                if (row["SCHOOL_CLOSED_YN"] == "Y")
                {
                    return AssertTrue(row, row[ratingColumn] == "School Closed", "Incorrect rating '" + ratingColumn + "' should be 'School Closed'", errors);
                }
            }

            return base.AssertRating(row, ratingColumn, valueColumn, ratingLookup, errors, passIfBlank);
        }

		Func<double, string> GetSchoolRating(Row row)
		{
			var level = row.Level;
			var emhCode = row["INCLUDED_EMH_FOR_A"];

            if (MeetsParticipationRate(row))
            {
                if (level == "H") return RatingHighRubricMeets;
                if (level == "M" || level == "E") return RatingElementaryMiddleRubricMeets;
                if (emhCode.Contains("H")) return RatingHighRubricMeets;
                return RatingElementaryMiddleRubricMeets;
            }
            else
            {
                if (level == "H") return RatingHighRubricNotMeets;
                if (level == "M" || level == "E") return RatingElementaryMiddleRubricNotMeets;
                if (emhCode.Contains("H")) return RatingHighRubricNotMeets;
                return RatingElementaryMiddleRubricNotMeets;
            }
		}

        bool MeetsParticipationRate(Row row)
        {
            return !row["1_3_PARTIC_RATING"].Contains("Not");
        }

		string RatingElementaryMiddleRubricMeets(double value)
		{
			if (value < 37.0) return "Turnaround";
			if (value < 47.0) return "Priority Improvement";
			if (value < 59.0) return "Improvement";
			return "Performance";
		}

		string RatingHighRubricMeets(double value)
		{
			if (value < 33.0) return "Turnaround";
			if (value < 47.0) return "Priority Improvement";
			if (value < 60.0) return "Improvement";
			return "Performance";
		}

        string RatingElementaryMiddleRubricNotMeets(double value)
        {
            if (value < 47.0) return "Turnaround";
            if (value < 59.0) return "Priority Improvement";
            return "Improvement";
        }

        string RatingHighRubricNotMeets(double value)
        {
            if (value < 47.0) return "Turnaround";
            if (value < 60.0) return "Priority Improvement";
            return "Improvement";
        }
	}
}
