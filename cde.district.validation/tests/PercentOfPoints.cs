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
				yield return new Tuple<string, string, string>("1_3_ACHIEVE_PCT_PTS_EARN", "1_3_ACHIEVE_PTS_ELIG", "1_3_ACHIEVE_PTS_EARN");
				yield return new Tuple<string, string, string>("1_3_GROWTH_PCT_PTS_EARN", "1_3_GROWTH_PTS_ELIG", "1_3_GROWTH_PTS_EARN");
				yield return new Tuple<string, string, string>("1_3_GRO_GAPS_PCT_PTS_EARN", "1_3_GRO_GAPS_PTS_ELIG", "1_3_GRO_GAPS_PTS_EARN");
				yield return new Tuple<string, string, string>("1_3_POST_SEC_PCT_PTS_EARN", "1_3_POST_SEC_PTS_ELIG", "1_3_POST_SEC_PTS_EARN");
				yield return new Tuple<string, string, string>("1YR_ACHIEVE_PCT_PTS_EARN", "1YR_ACHIEVE_PTS_ELIG", "1YR_ACHIEVE_PTS_EARN");
				yield return new Tuple<string, string, string>("1YR_GROWTH_PCT_PTS_EARN", "1YR_GROWTH_PTS_ELIG", "1YR_GROWTH_PTS_EARN");
				yield return new Tuple<string, string, string>("1YR_GRO_GAPS_PCT_PTS_EARN", "1YR_GRO_GAPS_PTS_ELIG", "1YR_GRO_GAPS_PTS_EARN");
				yield return new Tuple<string, string, string>("1YR_POST_SEC_PCT_PTS_EARN", "1YR_POST_SEC_PTS_ELIG", "1YR_POST_SEC_PTS_EARN");
				yield return new Tuple<string, string, string>("3YR_ACHIEVE_PCT_PTS_EARN", "3YR_ACHIEVE_PTS_ELIG", "3YR_ACHIEVE_PTS_EARN");
				yield return new Tuple<string, string, string>("3YR_GROWTH_PCT_PTS_EARN", "3YR_GROWTH_PTS_ELIG", "3YR_GROWTH_PTS_EARN");
				yield return new Tuple<string, string, string>("3YR_GRO_GAPS_PCT_PTS_EARN", "3YR_GRO_GAPS_PTS_ELIG", "3YR_GRO_GAPS_PTS_EARN");
				yield return new Tuple<string, string, string>("3YR_POST_SEC_PCT_PTS_EARN", "3YR_POST_SEC_PTS_ELIG", "3YR_POST_SEC_PTS_EARN");
			}
		}

		public override void Test(Row row, Errors errors)
		{
			Columns.ForEach(t => CheckPointsEarned(row, t.Item1, t.Item2, t.Item3, errors));
		}

		bool CheckPointsEarned(Row row, string percentPointsColumn, string pointsEligibleColumn, string pointsEarnedColumn, Errors errors)
		{
            if (!Defined(row, percentPointsColumn, errors) &&
                (!Defined(row, pointsEligibleColumn, errors) || !Defined(row, pointsEarnedColumn, errors)))
            {
                return true;
            }

            if (!AssertDefined(row, pointsEligibleColumn, errors) || !AssertDefined(row, pointsEarnedColumn, errors))
            {
                return false;
            }

			if(!Defined(row, percentPointsColumn, errors) && (row[pointsEligibleColumn] == "0" || row[pointsEarnedColumn] == "0"))
			{
				return true;
			}

			if (AssertDefined(row, new[] { percentPointsColumn, pointsEligibleColumn, pointsEarnedColumn }, errors))
			{
				var percentPoints = double.Parse(row[percentPointsColumn]);
				var pointsEligible = double.Parse(row[pointsEligibleColumn]);
				var pointsEarned = double.Parse(row[pointsEarnedColumn]);
				var pointsEarnedExpected = percentPoints * pointsEligible / 100.0;

				return AssertTrue(row, pointsEarnedExpected.Format() == pointsEarned.Format(), percentPointsColumn + ", " + pointsEligibleColumn + ", " + pointsEarnedColumn, errors);
			}
			return false;
		}
	}
}
