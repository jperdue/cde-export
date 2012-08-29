using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class OverallOfficialRating : BaseTest
	{
		IEnumerable<Tuple<string, string>> Columns
		{
			get
			{
				yield return new Tuple<string, string>("RDPF_A_TTL_DPF_RATING_CALC", "RDPF_1_3_TOTAL_PCT_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_A_TTL_DPF_RATING_OFFICIAL", "RDPF_1_3_TOTAL_PCT_PTS_EARN");
			}
		}

		public override void Test(Row row, Errors errors)
		{
			Columns.ForEach(t => AssertRating(row, t.Item1, t.Item2, Rating, errors));
		}

		protected override bool AssertRating(Row row, string ratingColumn, string valueColumn, Func<double, string> ratingLookup, Errors errors, bool passIfBlank = false)
		{

			return base.AssertRating(row, ratingColumn, valueColumn, ratingLookup, errors, passIfBlank);
		}

		string Rating(double value)
		{
			if (value < 42.0) return "Accredited with Turnaround Plan";
			if (value < 52.0) return "Accredited w/Priority Improvement Plan";
			if (value < 64.0) return "Accredited with Improvement Plan";
			if (value < 80.0) return "Accredited";
			return "Accredited with Distinction";
		}
	}
}
