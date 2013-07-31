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
			AssertSum(row, "1YR_PS_GRAD_DSAG_PTS_EARN", new[] { "1YR_PS_GRAD_ELL_PTS_EARN", "1YR_PS_GRAD_IEP_PTS_EARN", "1YR_PS_GRAD_MIN_PTS_EARN", "1YR_PS_GRAD_FRL_PTS_EARN" }, errors);
			AssertSum(row, "1YR_PS_GRAD_DSAG_PTS_ELIG", new[] { "1YR_PS_GRAD_ELL_PTS_ELIG", "1YR_PS_GRAD_IEP_PTS_ELIG", "1YR_PS_GRAD_MIN_PTS_ELIG", "1YR_PS_GRAD_FRL_PTS_ELIG" }, errors);
			AssertSum(row, "3YR_PS_GRAD_DSAG_PTS_EARN", new[] { "3YR_PS_GRAD_ELL_PTS_EARN", "3YR_PS_GRAD_IEP_PTS_EARN", "3YR_PS_GRAD_MIN_PTS_EARN", "3YR_PS_GRAD_FRL_PTS_EARN" }, errors);
			AssertSum(row, "3YR_PS_GRAD_DSAG_PTS_ELIG", new[] { "3YR_PS_GRAD_ELL_PTS_ELIG", "3YR_PS_GRAD_IEP_PTS_ELIG", "3YR_PS_GRAD_MIN_PTS_ELIG", "3YR_PS_GRAD_FRL_PTS_ELIG" }, errors);
        }

        public override bool AssertSum(Row row, string resultColumn, IEnumerable<string> partColumns, Errors errors)
        {
            if (!Defined(row, resultColumn, errors))
            {
                return true;
            }

            return base.AssertSum(row, resultColumn, partColumns, errors);
        }
	}
}
