using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class IndicatorRating : BaseTest
	{
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
				yield return new Tuple<string, string>("RDPF_1YR_ACH_RATING_TTL", "RDPF_1YR_ACH_PCT_PTS_EARN_TTL");
				yield return new Tuple<string, string>("RDPF_3YR_ACH_RATING_TTL", "RDPF_3YR_ACH_PCT_PTS_EARN_TTL");
				yield return new Tuple<string, string>("RDPF_1YR_GRO_RATING_TTL", "RDPF_1YR_GRO_PCT_PTS_EARN_TTL");
				yield return new Tuple<string, string>("RDPF_3YR_GRO_RATING_TTL", "RDPF_3YR_GRO_PCT_PTS_EARN_TTL");
				yield return new Tuple<string, string>("RDPF_1YR_GG_RATING_READ", "RDPF_1YR_GG_PCT_PTS_EARN_READ");
				yield return new Tuple<string, string>("RDPF_3YR_GG_RATING_READ", "RDPF_3YR_GG_PCT_PTS_EARN_READ");
				yield return new Tuple<string, string>("RDPF_1YR_GG_RATING_MATH", "RDPF_1YR_GG_PCT_PTS_EARN_MATH");
				yield return new Tuple<string, string>("RDPF_3YR_GG_RATING_MATH", "RDPF_3YR_GG_PCT_PTS_EARN_MATH");
				yield return new Tuple<string, string>("RDPF_1YR_GG_RATING_WRITE", "RDPF_1YR_GG_PCT_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("RDPF_3YR_GG_RATING_WRITE", "RDPF_3YR_GG_PCT_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("RDPF_1YR_GG_RATING_TTL", "RDPF_1YR_GG_PCT_PTS_EARN_TTL");
				yield return new Tuple<string, string>("RDPF_3YR_GG_RATING_TTL", "RDPF_3YR_GG_PCT_PTS_EARN_TTL");
				yield return new Tuple<string, string>("RDPF_1YR_PS_GRAD_DSAG_RATING", "RDPF_1YR_PS_GRAD_DSAG_PCT_PTS");
				yield return new Tuple<string, string>("RDPF_3YR_PS_GRAD_DSAG_RATING", "RDPF_3YR_PS_GRAD_DSAG_PCT_PTS");
				yield return new Tuple<string, string>("RDPF_1YR_PS_RATING_TTL", "RDPF_1YR_PS_PCT_PTS_EARN_TTL");
				yield return new Tuple<string, string>("RDPF_3YR_PS_RATING_TTL", "RDPF_3YR_PS_PCT_PTS_EARN_TTL");
			}
		}

		public override void Test(Row row, Errors errors)
		{
			Columns.ForEach(t => AssertRating(row, t.Item1, t.Item2, Rating, errors));
		}

		string Rating(double percent)
		{
			if (percent < 37.5) return "Does Not Meet";
			if (percent < 62.5) return "Approaching";
			if (percent < 87.5) return "Meets";
			return "Exceeds";
		}
	}
}
