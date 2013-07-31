using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
    class ParticipationOverallMet : BaseTest
    {
        public IEnumerable<Tuple<string, string>> Columns
        {
            get
            {
                yield return new Tuple<string, string>("1YR_TEST_PARTIC_DNM_COUNT", "1YR_TEST_PARTIC_RATING");
                yield return new Tuple<string, string>("3YR_TEST_PARTIC_DNM_COUNT", "3YR_TEST_PARTIC_RATING");
                yield return new Tuple<string, string>("1_3_PARTIC_DNM_COUNT", "1_3_PARTIC_RATING");
            }
        }

        public override void Test(Row row, Errors errors)
        {
            Columns.ForEach(t => AssertMet(row, t.Item1, t.Item2, errors));
        }

        bool AssertMet(Row row, string countColumn, string ratingColumn, Errors errors)
        {
            if(!Defined(row, countColumn, errors) ||
                !Defined(row, ratingColumn, errors))
            {
                return true;
            }

            double count;
            if (!AssertNumber(row, countColumn, out count, errors))
            {
                return false;
            }

            var rating = row[ratingColumn];
            var expectedRating = count >= 2 ?  "Does Not Meet 95% Participation Rate" : "Meets 95% Participation Rate";
            
            return AssertTrue(row, rating == expectedRating, "Count does not line up with rating (" + ratingColumn + ")", errors);
        }
    }
}
