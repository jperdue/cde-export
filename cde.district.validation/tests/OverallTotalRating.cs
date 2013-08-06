using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class OverallTotalRating : BaseTest
	{
        const string IncludedEMHForA = "INCLUDED_EMH_FOR_A";

		IEnumerable<Tuple<string, string, string>> Columns
		{
			get
			{
				yield return new Tuple<string, string, string>("1_3_TOTAL_RATING", "1_3_TOTAL_PCT_PTS_EARN", "1_3_PARTIC_RATING");
                yield return new Tuple<string, string, string>("1YR_TOTAL_RATING", "1YR_TOTAL_PCT_PTS_EARN", "1YR_TEST_PARTIC_RATING");
                yield return new Tuple<string, string, string>("3YR_TOTAL_RATING", "3YR_TOTAL_PCT_PTS_EARN", "3YR_TEST_PARTIC_RATING");
            }
		}

		public override void Test(Row row, Errors errors)
		{
			if (row.Type == EDataType.District)
			{


				Columns.ForEach(t => AssertRating(row, t.Item1, t.Item2, RatingDistrict(row, t.Item3), errors));
			}
			else
			{
                if(AssertDefined(row, IncludedEMHForA, errors))
                {
    				Columns.ForEach(t => AssertRating(row, t.Item1, t.Item2, GetSchoolRating(row, t.Item3), errors));				
                }
			}
		}

        Func<double, string> RatingDistrict(Row row, string participationColumn)
        {
            if (MeetsParticipationRate(row, participationColumn))
            {
                return RatingDistrictMeets;
            }
            else
            {
                return RatingDistrictNotMeets;
            }
        }

        protected override bool AssertRating(Row row, string ratingColumn, string valueColumn, Func<double, string> ratingLookup, Errors errors, bool passIfBlank = false)
        {
            if (!Defined(row, ratingColumn, errors) && ratingColumn.Contains("_SPF_"))
            {
                ratingColumn = ratingColumn.Replace("_SPF_", "_DPF_");
            }

            return base.AssertRating(row, ratingColumn, valueColumn, ratingLookup, errors, passIfBlank);
        }

		Func<double, string> GetSchoolRating(Row row, string participationColumn)
		{
    		var level = row.Level;
			var emhCode = row["INCLUDED_EMH_FOR_A"];

            if (MeetsParticipationRate(row, participationColumn))
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

        bool MeetsParticipationRate(Row row, string participationColumn)
        {
            return !row[participationColumn].Contains("Not");
        }

		string RatingDistrictMeets(double value)
		{
			if (value < 42.0) return "Turnaround";
			if (value < 52.0) return "Priority Improvement";
			if (value < 64.0) return "Improvement";
			if (value < 80.0) return "Performance";
			return "Distinction";
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

        string RatingDistrictNotMeets(double value)
        {
            if (value < 52.0) return "Turnaround";
            if (value < 64.0) return "Priority Improvement";
            if (value < 80.0) return "Improvement";
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
