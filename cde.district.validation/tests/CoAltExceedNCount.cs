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
				yield return new Tuple<string, string, string, string>("1YR_COALT_CAP_EXCD_READ", "1YR_COALT_CAP_PA_N_READ", "1YR_COALT_CAP_1PCTN_READ", "1YR_COALT_CAP_NEXCD_READ");
				yield return new Tuple<string, string, string, string>("1YR_COALT_CAP_EXCD_MATH", "1YR_COALT_CAP_PA_N_MATH", "1YR_COALT_CAP_1PCTN_MATH", "1YR_COALT_CAP_NEXCD_MATH");
				yield return new Tuple<string, string, string, string>("1YR_COALT_CAP_EXCD_WRITE", "1YR_COALT_CAP_PA_N_WRITE", "1YR_COALT_CAP_1PCTN_WRITE", "1YR_COALT_CAP_NEXCD_WRITE");
				yield return new Tuple<string, string, string, string>("1YR_COALT_CAP_EXCD_SCI", "1YR_COALT_CAP_PA_N_SCI", "1YR_COALT_CAP_1PCTN_SCI", "1YR_COALT_CAP_NEXCD_SCI");

				yield return new Tuple<string, string, string, string>("3YR_COALT_CAP_EXCD_READ", "3YR_COALT_CAP_PA_N_READ", "3YR_COALT_CAP_1PCTN_READ", "3YR_COALT_CAP_NEXCD_READ");
				yield return new Tuple<string, string, string, string>("3YR_COALT_CAP_EXCD_MATH", "3YR_COALT_CAP_PA_N_MATH", "3YR_COALT_CAP_1PCTN_MATH", "3YR_COALT_CAP_NEXCD_MATH");
				yield return new Tuple<string, string, string, string>("3YR_COALT_CAP_EXCD_WRITE", "3YR_COALT_CAP_PA_N_WRITE", "3YR_COALT_CAP_1PCTN_WRITE", "3YR_COALT_CAP_NEXCD_WRITE");
				yield return new Tuple<string, string, string, string>("3YR_COALT_CAP_EXCD_SCI", "3YR_COALT_CAP_PA_N_SCI", "3YR_COALT_CAP_1PCTN_SCI", "3YR_COALT_CAP_NEXCD_SCI");
			}
		}

		public override void Test(Row row, Errors errors)
		{
			if (row.Type == EDataType.School) return;

			Columns.ForEach(t => AssertSubtract(row, t.Item1, t.Item2, t.Item3, t.Item4, errors));
		}

		void AssertSubtract(Row row, string excdColumn, string panColumn, string pctnColumn, string nexcdColumn, Errors errors)
		{
			if (row[excdColumn].ToLower() == "yes")
			{
				AssertSubtract(row, panColumn, pctnColumn, nexcdColumn, errors);
			}
		}
	}
}
