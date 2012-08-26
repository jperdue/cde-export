using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class OverallRatings : BaseTest
	{
		IEnumerable<Tuple<string, string>> TotalColumns
		{
			get
			{				
				yield return new Tuple<string, string>("RDPF_1_3_TOTAL_RATING", "RDPF_1_3_TOTAL_PCT_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_1_3_TOTAL_RATING", "RDPF_1YR_TOTAL_PCT_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_1_3_TOTAL_RATING", "RDPF_3YR_TOTAL_PCT_PTS_EARN");
			}
		}

		IEnumerable<Tuple<string, string>> SPFColumns
		{
			get
			{
				yield return new Tuple<string, string>("RDPF_A_TTL_SPF_RATING_CALC", "RDPF_1_3_TOTAL_PCT_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_A_TTL_SPF_RATING_OFFICIAL", "RDPF_1_3_TOTAL_PCT_PTS_EARN");
			}
		}

		public override void Test(Row row, List<string> errors)
		{
			TotalColumns.ForEach(t => AssertRating(row, t.Item1, t.Item2, GetTotalRating, errors));
			SPFColumns.ForEach(t => AssertRating(row, t.Item1, t.Item2, GetSPFRating, errors));
		}

		string GetTotalRating(double value)
		{
			if (value < 42.0) return "Turnaround";
			if (value < 54.0) return "Priority Improvement";
			if (value <64.0) return "Improvement"
			if (value < 80.0) return "Performance";
			return "Distinction";
		}

		string GetSPFRating(double value)
		{
			if (value < 42.0) return "Accredited with Turnaround Plan";
			if (value < 52.0) return "Accredited with Priority Improvement Plan";
			if (value < 64.0) return "Accredited with Improvement Plan";
			if (value < 80.0) return "Accredited with Performance Plan";
			return "Accredited with Distinction Plan";
		}
	}
}
