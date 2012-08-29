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
				yield return new Tuple<string, string, string>("RDPF_1YR_PARTIC_RATING_READ", "RDPF_1YR_PARTIC_PCT_TEST_READ", "RDPF_1YR_PARTIC_DN_READ");
				yield return new Tuple<string, string, string>("RDPF_1YR_PARTIC_RATING_MATH", "RDPF_1YR_PARTIC_PCT_TEST_MATH", "RDPF_1YR_PARTIC_DN_MATH");
				yield return new Tuple<string, string, string>("RDPF_1YR_PARTIC_RATING_WRITE", "RDPF_1YR_PARTIC_PCT_TEST_WRITE", "RDPF_1YR_PARTIC_DN_WRITE");
				yield return new Tuple<string, string, string>("RDPF_1YR_PARTIC_RATING_SCI", "RDPF_1YR_PARTIC_PCT_TEST_SCI", "RDPF_1YR_PARTIC_DN_SCI");
				yield return new Tuple<string, string, string>("RDPF_1YR_PARTIC_RATING_ACT", "RDPF_1YR_PARTIC_PCT_TEST_ACT", "RDPF_1YR_PARTIC_DN_ACT");

				yield return new Tuple<string, string, string>("RDPF_3YR_PARTIC_RATING_READ", "RDPF_3YR_PARTIC_PCT_TEST_READ", "RDPF_3YR_PARTIC_DN_READ");
				yield return new Tuple<string, string, string>("RDPF_3YR_PARTIC_RATING_MATH", "RDPF_3YR_PARTIC_PCT_TEST_MATH", "RDPF_3YR_PARTIC_DN_MATH");
				yield return new Tuple<string, string, string>("RDPF_3YR_PARTIC_RATING_WRITE", "RDPF_3YR_PARTIC_PCT_TEST_WRITE", "RDPF_3YR_PARTIC_DN_WRITE");
				yield return new Tuple<string, string, string>("RDPF_3YR_PARTIC_RATING_SCI", "RDPF_3YR_PARTIC_PCT_TEST_SCI", "RDPF_3YR_PARTIC_DN_SCI");
				yield return new Tuple<string, string, string>("RDPF_3YR_PARTIC_RATING_ACT", "RDPF_3YR_PARTIC_PCT_TEST_ACT", "RDPF_3YR_PARTIC_DN_ACT");
			}
		}

		public override void Test(Row row, Errors errors)
		{
			ParticipationRateColumns.ForEach(t => Assert(row, t.Item1, t.Item2, t.Item3, errors));
		}
	
		bool Assert(Row row, string ratingColumn, string valueColumn, string denominatorColumn, Errors errors)
		{
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
