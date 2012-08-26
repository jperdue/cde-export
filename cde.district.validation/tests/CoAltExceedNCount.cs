using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class CoAltExceedNCount : BaseTest
	{
		IEnumerable<Tuple<string, string, string, string>> Columns
		{
			get
			{
				yield return new Tuple<string, string, string, string>("RDPF_1YR_COALT_CAP_EXCD_READ", "RDPF_1YR_COALT_CAP_PA_N_READ", "RDPF_1YR_COALT_CAP_1PCTN_READ", "RDPF_1YR_COALT_CAP_NEXCD_READ");
				yield return new Tuple<string, string, string, string>("RDPF_1YR_COALT_CAP_EXCD_MATH", "RDPF_1YR_COALT_CAP_PA_N_MATH", "RDPF_1YR_COALT_CAP_1PCTN_MATH", "RDPF_1YR_COALT_CAP_NEXCD_MATH");
				yield return new Tuple<string, string, string, string>("RDPF_1YR_COALT_CAP_EXCD_WRITE", "RDPF_1YR_COALT_CAP_PA_N_WRITE", "RDPF_1YR_COALT_CAP_1PCTN_WRITE", "RDPF_1YR_COALT_CAP_NEXCD_WRITE");
				yield return new Tuple<string, string, string, string>("RDPF_1YR_COALT_CAP_EXCD_SCI", "RDPF_1YR_COALT_CAP_PA_N_SCI", "RDPF_1YR_COALT_CAP_1PCTN_SCI", "RDPF_1YR_COALT_CAP_NEXCD_SCI");

				yield return new Tuple<string, string, string, string>("RDPF_3YR_COALT_CAP_EXCD_READ", "RDPF_3YR_COALT_CAP_PA_N_READ", "RDPF_3YR_COALT_CAP_1PCTN_READ", "RDPF_3YR_COALT_CAP_NEXCD_READ");
				yield return new Tuple<string, string, string, string>("RDPF_3YR_COALT_CAP_EXCD_MATH", "RDPF_3YR_COALT_CAP_PA_N_MATH", "RDPF_3YR_COALT_CAP_1PCTN_MATH", "RDPF_3YR_COALT_CAP_NEXCD_MATH");
				yield return new Tuple<string, string, string, string>("RDPF_3YR_COALT_CAP_EXCD_WRITE", "RDPF_3YR_COALT_CAP_PA_N_WRITE", "RDPF_3YR_COALT_CAP_1PCTN_WRITE", "RDPF_3YR_COALT_CAP_NEXCD_WRITE");
				yield return new Tuple<string, string, string, string>("RDPF_3YR_COALT_CAP_EXCD_SCI", "RDPF_3YR_COALT_CAP_PA_N_SCI", "RDPF_3YR_COALT_CAP_1PCTN_SCI", "RDPF_3YR_COALT_CAP_NEXCD_SCI");
			}
		}

		public override void Test(Row row, List<string> errors)
		{
			Columns.ForEach(t => AssertSubtract(row, t.Item1, t.Item2, t.Item3, t.Item4, errors));
		}

		void AssertSubtract(Row row, string excdColumn, string panColumn, string pctnColumn, string nexcdColumn, List<string> errors)
		{
			if (AssertDefined(row, excdColumn, errors) && row[excdColumn].ToLower() == "no")
			{
				AssertSubtract(row, panColumn, pctnColumn, nexcdColumn, errors);
			}
		}
	}
}
