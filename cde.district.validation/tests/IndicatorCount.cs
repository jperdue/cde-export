using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
    public class IndicatorCount : BaseTest
    {
        HashSet<string> countableValues;
        HashSet<string> CountableValues
        {
            get
            {
                if (countableValues == null)
                {
                    countableValues = new HashSet<string>
                    {
                        "Approaching", "Meets", "Does Not Meet", "Exceeds"
                    };
                }
                return countableValues;
            }
        }

        public override void Test(Row row, Errors errors)
        {
            var oneYear = new[] { "1YR_ACHIEVE_RATING", "1YR_GROWTH_RATING", "1YR_GRO_GAPS_RATING", "1YR_POST_SEC_RATING" };
            AssertRating(row, "1YR_INDICATOR_NCOUNT", oneYear, errors, GetIndicatorCount);

            var threeYear = new[] { "3YR_ACHIEVE_RATING", "3YR_GROWTH_RATING", "3YR_GRO_GAPS_RATING", "3YR_POST_SEC_RATING" };
            AssertRating(row, "3YR_INDICATOR_NCOUNT", threeYear, errors, GetIndicatorCount);
        }

        int GetIndicatorCount(Row row, IEnumerable<string> columns)
        {
            if (row.Level == "E" && row.Level == "M")
            {
                columns = columns.Take(3);
            }
            return columns.Where(c => CountableValues.Contains(row[c])).Count();
        }
    }
}
