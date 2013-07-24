using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
    public class IndicatorCount : BaseTest
    {
        public override void Test(Row row, Errors errors)
        {
            var oneYear = new[] { "1YR_ACHIEVE_RATING", "1YR_GROWTH_RATING", "1YR_GRO_GAPS_RATING", "1YR_POST_SEC_RATING" };
            AssertRating(row, "1YR_INDICATOR_NCOUNT", oneYear, errors, GetIndicatorCount);

            var threeYear = new[] { "3YR_ACHIEVE_RATING", "3YR_GROWTH_RATING", "3YR_GRO_GAPS_RATING", "3YR_POST_SEC_RATING" };
            AssertRating(row, "3YR_INDICATOR_NCOUNT", threeYear, errors, GetIndicatorCount);
        }

        int GetIndicatorCount(Row row, IEnumerable<string> columns)
        {
            return columns.Where(c => row[c] == " " || row[c] == "-").Count();
        }
    }
}
