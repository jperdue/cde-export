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
			AssertSum(row, "1YR_PS_PTS_EARN_TTL", new[] { "1YR_PS_GRAD_PTS_EARN", "1YR_PS_GRAD_DSAG_PTS_EARN", "1YR_PS_DROP_PTS_EARN", "1YR_PS_ACT_PTS_EARN" }, errors);
			AssertSum(row, "1YR_PS_PTS_ELIG_TTL", new[] { "1YR_PS_GRAD_PTS_ELIG", "1YR_PS_GRAD_DSAG_PTS_ELIG", "1YR_PS_DROP_PTS_ELIG", "1YR_PS_ACT_PTS_ELIG" }, errors);
			AssertSum(row, "3YR_PS_PTS_EARN_TTL", new[] { "3YR_PS_GRAD_PTS_EARN", "3YR_PS_GRAD_DSAG_PTS_EARN", "3YR_PS_DROP_PTS_EARN", "3YR_PS_ACT_PTS_EARN" }, errors);
			AssertSum(row, "3YR_PS_PTS_ELIG_TTL", new[] { "3YR_PS_GRAD_PTS_ELIG", "3YR_PS_GRAD_DSAG_PTS_ELIG", "3YR_PS_DROP_PTS_ELIG", "3YR_PS_ACT_PTS_ELIG" }, errors);
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
