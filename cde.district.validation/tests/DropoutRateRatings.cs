using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class DropoutRateRatings : BaseTest
	{
		public override void Test(Row row, List<string> errors)
		{
			AssertRating(row, "RDPF_1YR_PS_DROP_RATING", "RDPF_1YR_PS_DROP_RATE", Rating1, errors);
			AssertRating(row, "RDPF_3YR_PS_DROP_RATING", "RDPF_3YR_PS_DROP_RATE", Rating3, errors);
		}

		string Rating1(double value)
		{
			if (value <= 1.0) return Exceeds;
			if (value <= 3.6) return Meets;
			if (value <= 10.0) return Approaching;
			return DoesNotMeet;
		}

		string Rating3(double value)
		{
			if (value <= 1.0) return Exceeds;
			if (value <= 3.9) return Meets;
			if (value <= 10) return Approaching;
			return DoesNotMeet;
		}
	}
}
