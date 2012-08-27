using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class CoAltOnePercentExceedsAdjustment : BaseTest
	{
		IEnumerable<Tuple<string, string, string>> Columns
		{
			get
			{
				yield return new Tuple<string, string, string>("RDPF_1YR_PARTIC_NM_NOCAP_READ", "RDPF_1YR_PARTIC_NM_READ", "RDPF_1YR_COALT_CAP_NEXCD_READ");
				yield return new Tuple<string, string, string>("RDPF_1YR_PARTIC_NM_NOCAP_MATH", "RDPF_1YR_PARTIC_NM_MATH", "RDPF_1YR_COALT_CAP_NEXCD_MATH");
				yield return new Tuple<string, string, string>("RDPF_1YR_PARTIC_NM_NOCAP_WRITE", "RDPF_1YR_PARTIC_NM_WRITE", "RDPF_1YR_COALT_CAP_NEXCD_WRITE");
				yield return new Tuple<string, string, string>("RDPF_1YR_PARTIC_NM_NOCAP_SCI", "RDPF_1YR_PARTIC_NM_SCI", "RDPF_1YR_COALT_CAP_NEXCD_SCI");
				yield return new Tuple<string, string, string>("RDPF_3YR_PARTIC_NM_NOCAP_READ", "RDPF_3YR_PARTIC_NM_READ", "RDPF_3YR_COALT_CAP_NEXCD_READ");
				yield return new Tuple<string, string, string>("RDPF_3YR_PARTIC_NM_NOCAP_MATH", "RDPF_3YR_PARTIC_NM_MATH", "RDPF_3YR_COALT_CAP_NEXCD_MATH");
				yield return new Tuple<string, string, string>("RDPF_3YR_PARTIC_NM_NOCAP_WRITE", "RDPF_3YR_PARTIC_NM_WRITE", "RDPF_3YR_COALT_CAP_NEXCD_WRITE");
				yield return new Tuple<string, string, string>("RDPF_3YR_PARTIC_NM_NOCAP_SCI", "RDPF_3YR_PARTIC_NM_SCI", "RDPF_3YR_COALT_CAP_NEXCD_SCI");
			}
		}

		public override void Test(Row row, List<string> errors)
		{
			Columns.ForEach(t => AssertSubtract(row, t.Item1, t.Item2, t.Item3, errors));
		}
	}
}
