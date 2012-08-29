using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class AcademicGrowthAndGrowthGapsRating : BaseTest
	{
		IEnumerable<Tuple<string, string, string>> Columns
		{
			get
			{		
				yield return new Tuple<string, string, string>("RDPF_1YR_GRO_MADE_AGP_READ", "RDPF_1YR_GRO_RATING_READ", "RDPF_1YR_GRO_MGP_READ");
				yield return new Tuple<string, string, string>("RDPF_1YR_GRO_MADE_AGP_MATH", "RDPF_1YR_GRO_RATING_MATH", "RDPF_1YR_GRO_MGP_MATH");
				yield return new Tuple<string, string, string>("RDPF_1YR_GRO_MADE_AGP_WRITE", "RDPF_1YR_GRO_RATING_WRITE", "RDPF_1YR_GRO_MGP_WRITE");
				yield return new Tuple<string, string, string>("RDPF_1YR_GRO_MADE_AGP_ELP", "RDPF_1YR_GRO_RATING_ELP", "RDPF_1YR_GRO_MGP_ELP");
				yield return new Tuple<string, string, string>("RDPF_3YR_GRO_MADE_AGP_READ", "RDPF_3YR_GRO_RATING_READ", "RDPF_3YR_GRO_MGP_READ");
				yield return new Tuple<string, string, string>("RDPF_3YR_GRO_MADE_AGP_MATH", "RDPF_3YR_GRO_RATING_MATH", "RDPF_3YR_GRO_MGP_MATH");
				yield return new Tuple<string, string, string>("RDPF_3YR_GRO_MADE_AGP_WRITE", "RDPF_3YR_GRO_RATING_WRITE", "RDPF_3YR_GRO_MGP_WRITE");
				yield return new Tuple<string, string, string>("RDPF_3YR_GRO_MADE_AGP_ELP", "RDPF_3YR_GRO_RATING_ELP", "RDPF_3YR_GRO_MGP_ELP");
				yield return new Tuple<string, string, string>("RDPF_1YR_GG_FRL_MADE_AGP_READ", "RDPF_1YR_GG_FRL_RATING_READ", "RDPF_1YR_GG_FRL_MGP_READ");
				yield return new Tuple<string, string, string>("RDPF_1YR_GG_MIN_MADE_AGP_READ", "RDPF_1YR_GG_MIN_RATING_READ", "RDPF_1YR_GG_MIN_MGP_READ");
				yield return new Tuple<string, string, string>("RDPF_1YR_GG_DIS_MADE_AGP_READ", "RDPF_1YR_GG_DIS_RATING_READ", "RDPF_1YR_GG_DIS_MGP_READ");
				yield return new Tuple<string, string, string>("RDPF_1YR_GG_ELL_MADE_AGP_READ", "RDPF_1YR_GG_ELL_RATING_READ", "RDPF_1YR_GG_ELL_MGP_READ");
				yield return new Tuple<string, string, string>("RDPF_1YR_GG_BPA_MADE_AGP_READ", "RDPF_1YR_GG_BPA_RATING_READ", "RDPF_1YR_GG_BPA_MGP_READ");
				yield return new Tuple<string, string, string>("RDPF_1YR_GG_FRL_MADE_AGP_MATH", "RDPF_1YR_GG_FRL_RATING_MATH", "RDPF_1YR_GG_FRL_MGP_MATH");
				yield return new Tuple<string, string, string>("RDPF_1YR_GG_MIN_MADE_AGP_MATH", "RDPF_1YR_GG_MIN_RATING_MATH", "RDPF_1YR_GG_MIN_MGP_MATH");
				yield return new Tuple<string, string, string>("RDPF_1YR_GG_DIS_MADE_AGP_MATH", "RDPF_1YR_GG_DIS_RATING_MATH", "RDPF_1YR_GG_DIS_MGP_MATH");
				yield return new Tuple<string, string, string>("RDPF_1YR_GG_ELL_MADE_AGP_MATH", "RDPF_1YR_GG_ELL_RATING_MATH", "RDPF_1YR_GG_ELL_MGP_MATH");
				yield return new Tuple<string, string, string>("RDPF_1YR_GG_BPA_MADE_AGP_MATH", "RDPF_1YR_GG_BPA_RATING_MATH", "RDPF_1YR_GG_BPA_MGP_MATH");
				yield return new Tuple<string, string, string>("RDPF_1YR_GG_FRL_MADE_AGP_WRITE", "RDPF_1YR_GG_FRL_RATING_WRITE", "RDPF_1YR_GG_FRL_MGP_WRITE");
				yield return new Tuple<string, string, string>("RDPF_1YR_GG_MIN_MADE_AGP_WRITE", "RDPF_1YR_GG_MIN_RATING_WRITE", "RDPF_1YR_GG_MIN_MGP_WRITE");
				yield return new Tuple<string, string, string>("RDPF_1YR_GG_DIS_MADE_AGP_WRITE", "RDPF_1YR_GG_DIS_RATING_WRITE", "RDPF_1YR_GG_DIS_MGP_WRITE");
				yield return new Tuple<string, string, string>("RDPF_1YR_GG_ELL_MADE_AGP_WRITE", "RDPF_1YR_GG_ELL_RATING_WRITE", "RDPF_1YR_GG_ELL_MGP_WRITE");
				yield return new Tuple<string, string, string>("RDPF_1YR_GG_BPA_MADE_AGP_WRITE", "RDPF_1YR_GG_BPA_RATING_WRITE", "RDPF_1YR_GG_BPA_MGP_WRITE");
				yield return new Tuple<string, string, string>("RDPF_3YR_GG_FRL_MADE_AGP_READ", "RDPF_3YR_GG_FRL_RATING_READ", "RDPF_3YR_GG_FRL_MGP_READ");
				yield return new Tuple<string, string, string>("RDPF_3YR_GG_MIN_MADE_AGP_READ", "RDPF_3YR_GG_MIN_RATING_READ", "RDPF_3YR_GG_MIN_MGP_READ");
				yield return new Tuple<string, string, string>("RDPF_3YR_GG_DIS_MADE_AGP_READ", "RDPF_3YR_GG_DIS_RATING_READ", "RDPF_3YR_GG_DIS_MGP_READ");
				yield return new Tuple<string, string, string>("RDPF_3YR_GG_ELL_MADE_AGP_READ", "RDPF_3YR_GG_ELL_RATING_READ", "RDPF_3YR_GG_ELL_MGP_READ");
				yield return new Tuple<string, string, string>("RDPF_3YR_GG_BPA_MADE_AGP_READ", "RDPF_3YR_GG_BPA_RATING_READ", "RDPF_3YR_GG_BPA_MGP_READ");
				yield return new Tuple<string, string, string>("RDPF_3YR_GG_FRL_MADE_AGP_MATH", "RDPF_3YR_GG_FRL_RATING_MATH", "RDPF_3YR_GG_FRL_MGP_MATH");
				yield return new Tuple<string, string, string>("RDPF_3YR_GG_MIN_MADE_AGP_MATH", "RDPF_3YR_GG_MIN_RATING_MATH", "RDPF_3YR_GG_MIN_MGP_MATH");
				yield return new Tuple<string, string, string>("RDPF_3YR_GG_DIS_MADE_AGP_MATH", "RDPF_3YR_GG_DIS_RATING_MATH", "RDPF_3YR_GG_DIS_MGP_MATH");
				yield return new Tuple<string, string, string>("RDPF_3YR_GG_ELL_MADE_AGP_MATH", "RDPF_3YR_GG_ELL_RATING_MATH", "RDPF_3YR_GG_ELL_MGP_MATH");
				yield return new Tuple<string, string, string>("RDPF_3YR_GG_BPA_MADE_AGP_MATH", "RDPF_3YR_GG_BPA_RATING_MATH", "RDPF_3YR_GG_BPA_MGP_MATH");
				yield return new Tuple<string, string, string>("RDPF_3YR_GG_FRL_MADE_AGP_WRITE", "RDPF_3YR_GG_FRL_RATING_WRITE", "RDPF_3YR_GG_FRL_MGP_WRITE");
				yield return new Tuple<string, string, string>("RDPF_3YR_GG_MIN_MADE_AGP_WRITE", "RDPF_3YR_GG_MIN_RATING_WRITE", "RDPF_3YR_GG_MIN_MGP_WRITE");
				yield return new Tuple<string, string, string>("RDPF_3YR_GG_DIS_MADE_AGP_WRITE", "RDPF_3YR_GG_DIS_RATING_WRITE", "RDPF_3YR_GG_DIS_MGP_WRITE");
				yield return new Tuple<string, string, string>("RDPF_3YR_GG_ELL_MADE_AGP_WRITE", "RDPF_3YR_GG_ELL_RATING_WRITE", "RDPF_3YR_GG_ELL_MGP_WRITE");
				yield return new Tuple<string, string, string>("RDPF_3YR_GG_BPA_MADE_AGP_WRITE", "RDPF_3YR_GG_BPA_RATING_WRITE", "RDPF_3YR_GG_BPA_MGP_WRITE");
			}
		}

		public override void Test(Row row, Errors errors)
		{
			Columns.ForEach(t => AssertAGP(row, t.Item1, t.Item2, t.Item3, errors));
		}

		bool AssertAGP(Row row, string madeAgpColumn, string ratingColumn, string mgpColumn, Errors errors)
		{
			if(!Defined(row, madeAgpColumn, errors) && !Defined(row, ratingColumn, errors) && !Defined(row, mgpColumn, errors))
			{
				return true;
			}

			if(AssertDefined(row, madeAgpColumn, errors))
			{
				var madeMgp = row[madeAgpColumn];
				Func<double, string> rating = null;
				if (madeMgp.ToLower() == "yes") rating = RatingYes;
				if (madeMgp.ToLower() == "no") rating = RatingNo;
				if(rating != null)
				{
					return AssertRating(row, ratingColumn, mgpColumn, rating, errors);
				}
				else
				{
					errors.Add(row, "Unknown Made MGP State (should be 'Yes' or 'No'):" + madeMgp, GetPrettyName());
				}
				
			}
			return false;
		}

		string RatingYes(double value)
		{
			if (value >= 60.0) return Exceeds;
			if (value >= 45.0) return Meets;
			if (value >= 30.0) return Approaching;
			return DoesNotMeet;
		}

		string RatingNo(double value)
		{
			if (value >= 70.0) return Exceeds;
			if (value >= 55.0) return Meets;
			if (value >= 40.0) return Approaching;
			return DoesNotMeet;
		}
	}
}
