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
				yield return new Tuple<string, string, string>("1YR_PARTIC_NM_NOCAP_READ", "1YR_PARTIC_NM_READ", "1YR_COALT_CAP_NEXCD_READ");
				yield return new Tuple<string, string, string>("1YR_PARTIC_NM_NOCAP_MATH", "1YR_PARTIC_NM_MATH", "1YR_COALT_CAP_NEXCD_MATH");
				yield return new Tuple<string, string, string>("1YR_PARTIC_NM_NOCAP_WRITE", "1YR_PARTIC_NM_WRITE", "1YR_COALT_CAP_NEXCD_WRITE");
				yield return new Tuple<string, string, string>("1YR_PARTIC_NM_NOCAP_SCI", "1YR_PARTIC_NM_SCI", "1YR_COALT_CAP_NEXCD_SCI");
                yield return new Tuple<string, string, string>("1YR_PARTIC_NM_NOCAP_SOC", "1YR_PARTIC_NM_SOC", "1YR_COALT_CAP_NEXCD_SOC");

				yield return new Tuple<string, string, string>("3YR_PARTIC_NM_NOCAP_READ", "3YR_PARTIC_NM_READ", "3YR_COALT_CAP_NEXCD_READ");
				yield return new Tuple<string, string, string>("3YR_PARTIC_NM_NOCAP_MATH", "3YR_PARTIC_NM_MATH", "3YR_COALT_CAP_NEXCD_MATH");
				yield return new Tuple<string, string, string>("3YR_PARTIC_NM_NOCAP_WRITE", "3YR_PARTIC_NM_WRITE", "3YR_COALT_CAP_NEXCD_WRITE");
				yield return new Tuple<string, string, string>("3YR_PARTIC_NM_NOCAP_SCI", "3YR_PARTIC_NM_SCI", "3YR_COALT_CAP_NEXCD_SCI");
                yield return new Tuple<string, string, string>("3YR_PARTIC_NM_NOCAP_SOC", "3YR_PARTIC_NM_SOC", "3YR_COALT_CAP_NEXCD_SOC");
			}
		}

		public override void Test(Row row, Errors errors)
		{
			if (row.Type == EDataType.School) return;

			Columns.ForEach(t => AssertSubtract(row, t.Item1, t.Item2, t.Item3, errors));
		}

		protected override bool AssertSubtract(Row row, string column1, string column2, string resultColumn, Errors errors)
		{
			if(!Defined(row, resultColumn, errors))
			{
				row[resultColumn] = "0";
			}

			return base.AssertSubtract(row, column1, column2, resultColumn, errors);
		}
	}
}
