using cde.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class IndicatorRating : BaseTest
	{
		const string DoesNotMeet = "Does Not Meet";
		const string Approaching = "Approaching";
		const string Meets = "Meets";
		const string Exceeds = "Exceeds";

		IEnumerable<Tuple<string, string>> Columns
		{
			get
			{
				yield return new Tuple<string, string>("RDPF_1_3_ACHIEVE_RATING", "RDPF_1_3_ACHIEVE_PCT_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_1_3_GROWTH_RATING", "RDPF_1_3_GROWTH_PCT_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_1_3_GRO_GAPS_RATING", "RDPF_1_3_GRO_GAPS_PCT_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_1_3_POST_SEC_RATING", "RDPF_1_3_POST_SEC_PCT_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_1YR_ACHIEVE_RATING", "RDPF_1YR_ACHIEVE_PCT_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_1YR_GROWTH_RATING", "RDPF_1YR_GROWTH_PCT_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_1YR_GRO_GAPS_RATING", "RDPF_1YR_GRO_GAPS_PCT_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_1YR_POST_SEC_RATING", "RDPF_1YR_POST_SEC_PCT_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_3YR_ACHIEVE_RATING", "RDPF_3YR_ACHIEVE_PCT_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_3YR_GROWTH_RATING", "RDPF_3YR_GROWTH_PCT_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_3YR_GRO_GAPS_RATING", "RDPF_3YR_GRO_GAPS_PCT_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_3YR_POST_SEC_RATING", "RDPF_3YR_POST_SEC_PCT_PTS_EARN");
			}
		}

		public override void Test(Row row, List<string> errors)
		{
			Columns.ForEach(t => CheckRating(row, t.Item1, t.Item2, errors));
		}

		void CheckRating(Row row, string ratingColumn, string percentOfPointsRatingColumn, List<string> errors)
		{
			if (AssertUndefined(row, ratingColumn, errors) &&
				AssertUndefined(row, percentOfPointsRatingColumn, errors))
			{
				var rating = row[ratingColumn];
				var percent = double.Parse(row[percentOfPointsRatingColumn]);
				var expectedRating = Rating(percent);

				var message = rating + " != " + expectedRating + " (" + percent + "%) for " + ratingColumn + ", " + percentOfPointsRatingColumn;
				AssertThat(row, rating == expectedRating, message, errors);
			}
		}

		string Rating(double percent)
		{
			if (percent < 37.5) return DoesNotMeet;
			if (percent < 62.5) return Approaching;
			if (percent < 87.5) return Meets;
			return Exceeds;
		}
	}
}
