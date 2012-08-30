using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class ParticipationRateCalculation : BaseTest
	{
		IEnumerable<Tuple<string, string, string>> ParticipationColumns
		{
			get
			{
				yield return new Tuple<string, string, string>("1YR_PARTIC_PCT_TEST_READ", "1YR_PARTIC_NM_READ", "1YR_PARTIC_DN_READ");
				yield return new Tuple<string, string, string>("1YR_PARTIC_PCT_TEST_MATH", "1YR_PARTIC_NM_MATH", "1YR_PARTIC_DN_MATH");
				yield return new Tuple<string, string, string>("1YR_PARTIC_PCT_TEST_WRITE", "1YR_PARTIC_NM_WRITE", "1YR_PARTIC_DN_WRITE");
				yield return new Tuple<string, string, string>("1YR_PARTIC_PCT_TEST_SCI", "1YR_PARTIC_NM_SCI", "1YR_PARTIC_DN_SCI");
				yield return new Tuple<string, string, string>("1YR_PARTIC_PCT_TEST_ACT", "1YR_PARTIC_NM_ACT", "1YR_PARTIC_DN_ACT");
				yield return new Tuple<string, string, string>("3YR_PARTIC_PCT_TEST_READ", "3YR_PARTIC_NM_READ", "3YR_PARTIC_DN_READ");
				yield return new Tuple<string, string, string>("3YR_PARTIC_PCT_TEST_MATH", "3YR_PARTIC_NM_MATH", "3YR_PARTIC_DN_MATH");
				yield return new Tuple<string, string, string>("3YR_PARTIC_PCT_TEST_WRITE", "3YR_PARTIC_NM_WRITE", "3YR_PARTIC_DN_WRITE");
				yield return new Tuple<string, string, string>("3YR_PARTIC_PCT_TEST_SCI", "3YR_PARTIC_NM_SCI", "3YR_PARTIC_DN_SCI");
				yield return new Tuple<string, string, string>("3YR_PARTIC_PCT_TEST_ACT", "3YR_PARTIC_NM_ACT", "3YR_PARTIC_DN_ACT");
			}
		}

		public override void Test(Row row, Errors errors)
		{
			ParticipationColumns.ForEach(t => AssertDivide(row, t.Item1, t.Item2, t.Item3, errors));
		}
	}
}
