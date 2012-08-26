using cde.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class DisaggregatedGraduationPointsEarnedEqualsPercentOfDisaggregatedGradPoints : BaseTest
	{
		public override void Test(Row row, List<string> errors)
		{
			AssertDivide(row, "RDPF_1YR_PS_GRAD_DSAG_PCT_PTS", "RDPF_1YR_PS_GRAD_DSAG_PTS_EARN", "RDPF_1YR_PS_GRAD_DSAG_PTS_ELIG", errors);
			AssertDivide(row, "RDPF_3YR_PS_GRAD_DSAG_PCT_PTS", "RDPF_3YR_PS_GRAD_DSAG_PTS_EARN", "RDPF_3YR_PS_GRAD_DSAG_PTS_ELIG", errors);
		}
	}
}
