using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class DropoutRateRatings : BaseTest
	{
		public override void Test(Row row, Errors errors)
		{
			AssertRating(row, "1YR_PS_DROP_RATING", "1YR_PS_DROP_RATE", Rating1, errors);
			AssertRating(row, "3YR_PS_DROP_RATING", "3YR_PS_DROP_RATE", Rating3, errors);
		}

        protected override bool AssertRating(Row row, string ratingColumn, string valueColumn, Func<double, string> ratingLookup, Errors errors, bool passIfBlank = false)
        {
            if (!Defined(row, ratingColumn, errors))
            {
                return true;
            }

            return base.AssertRating(row, ratingColumn, valueColumn, ratingLookup, errors, passIfBlank);
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
