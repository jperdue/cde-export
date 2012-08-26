using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class ParticipationRating : BaseTest
	{
		IEnumerable<Tuple<string, string, string>> ParticipationColumns
		{
			get
			{
				yield return new Tuple<string, string, string>("RDPF_1YR_PARTIC_PCT_TEST_READ", "RDPF_1YR_PARTIC_NM_READ", "RDPF_1YR_PARTIC_DN_READ");
				yield return new Tuple<string, string, string>("RDPF_1YR_PARTIC_PCT_TEST_MATH", "RDPF_1YR_PARTIC_NM_MATH", "RDPF_1YR_PARTIC_DN_MATH");
				yield return new Tuple<string, string, string>("RDPF_1YR_PARTIC_PCT_TEST_WRITE", "RDPF_1YR_PARTIC_NM_WRITE", "RDPF_1YR_PARTIC_DN_WRITE");
				yield return new Tuple<string, string, string>("RDPF_1YR_PARTIC_PCT_TEST_SCI", "RDPF_1YR_PARTIC_NM_SCI", "RDPF_1YR_PARTIC_DN_SCI");
				yield return new Tuple<string, string, string>("RDPF_1YR_PARTIC_PCT_TEST_ACT", "RDPF_1YR_PARTIC_NM_ACT", "RDPF_1YR_PARTIC_DN_ACT");
				yield return new Tuple<string, string, string>("RDPF_3YR_PARTIC_PCT_TEST_READ", "RDPF_3YR_PARTIC_NM_READ", "RDPF_3YR_PARTIC_DN_READ");
				yield return new Tuple<string, string, string>("RDPF_3YR_PARTIC_PCT_TEST_MATH", "RDPF_3YR_PARTIC_NM_MATH", "RDPF_3YR_PARTIC_DN_MATH");
				yield return new Tuple<string, string, string>("RDPF_3YR_PARTIC_PCT_TEST_WRITE", "RDPF_3YR_PARTIC_NM_WRITE", "RDPF_3YR_PARTIC_DN_WRITE");
				yield return new Tuple<string, string, string>("RDPF_3YR_PARTIC_PCT_TEST_SCI", "RDPF_3YR_PARTIC_NM_SCI", "RDPF_3YR_PARTIC_DN_SCI");
				yield return new Tuple<string, string, string>("RDPF_3YR_PARTIC_PCT_TEST_ACT", "RDPF_3YR_PARTIC_NM_ACT", "RDPF_3YR_PARTIC_DN_ACT");
			}
		}

		IEnumerable<Tuple<string, string>> ParticipationRateColumns
		{
			get
			{
				yield return new Tuple<string, string>("RDPF_1YR_PARTIC_PCT_TEST_READ", "RDPF_1YR_PARTIC_RATING_READ");
				yield return new Tuple<string, string>("RDPF_1YR_PARTIC_PCT_TEST_MATH", "RDPF_1YR_PARTIC_RATING_MATH");
				yield return new Tuple<string, string>("RDPF_1YR_PARTIC_PCT_TEST_WRITE", "RDPF_1YR_PARTIC_RATING_WRITE");
				yield return new Tuple<string, string>("RDPF_1YR_PARTIC_PCT_TEST_SCI", "RDPF_1YR_PARTIC_RATING_SCI");
				yield return new Tuple<string, string>("RDPF_1YR_PARTIC_PCT_TEST_ACT", "RDPF_1YR_PARTIC_RATING_ACT");
				yield return new Tuple<string, string>("RDPF_3YR_PARTIC_PCT_TEST_READ", "RDPF_3YR_PARTIC_RATING_READ");
				yield return new Tuple<string, string>("RDPF_3YR_PARTIC_PCT_TEST_MATH", "RDPF_3YR_PARTIC_RATING_MATH");
				yield return new Tuple<string, string>("RDPF_3YR_PARTIC_PCT_TEST_WRITE", "RDPF_3YR_PARTIC_RATING_WRITE");
				yield return new Tuple<string, string>("RDPF_3YR_PARTIC_PCT_TEST_SCI", "RDPF_3YR_PARTIC_RATING_SCI");
				yield return new Tuple<string, string>("RDPF_3YR_PARTIC_PCT_TEST_ACT", "RDPF_3YR_PARTIC_RATING_ACT");
			}
		}

		public override void Test(Row row, List<string> errors)
		{
			AssertRating(row, "RDPF_1_3_PARTIC_RATING", "RDPF_1_3_PARTIC_DNM_COUNT", Rating, errors);
			AssertRating(row, "RDPF_1YR_PARTIC_RATING", "RDPF_1YR_PARTIC_DNM_COUNT", Rating, errors);
			AssertRating(row, "RDPF_3YR_PARTIC_RATING", "RDPF_3YR_PARTIC_DNM_COUNT", Rating, errors);

			ParticipationColumns.ForEach(t => AssertDivide(row, t.Item1, t.Item2, t.Item3, errors));

			ParticipationRateColumns.ForEach(t => AssertRating(row, t.Item2, t.Item1, RatingParticipation, errors));
		}

		string Rating(double value)
		{
			if (value <= 2.0) return "Meets 95% Participation Rate";
			return "Does Not Meet 95% Participation Rate";
		}

		string RatingParticipation(double value)
		{
			if (value >= 94.45) return Meets;
			return DoesNotMeet;
		}
	}
}
