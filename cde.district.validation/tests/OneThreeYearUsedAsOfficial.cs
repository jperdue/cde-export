using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class OneThreeYearUsedAsOfficial : BaseTest
	{
		public override void Test(Row row, List<string> errors)
		{
			if(AssertDefined(row, new[] { "RDPF_1_3_RATING_YEAR_USED", "RDPF_1YR_INDICATOR_NCOUNT", "RDPF_3YR_INDICATOR_NCOUNT", "RDPF_1YR_TOTAL_PCT_PTS_EARN", "RDPF_3YR_TOTAL_PCT_PTS_EARN" }, errors))
			{
				var ratingYearUsed = row["RDPF_1_3_RATING_YEAR_USED"].ToLower();
				var oneYearCount = double.Parse(row["RDPF_1YR_INDICATOR_NCOUNT"]);
				var threeYearCount = double.Parse(row["RDPF_3YR_INDICATOR_NCOUNT"]);
				var oneYearPercent = double.Parse(row["RDPF_1YR_TOTAL_PCT_PTS_EARN"]);
				var threeYearPercent = double.Parse(row["RDPF_3YR_TOTAL_PCT_PTS_EARN"]);

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
