using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class DisaggregatedGraduationRateRollupPoints : BaseTest
	{
		public override void Test(Row row, Errors errors)
		{
			AssertSum(row, "RDPF_1YR_PS_GRAD_DSAG_PTS_EARN", new[] { "RDPF_1YR_PS_GRAD_ELL_PTS_EARN", "RDPF_1YR_PS_GRAD_IEP_PTS_EARN", "RDPF_1YR_PS_GRAD_MIN_PTS_EARN", "RDPF_1YR_PS_GRAD_FRL_PTS_EARN" }, errors);
			AssertSum(row, "RDPF_1YR_PS_GRAD_DSAG_PTS_ELIG", new[] { "RDPF_1YR_PS_GRAD_ELL_PTS_ELIG", "RDPF_1YR_PS_GRAD_IEP_PTS_ELIG", "RDPF_1YR_PS_GRAD_MIN_PTS_ELIG", "RDPF_1YR_PS_GRAD_FRL_PTS_ELIG" }, errors);
			AssertSum(row, "RDPF_3YR_PS_GRAD_DSAG_PTS_EARN", new[] { "RDPF_3YR_PS_GRAD_ELL_PTS_EARN", "RDPF_3YR_PS_GRAD_IEP_PTS_EARN", "RDPF_3YR_PS_GRAD_MIN_PTS_EARN", "RDPF_3YR_PS_GRAD_FRL_PTS_EARN" }, errors);
			AssertSum(row, "RDPF_3YR_PS_GRAD_DSAG_PTS_ELIG", new[] { "RDPF_3YR_PS_GRAD_ELL_PTS_ELIG", "RDPF_3YR_PS_GRAD_IEP_PTS_ELIG", "RDPF_3YR_PS_GRAD_MIN_PTS_ELIG", "RDPF_3YR_PS_GRAD_FRL_PTS_ELIG" }, errors);	}
	}
}
