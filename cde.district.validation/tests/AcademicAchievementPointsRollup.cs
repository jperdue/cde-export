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
			AssertSum(row, "1YR_ACH_PTS_EARN_TTL", new[] { "1YR_ACH_PTS_EARN_READ", "1YR_ACH_PTS_EARN_MATH", "1YR_ACH_PTS_EARN_WRITE", "1YR_ACH_PTS_EARN_SCI" }, errors);
			AssertSum(row, "3YR_ACH_PTS_EARN_TTL", new[] { "3YR_ACH_PTS_EARN_READ", "3YR_ACH_PTS_EARN_MATH", "3YR_ACH_PTS_EARN_WRITE", "3YR_ACH_PTS_EARN_SCI" }, errors);
			AssertSum(row, "1YR_ACH_PTS_ELIG_TTL", new[] { "1YR_ACH_PTS_ELIG_READ", "1YR_ACH_PTS_ELIG_MATH", "1YR_ACH_PTS_ELIG_WRITE", "1YR_ACH_PTS_ELIG_SCI" }, errors);
			AssertSum(row, "3YR_ACH_PTS_ELIG_TTL", new[] { "3YR_ACH_PTS_ELIG_READ", "3YR_ACH_PTS_ELIG_MATH", "3YR_ACH_PTS_ELIG_WRITE", "3YR_ACH_PTS_ELIG_SCI" }, errors);
		}
	}
}