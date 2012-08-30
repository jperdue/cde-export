using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class GrowthPointsEarnedEqualsPercentOfGrowthPoints : BaseTest
	{
		public override void Test(Row row, Errors errors)
		{
			AssertDivide(row, "1YR_GRO_PCT_PTS_EARN_TTL", "1YR_GRO_PTS_EARN_TTL", "1YR_GRO_PTS_ELIG_TTL", errors);
			AssertDivide(row, "3YR_GRO_PCT_PTS_EARN_TTL", "3YR_GRO_PTS_EARN_TTL", "3YR_GRO_PTS_ELIG_TTL", errors);

			AssertDivide(row, "1YR_GG_PCT_PTS_EARN_READ", "1YR_GG_PTS_EARN_READ",  "1YR_GG_PTS_ELIG_READ", errors);
			AssertDivide(row, "3YR_GG_PCT_PTS_EARN_READ", "3YR_GG_PTS_EARN_READ", "3YR_GG_PTS_ELIG_READ", errors);
			AssertDivide(row, "1YR_GG_PCT_PTS_EARN_MATH", "1YR_GG_PTS_EARN_MATH", "1YR_GG_PTS_ELIG_MATH", errors);
			AssertDivide(row, "3YR_GG_PCT_PTS_EARN_MATH", "3YR_GG_PTS_EARN_MATH", "3YR_GG_PTS_ELIG_MATH", errors);
			AssertDivide(row, "1YR_GG_PCT_PTS_EARN_WRITE", "1YR_GG_PTS_EARN_WRITE", "1YR_GG_PTS_ELIG_WRITE", errors);
			AssertDivide(row, "3YR_GG_PCT_PTS_EARN_WRITE", "3YR_GG_PTS_EARN_WRITE", "3YR_GG_PTS_ELIG_WRITE", errors);
			AssertDivide(row, "1YR_GG_PCT_PTS_EARN_TTL", "1YR_GG_PTS_EARN_TTL", "1YR_GG_PTS_ELIG_TTL", errors);
			AssertDivide(row, "3YR_GG_PCT_PTS_EARN_TTL", "3YR_GG_PTS_EARN_TTL", "3YR_GG_PTS_ELIG_TTL", errors);  
		}
	}
}
