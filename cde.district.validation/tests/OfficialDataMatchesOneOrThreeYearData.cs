using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class OfficialDataMatchesOneOrThreeYearData : BaseTest
	{
		IEnumerable<Tuple<string, string>> OneYearColumns
		{
			get
			{
				yield return new Tuple<string, string>("1_3_YEARS_OF_DATA", "1YR_YEARS_OF_DATA");
				yield return new Tuple<string, string>("1_3_ACHIEVE_RATING", "1YR_ACHIEVE_RATING");
				yield return new Tuple<string, string>("1_3_ACHIEVE_PCT_PTS_EARN", "1YR_ACHIEVE_PCT_PTS_EARN");
				yield return new Tuple<string, string>("1_3_ACHIEVE_PTS_ELIG", "1YR_ACHIEVE_PTS_ELIG");
				yield return new Tuple<string, string>("1_3_GROWTH_RATING", "1YR_GROWTH_RATING");
				yield return new Tuple<string, string>("1_3_GROWTH_PCT_PTS_EARN", "1YR_GROWTH_PCT_PTS_EARN");
				yield return new Tuple<string, string>("1_3_GROWTH_PTS_EARN", "1YR_GROWTH_PTS_EARN");
				yield return new Tuple<string, string>("1_3_GROWTH_PTS_ELIG", "1YR_GROWTH_PTS_ELIG");
				yield return new Tuple<string, string>("1_3_GRO_GAPS_RATING", "1YR_GRO_GAPS_RATING");
				yield return new Tuple<string, string>("1_3_GRO_GAPS_PCT_PTS_EARN", "1YR_GRO_GAPS_PCT_PTS_EARN");
				yield return new Tuple<string, string>("1_3_GRO_GAPS_PTS_EARN", "1YR_GRO_GAPS_PTS_EARN");
				yield return new Tuple<string, string>("1_3_GRO_GAPS_PTS_ELIG", "1YR_GRO_GAPS_PTS_ELIG");
				yield return new Tuple<string, string>("1_3_POST_SEC_RATING", "1YR_POST_SEC_RATING");
				yield return new Tuple<string, string>("1_3_POST_SEC_PCT_PTS_EARN", "1YR_POST_SEC_PCT_PTS_EARN");
				yield return new Tuple<string, string>("1_3_POST_SEC_PTS_EARN", "1YR_POST_SEC_PTS_EARN");
				yield return new Tuple<string, string>("1_3_POST_SEC_PTS_ELIG", "1YR_POST_SEC_PTS_ELIG");
				yield return new Tuple<string, string>("1_3_PARTIC_DNM_COUNT", "1YR_TEST_PARTIC_DNM_COUNT");
				yield return new Tuple<string, string>("1_3_PARTIC_RATING", "1YR_TEST_PARTIC_RATING");
			}
		}

		IEnumerable<Tuple<string, string>> ThreeYearColumns
		{
			get
			{
				yield return new Tuple<string, string>("1_3_YEARS_OF_DATA", "3YR_YEARS_OF_DATA");
				yield return new Tuple<string, string>("1_3_ACHIEVE_RATING", "3YR_ACHIEVE_RATING");
				yield return new Tuple<string, string>("1_3_ACHIEVE_PCT_PTS_EARN", "3YR_ACHIEVE_PCT_PTS_EARN");
				yield return new Tuple<string, string>("1_3_ACHIEVE_PTS_ELIG", "3YR_ACHIEVE_PTS_ELIG");
				yield return new Tuple<string, string>("1_3_GROWTH_RATING", "3YR_GROWTH_RATING");
				yield return new Tuple<string, string>("1_3_GROWTH_PCT_PTS_EARN", "3YR_GROWTH_PCT_PTS_EARN");
				yield return new Tuple<string, string>("1_3_GROWTH_PTS_EARN", "3YR_GROWTH_PTS_EARN");
				yield return new Tuple<string, string>("1_3_GROWTH_PTS_ELIG", "3YR_GROWTH_PTS_ELIG");
				yield return new Tuple<string, string>("1_3_GRO_GAPS_RATING", "3YR_GRO_GAPS_RATING");
				yield return new Tuple<string, string>("1_3_GRO_GAPS_PCT_PTS_EARN", "3YR_GRO_GAPS_PCT_PTS_EARN");
				yield return new Tuple<string, string>("1_3_GRO_GAPS_PTS_EARN", "3YR_GRO_GAPS_PTS_EARN");
				yield return new Tuple<string, string>("1_3_GRO_GAPS_PTS_ELIG", "3YR_GRO_GAPS_PTS_ELIG");
				yield return new Tuple<string, string>("1_3_POST_SEC_RATING", "3YR_POST_SEC_RATING");
				yield return new Tuple<string, string>("1_3_POST_SEC_PCT_PTS_EARN", "3YR_POST_SEC_PCT_PTS_EARN");
				yield return new Tuple<string, string>("1_3_POST_SEC_PTS_EARN", "3YR_POST_SEC_PTS_EARN");
				yield return new Tuple<string, string>("1_3_POST_SEC_PTS_ELIG", "3YR_POST_SEC_PTS_ELIG");
				yield return new Tuple<string, string>("1_3_PARTIC_DNM_COUNT", "3YR_TEST_PARTIC_DNM_COUNT");
				yield return new Tuple<string, string>("1_3_PARTIC_RATING", "3YR_TEST_PARTIC_RATING");
			}
		}

		public override void Test(Row row, Errors errors)
		{
			var columns = row["1_3_RATING_YEAR_USED"].ToLower() == "1 year" ? OneYearColumns : ThreeYearColumns;
			AssertMatch(row, columns, errors);
		}

		void AssertMatch(Row row, IEnumerable<Tuple<string, string>> columns, Errors errors)
		{
			columns.ForEach(t => AssertEqual(row, t.Item1, t.Item2, errors));
		}
	}
}
