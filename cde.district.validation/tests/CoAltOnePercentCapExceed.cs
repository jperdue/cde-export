using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class CoAltOnePercentCapExceed : BaseTest
	{
		IEnumerable<Tuple<string, string, string>> Columns
		{
			get
			{
				yield return new Tuple<string, string, string>("1YR_COALT_CAP_PA_N_READ", "1YR_COALT_CAP_1PCTN_READ", "1YR_COALT_CAP_EXCD_READ");
				yield return new Tuple<string, string, string>("1YR_COALT_CAP_PA_N_MATH", "1YR_COALT_CAP_1PCTN_MATH", "1YR_COALT_CAP_EXCD_MATH");
				yield return new Tuple<string, string, string>("1YR_COALT_CAP_PA_N_WRITE", "1YR_COALT_CAP_1PCTN_WRITE", "1YR_COALT_CAP_EXCD_WRITE");
				yield return new Tuple<string, string, string>("1YR_COALT_CAP_PA_N_SCI", "1YR_COALT_CAP_1PCTN_SCI", "1YR_COALT_CAP_EXCD_SCI");

				yield return new Tuple<string, string, string>("3YR_COALT_CAP_PA_N_READ", "3YR_COALT_CAP_1PCTN_READ", "3YR_COALT_CAP_EXCD_READ");
				yield return new Tuple<string, string, string>("3YR_COALT_CAP_PA_N_MATH", "3YR_COALT_CAP_1PCTN_MATH", "3YR_COALT_CAP_EXCD_MATH");
				yield return new Tuple<string, string, string>("3YR_COALT_CAP_PA_N_WRITE", "3YR_COALT_CAP_1PCTN_WRITE", "3YR_COALT_CAP_EXCD_WRITE");
				yield return new Tuple<string, string, string>("3YR_COALT_CAP_PA_N_SCI", "3YR_COALT_CAP_1PCTN_SCI", "3YR_COALT_CAP_EXCD_SCI");
			}
		}

		public override void Test(Row row, Errors errors)
		{
			if (row.Type == EDataType.School) return;

			Columns.ForEach(t => AssertGreaterThan(row, t.Item1, t.Item2, t.Item3, errors));
		}

		void AssertGreaterThan(Row row, string panColumn, string pctnColumn, string excdColumn, Errors errors)
		{
            if (!Defined(row, panColumn, errors))
            {
                return;
            }

            if (row[pctnColumn] == "0" && (!Defined(row, panColumn, errors) || row[panColumn] == "0"))
            {
                return;
            }

            var excdValue = row[excdColumn].ToLower();
			if(excdValue == "yes")
			{
                AssertGreaterOrEqual(row, panColumn, pctnColumn, errors);
			}
            else if (excdValue == "no")
            {
                AssertGreaterThan(row, pctnColumn, panColumn, errors);
            }
		}
	}
}
