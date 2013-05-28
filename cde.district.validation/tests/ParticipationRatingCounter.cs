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
			AssertRating(row, "1YR_TEST_PARTIC_DNM_COUNT", oneYear, errors);

			var threeYear = new[] { "3YR_PARTIC_RATING_READ", "3YR_PARTIC_RATING_MATH", "3YR_PARTIC_RATING_WRITE", "3YR_PARTIC_RATING_SCI", "3YR_PARTIC_RATING_ACT" };
			AssertRating(row, "3YR_TEST_PARTIC_DNM_COUNT", threeYear, errors);
		}

		bool AssertRating(Row row, string countColumn, string[] valueColumns, Errors errors)
		{
            if(!AssertDefined(row, countColumn, errors))
            {
                return false;
            }

			var participationCount = row[countColumn];
			var expectedParticipationCount = GetParticipationCount(row, valueColumns).ToString();
			var message = "Sum of Participation columns (" + expectedParticipationCount + ") does not match the value in '" + countColumn + "' (" + participationCount + ")";
			return AssertTrue(row, participationCount == expectedParticipationCount, message, errors);
		}

		int GetParticipationCount(Row row, IEnumerable<string> columns)
		{
			return columns.Where(c => row[c] == DoesNotMeet).Count();
		}
	}
}
