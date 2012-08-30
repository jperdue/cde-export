using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class IndicatorRollupPoints : BaseTest
	{
		public override void Test(Row row, Errors errors)
		{
			AssertSum(row, "1_3_TOTAL_PTS_EARN", new[] { "1_3_ACHIEVE_PTS_EARN", "1_3_GROWTH_PTS_EARN", "1_3_GRO_GAPS_PTS_EARN", "1_3_POST_SEC_PTS_EARN" }, errors);
			AssertSum(row, "1YR_TOTAL_PTS_EARN", new[] { "1YR_ACHIEVE_PTS_EARN", "1YR_GROWTH_PTS_EARN", "1YR_GRO_GAPS_PTS_EARN", "1YR_POST_SEC_PTS_EARN" }, errors);
			AssertSum(row, "3YR_TOTAL_PTS_EARN", new[] { "3YR_ACHIEVE_PTS_EARN", "3YR_GROWTH_PTS_EARN", "3YR_GRO_GAPS_PTS_EARN", "3YR_POST_SEC_PTS_EARN" }, errors);

			AssertDivide(row, "1_3_TOTAL_PCT_PTS_EARN", "1_3_TOTAL_PTS_EARN", "1_3_TOTAL_PTS_ELIG", errors);
			AssertDivide(row, "1YR_TOTAL_PCT_PTS_EARN", "1YR_TOTAL_PTS_EARN", "1YR_TOTAL_PTS_ELIG", errors);
			AssertDivide(row, "3YR_TOTAL_PCT_PTS_EARN", "3YR_TOTAL_PTS_EARN", "3YR_TOTAL_PTS_ELIG", errors);
		}
	}
}
