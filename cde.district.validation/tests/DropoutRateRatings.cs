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
			if (row.Type == EDataType.District)
			{
				AssertRating(row, "1YR_PS_DROP_RATING", "1YR_PS_DROP_RATE", Rating1District, errors);
				AssertRating(row, "3YR_PS_DROP_RATING", "3YR_PS_DROP_RATE", Rating3District, errors);
			}
			else
			{
				AssertRating(row, "1YR_PS_DROP_RATING", "1YR_PS_DROP_RATE", Rating1School, errors);
				AssertRating(row, "3YR_PS_DROP_RATING", "3YR_PS_DROP_RATE", Rating3School, errors);			
			}
		}

		string Rating1District(double value)
		{
			if (value <= 1.0) return Exceeds;
			if (value <= 3.6) return Meets;
			if (value <= 10.0) return Approaching;
			return DoesNotMeet;
		}

		string Rating3District(double value)
		{
			if (value <= 1.0) return Exceeds;
			if (value <= 3.9) return Meets;
			if (value <= 10) return Approaching;
			return DoesNotMeet;
		}
		
		string Rating1School(double value)
		{
			if (value <= 1.0) return Exceeds;
			if (value <= 3.6) return Meets;
			if (value <= 10.0) return Approaching;
			return DoesNotMeet;
		}

		string Rating3School(double value)
		{
			if (value <= 1.0) return Exceeds;
			if (value <= 3.9) return Meets;
			if (value <= 10) return Approaching;
			return DoesNotMeet;
		}
	}
}
