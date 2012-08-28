using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class ACTRateRating : BaseTest
	{
		public override void Test(Row row, Errors errors)
		{
			AssertRating(row, "RDPF_1YR_PS_ACT_RATING", "RDPF_1YR_PS_ACT_SCORE", Rating1, errors);
			AssertRating(row, "RDPF_3YR_PS_ACT_RATING", "RDPF_3YR_PS_ACT_SCORE", Rating3, errors);
		}

		protected override bool AssertRating(Row row, string ratingColumn, string percentOfPointsRatingColumn, Func<double, string> ratingLookup, Errors errors)
		{
			if (!Defined(row, ratingColumn) && !Defined(row, percentOfPointsRatingColumn)) return true;

			return base.AssertRating(row, ratingColumn, percentOfPointsRatingColumn, ratingLookup, errors);
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
