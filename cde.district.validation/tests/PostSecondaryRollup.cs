using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class PostSecondaryRollup : BaseTest
	{
		public override void Test(Row row, Errors errors)
		{
			AssertSum(row, "RDPF_1YR_PS_PTS_EARN_TTL", new[] { "RDPF_1YR_PS_GRAD_PTS_EARN", "RDPF_1YR_PS_GRAD_DSAG_PTS_EARN", "RDPF_1YR_PS_DROP_PTS_EARN", "RDPF_1YR_PS_ACT_PTS_EARN" }, errors);
			AssertSum(row, "RDPF_1YR_PS_PTS_ELIG_TTL", new[] { "RDPF_1YR_PS_GRAD_PTS_ELIG", "RDPF_1YR_PS_GRAD_DSAG_PTS_ELIG", "RDPF_1YR_PS_DROP_PTS_ELIG", "RDPF_1YR_PS_ACT_PTS_ELIG" }, errors);
			AssertSum(row, "RDPF_3YR_PS_PTS_EARN_TTL", new[] { "RDPF_3YR_PS_GRAD_PTS_EARN", "RDPF_3YR_PS_GRAD_DSAG_PTS_EARN", "RDPF_3YR_PS_DROP_PTS_EARN", "RDPF_3YR_PS_ACT_PTS_EARN" }, errors);
			AssertSum(row, "RDPF_3YR_PS_PTS_ELIG_TTL", new[] { "RDPF_3YR_PS_GRAD_PTS_ELIG", "RDPF_3YR_PS_GRAD_DSAG_PTS_ELIG", "RDPF_3YR_PS_DROP_PTS_ELIG", "RDPF_3YR_PS_ACT_PTS_ELIG" }, errors);
		}
	}
}
