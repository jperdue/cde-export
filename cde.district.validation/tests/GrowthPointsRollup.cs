using cde.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class GrowthPointsRollup : BaseTest
	{
		public override void Test(Row row, List<string> errors)
		{
			AssertSum(row, "RDPF_1YR_GRO_PTS_EARN_TTL", new[] { "RDPF_1YR_GRO_PTS_EARN_ELP", "RDPF_1YR_GRO_PTS_EARN_READ", "RDPF_1YR_GRO_PTS_EARN_MATH", "RDPF_1YR_GRO_PTS_EARN_WRITE" }, errors);
			AssertSum(row, "RDPF_1YR_GRO_PTS_ELIG_TTL", new[] { "RDPF_1YR_GRO_PTS_ELIG_ELP", "RDPF_1YR_GRO_PTS_ELIG_READ", "RDPF_1YR_GRO_PTS_ELIG_MATH", "RDPF_1YR_GRO_PTS_ELIG_WRITE" }, errors);
			AssertSum(row, "RDPF_3YR_GRO_PTS_EARN_TTL", new[] { "RDPF_3YR_GRO_PTS_EARN_ELP", "RDPF_3YR_GRO_PTS_EARN_READ", "RDPF_3YR_GRO_PTS_EARN_MATH", "RDPF_3YR_GRO_PTS_EARN_WRITE" }, errors);
			AssertSum(row, "RDPF_3YR_GRO_PTS_ELIG_TTL", new[] { "RDPF_3YR_GRO_PTS_ELIG_ELP", "RDPF_3YR_GRO_PTS_ELIG_READ", "RDPF_3YR_GRO_PTS_ELIG_MATH", "RDPF_3YR_GRO_PTS_ELIG_WRITE" }, errors);
		}
	}
}
