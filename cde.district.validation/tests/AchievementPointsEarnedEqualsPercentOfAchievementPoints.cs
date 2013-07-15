using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class AchievementPointsEarnedEqualsPercentOfAchievementPoints : BaseTest
	{
		public override void Test(Row row, Errors errors)
		{
			AssertDivide(row, "1YR_ACH_PCT_PTS_EARN_TTL", "1YR_ACH_PTS_EARN_TTL", "1YR_ACH_PTS_ELIG_TTL", errors);
			AssertDivide(row, "3YR_ACH_PCT_PTS_EARN_TTL", "3YR_ACH_PTS_EARN_TTL", "3YR_ACH_PTS_ELIG_TTL", errors);
		}

        protected override bool AssertDivide(Row row, string resultColumn, string numeratorColumn, string denominatorColumn, Errors errors)
        {
            if (!Defined(row, numeratorColumn, errors))
            {
                return true;
            }

            return base.AssertDivide(row, resultColumn, numeratorColumn, denominatorColumn, errors);
        }
	}
}
