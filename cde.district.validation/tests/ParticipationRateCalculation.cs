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

		public override void Test(Row row, Errors errors)
		{
			ParticipationColumns.ForEach(t => AssertDivide(row, t.Item1, t.Item2, t.Item3, errors));
		}
	}
}
