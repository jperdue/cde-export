using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class YearsOfData : BaseTest
	{
		public override void Test(Row row, Errors errors)
		{
            var requiredColumns = new[] { "1_3_RATING_YEAR_USED", "1_3_YEARS_OF_DATA", "1YR_YEARS_OF_DATA", "3YR_YEARS_OF_DATA" };
            if (requiredColumns.All(c => !AssertDefined(row, c, errors)))
            {
                return;
            }

            var year = DateTime.Now.Year;
            var expectedOneYear = OneYear(year);
            var expectedThreeYear = ThreeYear(year);

			var oneYear = row["1_3_RATING_YEAR_USED"] == "1 Year" && row["1_3_YEARS_OF_DATA"] == expectedOneYear;
			var threeYear = row["1_3_RATING_YEAR_USED"] == "3 Year" && row["1_3_YEARS_OF_DATA"] == expectedThreeYear;

			AssertTrue(row, oneYear || threeYear, "1_3_RATING_YEAR_USED", errors);
			AssertTrue(row, row["1YR_YEARS_OF_DATA"] == expectedOneYear, "1YR_YEARS_OF_DATA", errors);
			AssertTrue(row, row["3YR_YEARS_OF_DATA"] == expectedThreeYear, "3YR_YEARS_OF_DATA", errors);
		}

        public string OneYear(int year)
        {
            return (year-1).ToString() + "-" + year.ToString().Substring(2);
        }

        public string ThreeYear(int year)
        {
            return OneYear(year - 2) + ","
                 + OneYear(year - 1) + ","
                 + OneYear(year);
        }
	}
}