using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class AcademicAchievementPointsRollup : BaseTest
	{
		public override void Test(Row row, Errors errors)
		{
			AssertSum(row, "RDPF_1YR_ACH_PTS_EARN_TTL", new[] { "RDPF_1YR_ACH_PTS_EARN_READ", "RDPF_1YR_ACH_PTS_EARN_MATH", "RDPF_1YR_ACH_PTS_EARN_WRITE", "RDPF_1YR_ACH_PTS_EARN_SCI" }, errors);
			AssertSum(row, "RDPF_3YR_ACH_PTS_EARN_TTL", new[] { "RDPF_3YR_ACH_PTS_EARN_READ", "RDPF_3YR_ACH_PTS_EARN_MATH", "RDPF_3YR_ACH_PTS_EARN_WRITE", "RDPF_3YR_ACH_PTS_EARN_SCI" }, errors);
			AssertSum(row, "RDPF_1YR_ACH_PTS_ELIG_TTL", new[] { "RDPF_1YR_ACH_PTS_ELIG_READ", "RDPF_1YR_ACH_PTS_ELIG_MATH", "RDPF_1YR_ACH_PTS_ELIG_WRITE", "RDPF_1YR_ACH_PTS_ELIG_SCI" }, errors);
			AssertSum(row, "RDPF_3YR_ACH_PTS_ELIG_TTL", new[] { "RDPF_3YR_ACH_PTS_ELIG_READ", "RDPF_3YR_ACH_PTS_ELIG_MATH", "RDPF_3YR_ACH_PTS_ELIG_WRITE", "RDPF_3YR_ACH_PTS_ELIG_SCI" }, errors);
		}
	}
}