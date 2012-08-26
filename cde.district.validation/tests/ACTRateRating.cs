using cde.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class ACTRateRating : BaseTest
	{
		public override void Test(Row row, List<string> errors)
		{
			AssertRating(row, "RDPF_1YR_PS_ACT_RATING", "RDPF_1YR_PS_ACT_SCORE", Rating1, errors);
			AssertRating(row, "RDPF_3YR_PS_ACT_RATING", "RDPF_3YR_PS_ACT_SCORE", Rating3, errors);
		}

		string Rating1(double value)
		{
			if (value >= 22) return Exceeds;
			if (value >= 20) return Meets;
			if (value >= 17) return Approaching;
			return DoesNotMeet;
		}

		string Rating3(double value)
		{
			if (value >= 22) return Exceeds;
			if (value >= 20.1) return Meets;
			if (value >= 17) return Approaching;
			return DoesNotMeet;
		}
	}
}
