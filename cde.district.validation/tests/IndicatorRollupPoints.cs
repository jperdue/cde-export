using cde.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class IndicatorRollupPoints : BaseTest
	{
		public override void Test(Row row, List<string> errors)
		{
			AssertSum(row, "RDPF_1_3_TOTAL_PCT_PTS_EARN", new[] { "RDPF_1_3_ACHIEVE_PTS_EARN", "RDPF_1_3_GROWTH_PTS_EARN", "RDPF_1_3_GRO_GAPS_PTS_EARN", "RDPF_1_3_POST_SEC_PTS_EARN" }, errors);
			AssertSum(row, "RDPF_1YR_TOTAL_PCT_PTS_EARN", new[] { "RDPF_1YR_ACHIEVE_PTS_EARN", "RDPF_1YR_GROWTH_PTS_EARN", "RDPF_1YR_GRO_GAPS_PTS_EARN", "RDPF_1YR_POST_SEC_PTS_EARN" }, errors);
			AssertSum(row, "RDPF_3YR_TOTAL_PCT_PTS_EARN", new[] { "RDPF_3YR_ACHIEVE_PTS_EARN", "RDPF_3YR_GROWTH_PTS_EARN", "RDPF_3YR_GRO_GAPS_PTS_EARN", "RDPF_3YR_POST_SEC_PTS_EARN" }, errors);

			AssertDivide(row, "RDPF_1_3_TOTAL_PCT_PTS_EARN", "RDPF_1_3_TOTAL_PTS_EARN", "RDPF_1_3_TOTAL_PTS_ELIG", errors);
			AssertDivide(row, "RDPF_1YR_TOTAL_PCT_PTS_EARN", "RDPF_1YR_TOTAL_PTS_EARN", "RDPF_1YR_TOTAL_PTS_ELIG", errors);
			AssertDivide(row, "RDPF_3YR_TOTAL_PCT_PTS_EARN", "RDPF_3YR_TOTAL_PTS_EARN", "RDPF_3YR_TOTAL_PTS_ELIG", errors);
		}
	}
}
