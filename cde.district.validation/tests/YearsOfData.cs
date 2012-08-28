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
			var oneYear = row["RDPF_1_3_RATING_YEAR_USED"] == "1 Year" && row["RDPF_1_3_YEARS_OF_DATA"] == "2011-12";
			var threeYear = row["RDPF_1_3_RATING_YEAR_USED"] == "3 Year" && row["RDPF_1_3_YEARS_OF_DATA"] == "2009-10,2010-11,2011-12";

			AssertTrue(row, oneYear || threeYear, "RDPF_1_3_RATING_YEAR_USED", errors);
			AssertTrue(row, row["RDPF_1YR_YEARS_OF_DATA"] == "2011-12", "RDPF_1YR_YEARS_OF_DATA", errors);
			AssertTrue(row, row["RDPF_3YR_YEARS_OF_DATA"] == "2009-10,2010-11,2011-12", "RDPF_3YR_YEARS_OF_DATA", errors);
		}
	}
}