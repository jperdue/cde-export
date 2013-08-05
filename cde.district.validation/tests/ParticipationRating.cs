using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class ParticipationRating : BaseTest
	{
		IEnumerable<Tuple<string, string, string>> ParticipationRateColumns
		{
			get
			{
				yield return new Tuple<string, string, string>("1YR_PARTIC_RATING_READ", "1YR_PARTIC_PCT_TEST_READ", "1YR_PARTIC_DN_READ");
				yield return new Tuple<string, string, string>("1YR_PARTIC_RATING_MATH", "1YR_PARTIC_PCT_TEST_MATH", "1YR_PARTIC_DN_MATH");
				yield return new Tuple<string, string, string>("1YR_PARTIC_RATING_WRITE", "1YR_PARTIC_PCT_TEST_WRITE", "1YR_PARTIC_DN_WRITE");
				yield return new Tuple<string, string, string>("1YR_PARTIC_RATING_SCI", "1YR_PARTIC_PCT_TEST_SCI", "1YR_PARTIC_DN_SCI");
				yield return new Tuple<string, string, string>("1YR_PARTIC_RATING_ACT", "1YR_PARTIC_PCT_TEST_ACT", "1YR_PARTIC_DN_ACT");

				yield return new Tuple<string, string, string>("3YR_PARTIC_RATING_READ", "3YR_PARTIC_PCT_TEST_READ", "3YR_PARTIC_DN_READ");
				yield return new Tuple<string, string, string>("3YR_PARTIC_RATING_MATH", "3YR_PARTIC_PCT_TEST_MATH", "3YR_PARTIC_DN_MATH");
				yield return new Tuple<string, string, string>("3YR_PARTIC_RATING_WRITE", "3YR_PARTIC_PCT_TEST_WRITE", "3YR_PARTIC_DN_WRITE");
				yield return new Tuple<string, string, string>("3YR_PARTIC_RATING_SCI", "3YR_PARTIC_PCT_TEST_SCI", "3YR_PARTIC_DN_SCI");
				yield return new Tuple<string, string, string>("3YR_PARTIC_RATING_ACT", "3YR_PARTIC_PCT_TEST_ACT", "3YR_PARTIC_DN_ACT");
			}
		}

		public override void Test(Row row, Errors errors)
		{
			ParticipationRateColumns.ForEach(t => Assert(row, t.Item1, t.Item2, t.Item3, errors));
		}
	
		bool Assert(Row row, string ratingColumn, string valueColumn, string denominatorColumn, Errors errors)
		{
            if (row.Level == "A" && denominatorColumn.EndsWith("_DN_ACT"))
            {
                return true;
            }

            if(!AssertDefined(row, denominatorColumn, errors))
            {
                return false;
            }

			double value;
			if(double.TryParse(row[denominatorColumn], out value))
			{
				if(value < 20)
				{
					return true;
				}
				return AssertRating(row, ratingColumn, valueColumn, RatingParticipation, errors);
			}
			return false;
		}

		protected override bool AssertRating(Row row, string ratingColumn, string valueColumn, Func<double, string> ratingLookup, Errors errors, bool passIfBlank = false)
		{
			if(!Defined(row, ratingColumn, errors) && !Defined(row, valueColumn, errors))
			{
				return true;
			}

			return base.AssertRating(row, ratingColumn, valueColumn, ratingLookup, errors, passIfBlank);
		}

		string RatingParticipation(double value)
		{
			if (value >= 94.5) return Meets;
			return DoesNotMeet;
		}
	}
}
