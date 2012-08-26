using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class GrowthPointsEarnedEqualsPercentOfGrowthPoints : BaseTest
	{
		public override void Test(Row row, List<string> errors)
		{
			AssertDivide(row, "RDPF_1YR_GRO_PCT_PTS_EARN_TTL", "RDPF_1YR_GRO_PTS_EARN_TTL", "RDPF_1YR_GRO_PTS_ELIG_TTL", errors);
			AssertDivide(row, "RDPF_3YR_GRO_PCT_PTS_EARN_TTL", "RDPF_3YR_GRO_PTS_EARN_TTL", "RDPF_3YR_GRO_PTS_ELIG_TTL", errors);

			AssertDivide(row, "RDPF_1YR_GG_PCT_PTS_EARN_READ", "RDPF_1YR_GG_PTS_EARN_READ",  "RDPF_1YR_GG_PTS_ELIG_READ", errors);
			AssertDivide(row, "RDPF_3YR_GG_PCT_PTS_EARN_READ", "RDPF_3YR_GG_PTS_EARN_READ", "RDPF_3YR_GG_PTS_ELIG_READ", errors);
			AssertDivide(row, "RDPF_1YR_GG_PCT_PTS_EARN_MATH", "RDPF_1YR_GG_PTS_EARN_MATH", "RDPF_1YR_GG_PTS_ELIG_MATH", errors);
			AssertDivide(row, "RDPF_3YR_GG_PCT_PTS_EARN_MATH", "RDPF_3YR_GG_PTS_EARN_MATH", "RDPF_3YR_GG_PTS_ELIG_MATH", errors);
			AssertDivide(row, "RDPF_1YR_GG_PCT_PTS_EARN_WRITE", "RDPF_1YR_GG_PTS_EARN_WRITE", "RDPF_1YR_GG_PTS_ELIG_WRITE", errors);
			AssertDivide(row, "RDPF_3YR_GG_PCT_PTS_EARN_WRITE", "RDPF_3YR_GG_PTS_EARN_WRITE", "RDPF_3YR_GG_PTS_ELIG_WRITE", errors);
			AssertDivide(row, "RDPF_1YR_GG_PCT_PTS_EARN_TTL", "RDPF_1YR_GG_PTS_EARN_TTL", "RDPF_1YR_GG_PTS_ELIG_TTL", errors);
			AssertDivide(row, "RDPF_3YR_GG_PCT_PTS_EARN_TTL", "RDPF_3YR_GG_PTS_EARN_TTL", "RDPF_3YR_GG_PTS_ELIG_TTL", errors);  
		}
	}
}
