using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class ParticipationRatingCounter : BaseTest
	{
		public override void Test(Row row, Errors errors)
		{
			var oneYear = new[] { "1YR_PARTIC_RATING_READ", "1YR_PARTIC_RATING_MATH", "1YR_PARTIC_RATING_WRITE", "1YR_PARTIC_RATING_SCI", "1YR_PARTIC_RATING_ACT" };
			AssertRating(row, "1YR_TEST_PARTIC_DNM_COUNT", oneYear, errors, GetParticipationCount);

			var threeYear = new[] { "3YR_PARTIC_RATING_READ", "3YR_PARTIC_RATING_MATH", "3YR_PARTIC_RATING_WRITE", "3YR_PARTIC_RATING_SCI", "3YR_PARTIC_RATING_ACT" };
			AssertRating(row, "3YR_TEST_PARTIC_DNM_COUNT", threeYear, errors, GetParticipationCount);
		}

        protected override bool AssertRating(Row row, string ratingColumn, string valueColumn, Func<double, string> ratingLookup, Errors errors, bool passIfBlank = false)
        {
            if (!Defined(row, ratingColumn, errors))
            {
                return true;
            }

            return base.AssertRating(row, ratingColumn, valueColumn, ratingLookup, errors, passIfBlank);
        }

		int GetParticipationCount(Row row, IEnumerable<string> columns)
		{
			return columns.Where(c => row[c] == DoesNotMeet).Count();
		}
	}
}
