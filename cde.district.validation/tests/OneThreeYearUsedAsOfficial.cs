using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class OneThreeYearUsedAsOfficial : BaseTest
	{
		public override void Test(Row row, Errors errors)
		{
			if(AssertDefined(row, new[] { "1_3_RATING_YEAR_USED", "1YR_INDICATOR_NCOUNT", "3YR_INDICATOR_NCOUNT", "1YR_TOTAL_PCT_PTS_EARN", "3YR_TOTAL_PCT_PTS_EARN" }, errors))
			{
				var ratingYearUsed = row["1_3_RATING_YEAR_USED"].ToLower();
				var oneYearCount = double.Parse(row["1YR_INDICATOR_NCOUNT"]);
				var threeYearCount = double.Parse(row["3YR_INDICATOR_NCOUNT"]);
				var oneYearPercent = double.Parse(row["1YR_TOTAL_PCT_PTS_EARN"]);
				var threeYearPercent = double.Parse(row["3YR_TOTAL_PCT_PTS_EARN"]);

				if (ratingYearUsed == "1 year")
				{
					if (oneYearCount > threeYearCount) return;
					if (oneYearCount == threeYearCount && oneYearPercent >= threeYearPercent) return;
				}
				else if(ratingYearUsed == "3 year")
				{
					if (oneYearCount < threeYearCount) return;
					if (oneYearCount == threeYearCount && oneYearPercent < threeYearPercent) return;
				}
				//If we got there then none of the tests pass
				AssertTrue(row, false, "None of the tests passed", errors);
			}
		}
	}
}
