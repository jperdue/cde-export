using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class PercentOfPoints : BaseTest
	{
		IEnumerable<Tuple<string, string, string>> Columns
		{
			get
			{				
				yield return new Tuple<string, string, string>("RDPF_1_3_ACHIEVE_PCT_PTS_EARN", "RDPF_1_3_ACHIEVE_PTS_ELIG", "RDPF_1_3_ACHIEVE_PTS_EARN");
				yield return new Tuple<string, string, string>("RDPF_1_3_GROWTH_PCT_PTS_EARN", "RDPF_1_3_GROWTH_PTS_ELIG", "RDPF_1_3_GROWTH_PTS_EARN");
				yield return new Tuple<string, string, string>("RDPF_1_3_GRO_GAPS_PCT_PTS_EARN", "RDPF_1_3_GRO_GAPS_PTS_ELIG", "RDPF_1_3_GRO_GAPS_PTS_EARN");
				yield return new Tuple<string, string, string>("RDPF_1_3_POST_SEC_PCT_PTS_EARN", "RDPF_1_3_POST_SEC_PTS_ELIG", "RDPF_1_3_POST_SEC_PTS_EARN");
				yield return new Tuple<string, string, string>("RDPF_1YR_ACHIEVE_PCT_PTS_EARN", "RDPF_1YR_ACHIEVE_PTS_ELIG", "RDPF_1YR_ACHIEVE_PTS_EARN");
				yield return new Tuple<string, string, string>("RDPF_1YR_GROWTH_PCT_PTS_EARN", "RDPF_1YR_GROWTH_PTS_ELIG", "RDPF_1YR_GROWTH_PTS_EARN");
				yield return new Tuple<string, string, string>("RDPF_1YR_GRO_GAPS_PCT_PTS_EARN", "RDPF_1YR_GRO_GAPS_PTS_ELIG", "RDPF_1YR_GRO_GAPS_PTS_EARN");
				yield return new Tuple<string, string, string>("RDPF_1YR_POST_SEC_PCT_PTS_EARN", "RDPF_1YR_POST_SEC_PTS_ELIG", "RDPF_1YR_POST_SEC_PTS_EARN");
				yield return new Tuple<string, string, string>("RDPF_3YR_ACHIEVE_PCT_PTS_EARN", "RDPF_3YR_ACHIEVE_PTS_ELIG", "RDPF_3YR_ACHIEVE_PTS_EARN");
				yield return new Tuple<string, string, string>("RDPF_3YR_GROWTH_PCT_PTS_EARN", "RDPF_3YR_GROWTH_PTS_ELIG", "RDPF_3YR_GROWTH_PTS_EARN");
				yield return new Tuple<string, string, string>("RDPF_3YR_GRO_GAPS_PCT_PTS_EARN", "RDPF_3YR_GRO_GAPS_PTS_ELIG", "RDPF_3YR_GRO_GAPS_PTS_EARN");
				yield return new Tuple<string, string, string>("RDPF_3YR_POST_SEC_PCT_PTS_EARN", "RDPF_3YR_POST_SEC_PTS_ELIG", "RDPF_3YR_POST_SEC_PTS_EARN");
			}
		}

		public override void Test(Row row, List<string> errors)
		{
			Columns.ForEach(t => CheckPointsEarned(row, t.Item1, t.Item2, t.Item3, errors));
		}

		void CheckPointsEarned(Row row, string percentPointsColumn, string pointsEligibleColumn, string pointsEarnedColumn, List<string> errors)
		{
			if (AssertDefined(row, new[] { percentPointsColumn, pointsEligibleColumn, pointsEarnedColumn }, errors))
			{
				var percentPoints = double.Parse(row[percentPointsColumn]);
				var pointsEligible = double.Parse(row[pointsEligibleColumn]);
				var pointsEarned = double.Parse(row[pointsEarnedColumn]);

				AssertTrue(row, percentPoints * pointsEligible / 100.0 == pointsEarned, percentPointsColumn + ", " + pointsEligibleColumn + ", " + pointsEarnedColumn, errors);
			}
		}
	}
}
