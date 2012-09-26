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
			if (row.Type == EDataType.District)
			{
				AssertRating(row, "1YR_PS_ACT_RATING", "1YR_PS_ACT_SCORE", Rating1District, errors);
				AssertRating(row, "3YR_PS_ACT_RATING", "3YR_PS_ACT_SCORE", Rating3District, errors);
			}
			else
			{
				AssertRating(row, "1YR_PS_ACT_RATING", "1YR_PS_ACT_SCORE", Rating1School, errors);
				AssertRating(row, "3YR_PS_ACT_RATING", "3YR_PS_ACT_SCORE", Rating3School, errors);				
			}
		}

		protected override bool AssertRating(Row row, string ratingColumn, string valueColumn, Func<double, string> ratingLookup, Errors errors, bool passIfBlank = false)
		{
			if (!Defined(row, ratingColumn, errors) && !Defined(row, valueColumn, errors)) return true;

			return base.AssertRating(row, ratingColumn, valueColumn, ratingLookup, errors);
		}

		string Rating1District(double value)
		{
			if (value >= 22) return Exceeds;
			if (value >= 20) return Meets;
			if (value >= 17) return Approaching;
			return DoesNotMeet;
		}

		string Rating3District(double value)
		{
			if (value >= 22) return Exceeds;
			if (value >= 20.1) return Meets;
			if (value >= 17) return Approaching;
			return DoesNotMeet;
		}

		string Rating1School(double value)
		{
			if (value >= 22) return Exceeds;
			if (value >= 20) return Meets;
			if (value >= 17) return Approaching;
			return DoesNotMeet;
		}

		string Rating3School(double value)
		{
			if (value >= 22) return Exceeds;
			if (value >= 20.1) return Meets;
			if (value >= 17) return Approaching;
			return DoesNotMeet;
		}
	}
}
