using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class IndicatorPercentOfPointsEarnedMatchSummaryPercentOfPoints : BaseTest
	{
		public override void Test(Row row, Errors errors)
		{
			AssertEqual(row, "1YR_ACHIEVE_PCT_PTS_EARN", "1YR_ACH_PCT_PTS_EARN_TTL", errors);
			AssertEqual(row, "3YR_ACHIEVE_PCT_PTS_EARN", "3YR_ACH_PCT_PTS_EARN_TTL", errors);
			AssertEqual(row, "1YR_GROWTH_PCT_PTS_EARN", "1YR_GRO_PCT_PTS_EARN_TTL", errors);
			AssertEqual(row, "3YR_GROWTH_PCT_PTS_EARN", "3YR_GRO_PCT_PTS_EARN_TTL", errors);
			AssertEqual(row, "1YR_GRO_GAPS_PCT_PTS_EARN", "1YR_GG_PCT_PTS_EARN_TTL", errors);
			AssertEqual(row, "3YR_GRO_GAPS_PCT_PTS_EARN", "3YR_GG_PCT_PTS_EARN_TTL", errors);
			AssertEqual(row, "1YR_POST_SEC_PCT_PTS_EARN", "1YR_PS_PCT_PTS_EARN_TTL", errors);
			AssertEqual(row, "3YR_POST_SEC_PCT_PTS_EARN", "3YR_PS_PCT_PTS_EARN_TTL", errors);
		}
	}
}
