using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class GrowthPointsRollup : BaseTest
	{
		IEnumerable<Tuple<string, string, string>> Columns
		{
			get
			{
				yield return new Tuple<string, string, string>("1YR_GRO_MGP_READ", "1YR_GRO_AGP_READ", "1YR_GRO_MADE_AGP_READ");
				yield return new Tuple<string, string, string>("1YR_GRO_MGP_MATH", "1YR_GRO_AGP_MATH", "1YR_GRO_MADE_AGP_MATH");
				yield return new Tuple<string, string, string>("1YR_GRO_MGP_WRITE", "1YR_GRO_AGP_WRITE", "1YR_GRO_MADE_AGP_WRITE");
                //yield return new Tuple<string, string, string>("1YR_GRO_MGP_ELP", "1YR_GRO_AGP_ELP", "1YR_GRO_MADE_AGP_ELP");
				yield return new Tuple<string, string, string>("3YR_GRO_MGP_READ", "3YR_GRO_AGP_READ", "3YR_GRO_MADE_AGP_READ");
				yield return new Tuple<string, string, string>("3YR_GRO_MGP_MATH", "3YR_GRO_AGP_MATH", "3YR_GRO_MADE_AGP_MATH");
				yield return new Tuple<string, string, string>("3YR_GRO_MGP_WRITE", "3YR_GRO_AGP_WRITE", "3YR_GRO_MADE_AGP_WRITE");
				//yield return new Tuple<string, string, string>("3YR_GRO_MGP_ELP", "3YR_GRO_AGP_ELP", "3YR_GRO_MADE_AGP_ELP");
				yield return new Tuple<string, string, string>("1YR_GG_FRL_MGP_READ", "1YR_GG_FRL_AGP_READ", "1YR_GG_FRL_MADE_AGP_READ");
				yield return new Tuple<string, string, string>("1YR_GG_MIN_MGP_READ", "1YR_GG_MIN_AGP_READ", "1YR_GG_MIN_MADE_AGP_READ");
				yield return new Tuple<string, string, string>("1YR_GG_DIS_MGP_READ", "1YR_GG_DIS_AGP_READ", "1YR_GG_DIS_MADE_AGP_READ");
				yield return new Tuple<string, string, string>("1YR_GG_ELL_MGP_READ", "1YR_GG_ELL_AGP_READ", "1YR_GG_ELL_MADE_AGP_READ");
				yield return new Tuple<string, string, string>("1YR_GG_BPA_MGP_READ", "1YR_GG_BPA_AGP_READ", "1YR_GG_BPA_MADE_AGP_READ");
				yield return new Tuple<string, string, string>("1YR_GG_FRL_MGP_MATH", "1YR_GG_FRL_AGP_MATH", "1YR_GG_FRL_MADE_AGP_MATH");
				yield return new Tuple<string, string, string>("1YR_GG_MIN_MGP_MATH", "1YR_GG_MIN_AGP_MATH", "1YR_GG_MIN_MADE_AGP_MATH");
				yield return new Tuple<string, string, string>("1YR_GG_DIS_MGP_MATH", "1YR_GG_DIS_AGP_MATH", "1YR_GG_DIS_MADE_AGP_MATH");
				yield return new Tuple<string, string, string>("1YR_GG_ELL_MGP_MATH", "1YR_GG_ELL_AGP_MATH", "1YR_GG_ELL_MADE_AGP_MATH");
				yield return new Tuple<string, string, string>("1YR_GG_BPA_MGP_MATH", "1YR_GG_BPA_AGP_MATH", "1YR_GG_BPA_MADE_AGP_MATH");
				yield return new Tuple<string, string, string>("1YR_GG_FRL_MGP_WRITE", "1YR_GG_FRL_AGP_WRITE", "1YR_GG_FRL_MADE_AGP_WRITE");
				yield return new Tuple<string, string, string>("1YR_GG_MIN_MGP_WRITE", "1YR_GG_MIN_AGP_WRITE", "1YR_GG_MIN_MADE_AGP_WRITE");
				yield return new Tuple<string, string, string>("1YR_GG_DIS_MGP_WRITE", "1YR_GG_DIS_AGP_WRITE", "1YR_GG_DIS_MADE_AGP_WRITE");
				yield return new Tuple<string, string, string>("1YR_GG_ELL_MGP_WRITE", "1YR_GG_ELL_AGP_WRITE", "1YR_GG_ELL_MADE_AGP_WRITE");
				yield return new Tuple<string, string, string>("1YR_GG_BPA_MGP_WRITE", "1YR_GG_BPA_AGP_WRITE", "1YR_GG_BPA_MADE_AGP_WRITE");
				yield return new Tuple<string, string, string>("3YR_GG_FRL_MGP_READ", "3YR_GG_FRL_AGP_READ", "3YR_GG_FRL_MADE_AGP_READ");
				yield return new Tuple<string, string, string>("3YR_GG_MIN_MGP_READ", "3YR_GG_MIN_AGP_READ", "3YR_GG_MIN_MADE_AGP_READ");
				yield return new Tuple<string, string, string>("3YR_GG_DIS_MGP_READ", "3YR_GG_DIS_AGP_READ", "3YR_GG_DIS_MADE_AGP_READ");
				yield return new Tuple<string, string, string>("3YR_GG_ELL_MGP_READ", "3YR_GG_ELL_AGP_READ", "3YR_GG_ELL_MADE_AGP_READ");
				yield return new Tuple<string, string, string>("3YR_GG_BPA_MGP_READ", "3YR_GG_BPA_AGP_READ", "3YR_GG_BPA_MADE_AGP_READ");
				yield return new Tuple<string, string, string>("3YR_GG_FRL_MGP_MATH", "3YR_GG_FRL_AGP_MATH", "3YR_GG_FRL_MADE_AGP_MATH");
				yield return new Tuple<string, string, string>("3YR_GG_MIN_MGP_MATH", "3YR_GG_MIN_AGP_MATH", "3YR_GG_MIN_MADE_AGP_MATH");
				yield return new Tuple<string, string, string>("3YR_GG_DIS_MGP_MATH", "3YR_GG_DIS_AGP_MATH", "3YR_GG_DIS_MADE_AGP_MATH");
				yield return new Tuple<string, string, string>("3YR_GG_ELL_MGP_MATH", "3YR_GG_ELL_AGP_MATH", "3YR_GG_ELL_MADE_AGP_MATH");
				yield return new Tuple<string, string, string>("3YR_GG_BPA_MGP_MATH", "3YR_GG_BPA_AGP_MATH", "3YR_GG_BPA_MADE_AGP_MATH");
				yield return new Tuple<string, string, string>("3YR_GG_FRL_MGP_WRITE", "3YR_GG_FRL_AGP_WRITE", "3YR_GG_FRL_MADE_AGP_WRITE");
				yield return new Tuple<string, string, string>("3YR_GG_MIN_MGP_WRITE", "3YR_GG_MIN_AGP_WRITE", "3YR_GG_MIN_MADE_AGP_WRITE");

			}
		}

		public override void Test(Row row, Errors errors)
		{
			Columns.ForEach(t => AssertMadeAGP(row, t.Item1, t.Item2, t.Item3, errors));
		}

		void AssertMadeAGP(Row row, string mgpColumn, string agpColumn, string madeAgpColumn, Errors errors)
		{
			if (!Defined(row, mgpColumn, errors) && !Defined(row, agpColumn, errors) && !Defined(row, madeAgpColumn, errors))
			{
				return;
			}
			
			if (AssertDefined(row, new[] { mgpColumn, agpColumn, madeAgpColumn }, errors))
			{
				double mgp, agp;
				if (AssertNumber(row, mgpColumn, out mgp, errors) &&
					AssertNumber(row, agpColumn, out agp, errors))
				{
					var madeAgp = row[madeAgpColumn].ToLower();
					var madeAgpExpected = MadeAGP(mgp, agp).ToLower();

					var message = "Calculated made AGP (" + madeAgpExpected + ") != Made MGP (" + madeAgp + ")";
					AssertTrue(row, madeAgpExpected.ToLower() == madeAgp.ToLower(), message, errors);
				}
			}
		}

		string MadeAGP(double mgp, double agp)
		{
			if ((mgp - agp) >= 0.0) return "YES";
			return "NO";
		}
	}
}
