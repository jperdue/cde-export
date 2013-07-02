using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class DisaggregatedGraduationPointsEarnedEqualsPercentOfDisaggregatedGradPoints : BaseTest
	{
		IEnumerable<Tuple<string, string, string>> Columns
		{
			get
			{
				yield return new Tuple<string, string, string>("1YR_PS_GRAD_DSAG_PCT_PTS", "1YR_PS_GRAD_DSAG_PTS_EARN", "1YR_PS_GRAD_DSAG_PTS_ELIG");
				yield return new Tuple<string, string, string>("3YR_PS_GRAD_DSAG_PCT_PTS", "3YR_PS_GRAD_DSAG_PTS_EARN", "3YR_PS_GRAD_DSAG_PTS_ELIG");
			}
		}

		public override void Test(Row row, Errors errors)
		{
		}

		protected override bool AssertDivide(Row row, string resultColumn, string numeratorColumn, string denominatorColumn, Errors errors)
		{
			if (!Defined(row, resultColumn, errors) && row[denominatorColumn] == "0") return true;

			return base.AssertDivide(row, resultColumn, numeratorColumn, denominatorColumn, errors);
		}
	}
}
