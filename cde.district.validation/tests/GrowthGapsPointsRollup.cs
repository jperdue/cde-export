using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class GrowthGapsPointsRollup : BaseTest
	{
		public override void Test(Row row, Errors errors)
		{
			AssertSum(row, "1YR_GG_PTS_EARN_READ", new[] { "1YR_GG_BPA_PTS_EARN_READ", "1YR_GG_ELL_PTS_EARN_READ", "1YR_GG_DIS_PTS_EARN_READ", "1YR_GG_MIN_PTS_EARN_READ", "1YR_GG_FRL_PTS_EARN_READ" }, errors);
			AssertSum(row, "1YR_GG_PTS_ELIG_READ", new[] { "1YR_GG_BPA_PTS_ELIG_READ", "1YR_GG_ELL_PTS_ELIG_READ", "1YR_GG_DIS_PTS_ELIG_READ", "1YR_GG_MIN_PTS_ELIG_READ", "1YR_GG_FRL_PTS_ELIG_READ" }, errors);
			AssertSum(row, "3YR_GG_PTS_EARN_READ", new[] { "3YR_GG_BPA_PTS_EARN_READ", "3YR_GG_ELL_PTS_EARN_READ", "3YR_GG_DIS_PTS_EARN_READ", "3YR_GG_MIN_PTS_EARN_READ", "3YR_GG_FRL_PTS_EARN_READ" }, errors);
			AssertSum(row, "3YR_GG_PTS_ELIG_READ", new[] { "3YR_GG_BPA_PTS_ELIG_READ", "3YR_GG_ELL_PTS_ELIG_READ", "3YR_GG_DIS_PTS_ELIG_READ", "3YR_GG_MIN_PTS_ELIG_READ", "3YR_GG_FRL_PTS_ELIG_READ" }, errors);

			AssertSum(row, "1YR_GG_PTS_EARN_MATH", new[] { "1YR_GG_BPA_PTS_EARN_MATH", "1YR_GG_ELL_PTS_EARN_MATH", "1YR_GG_DIS_PTS_EARN_MATH", "1YR_GG_MIN_PTS_EARN_MATH", "1YR_GG_FRL_PTS_EARN_MATH" }, errors);
			AssertSum(row, "1YR_GG_PTS_ELIG_MATH", new[] { "1YR_GG_BPA_PTS_ELIG_MATH", "1YR_GG_ELL_PTS_ELIG_MATH", "1YR_GG_DIS_PTS_ELIG_MATH", "1YR_GG_MIN_PTS_ELIG_MATH", "1YR_GG_FRL_PTS_ELIG_MATH" }, errors);
			AssertSum(row, "3YR_GG_PTS_EARN_MATH", new[] { "3YR_GG_BPA_PTS_EARN_MATH", "3YR_GG_ELL_PTS_EARN_MATH", "3YR_GG_DIS_PTS_EARN_MATH", "3YR_GG_MIN_PTS_EARN_MATH", "3YR_GG_FRL_PTS_EARN_MATH" }, errors);
			AssertSum(row, "3YR_GG_PTS_ELIG_MATH", new[] { "3YR_GG_BPA_PTS_ELIG_MATH", "3YR_GG_ELL_PTS_ELIG_MATH", "3YR_GG_DIS_PTS_ELIG_MATH", "3YR_GG_MIN_PTS_ELIG_MATH", "3YR_GG_FRL_PTS_ELIG_MATH" }, errors);

			AssertSum(row, "1YR_GG_PTS_EARN_WRITE", new[] { "1YR_GG_BPA_PTS_EARN_WRITE", "1YR_GG_ELL_PTS_EARN_WRITE", "1YR_GG_DIS_PTS_EARN_WRITE", "1YR_GG_MIN_PTS_EARN_WRITE", "1YR_GG_FRL_PTS_EARN_WRITE" }, errors);
			AssertSum(row, "1YR_GG_PTS_ELIG_WRITE", new[] { "1YR_GG_BPA_PTS_ELIG_WRITE", "1YR_GG_ELL_PTS_ELIG_WRITE", "1YR_GG_DIS_PTS_ELIG_WRITE", "1YR_GG_MIN_PTS_ELIG_WRITE", "1YR_GG_FRL_PTS_ELIG_WRITE" }, errors);
			AssertSum(row, "3YR_GG_PTS_EARN_WRITE", new[] { "3YR_GG_BPA_PTS_EARN_WRITE", "3YR_GG_ELL_PTS_EARN_WRITE", "3YR_GG_DIS_PTS_EARN_WRITE", "3YR_GG_MIN_PTS_EARN_WRITE", "3YR_GG_FRL_PTS_EARN_WRITE" }, errors);
			AssertSum(row, "3YR_GG_PTS_ELIG_WRITE", new[] { "3YR_GG_BPA_PTS_ELIG_WRITE", "3YR_GG_ELL_PTS_ELIG_WRITE", "3YR_GG_DIS_PTS_ELIG_WRITE", "3YR_GG_MIN_PTS_ELIG_WRITE", "3YR_GG_FRL_PTS_ELIG_WRITE" }, errors);

			AssertSum(row, "1YR_GG_PTS_EARN_TTL", new[] { "1YR_GG_PTS_EARN_READ", "1YR_GG_PTS_EARN_MATH", "1YR_GG_PTS_EARN_WRITE" }, errors);
			AssertSum(row, "1YR_GG_PTS_ELIG_TTL", new[] { "1YR_GG_PTS_ELIG_READ", "1YR_GG_PTS_ELIG_MATH", "1YR_GG_PTS_ELIG_WRITE" }, errors);
			AssertSum(row, "3YR_GG_PTS_EARN_TTL", new[] { "3YR_GG_PTS_EARN_READ", "3YR_GG_PTS_EARN_MATH", "3YR_GG_PTS_EARN_WRITE" }, errors);
			AssertSum(row, "3YR_GG_PTS_ELIG_TTL", new[] { "3YR_GG_PTS_ELIG_READ", "3YR_GG_PTS_ELIG_MATH", "3YR_GG_PTS_ELIG_WRITE" }, errors);
		}

        public override bool AssertSum(Row row, string resultColumn, IEnumerable<string> partColumns, Errors errors)
        {
            if (!Defined(row, resultColumn, errors) &&
                partColumns.All(c => !Defined(row, c, errors)))
            {
                return true;
            }

            return base.AssertSum(row, resultColumn, partColumns, errors);
        }
	}
}
