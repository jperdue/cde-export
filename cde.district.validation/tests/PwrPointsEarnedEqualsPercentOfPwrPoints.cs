using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class PwrPointsEarnedEqualsPercentOfPwrPoints : BaseTest
	{
		public override void Test(Row row, Errors errors)
		{
			AssertDivide(row, "RDPF_1YR_PS_PCT_PTS_EARN_TTL", "RDPF_1YR_PS_PTS_EARN_TTL", "RDPF_1YR_PS_PTS_ELIG_TTL", errors);
			AssertDivide(row, "RDPF_3YR_PS_PCT_PTS_EARN_TTL", "RDPF_3YR_PS_PTS_EARN_TTL", "RDPF_3YR_PS_PTS_ELIG_TTL", errors);
		}
	}
}
