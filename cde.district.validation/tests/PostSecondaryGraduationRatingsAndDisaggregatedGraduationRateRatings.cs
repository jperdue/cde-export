using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class PostSecondaryGraduationRatingsAndDisaggregatedGraduationRateRatings : BaseTest
	{
		IEnumerable<Tuple<string, string>> Columns
		{
			get
			{
				yield return new Tuple<string, string>("1YR_PS_GRAD_RATING", "1YR_PS_GRAD_BEST_GR");
				yield return new Tuple<string, string>("3YR_PS_GRAD_RATING", "3YR_PS_GRAD_BEST_GR");

				yield return new Tuple<string, string>("1YR_PS_GRAD_FRL_RATING", "1YR_PS_GRAD_FRL_BEST_GR");
				yield return new Tuple<string, string>("1YR_PS_GRAD_MIN_RATING", "1YR_PS_GRAD_MIN_BEST_GR");
				yield return new Tuple<string, string>("1YR_PS_GRAD_IEP_RATING", "1YR_PS_GRAD_IEP_BEST_GR");
				yield return new Tuple<string, string>("1YR_PS_GRAD_ELL_RATING", "1YR_PS_GRAD_ELL_BEST_GR");

				yield return new Tuple<string, string>("3YR_PS_GRAD_FRL_RATING", "3YR_PS_GRAD_FRL_BEST_GR");
				yield return new Tuple<string, string>("3YR_PS_GRAD_MIN_RATING", "3YR_PS_GRAD_MIN_BEST_GR");
				yield return new Tuple<string, string>("3YR_PS_GRAD_IEP_RATING", "3YR_PS_GRAD_IEP_BEST_GR");
				yield return new Tuple<string, string>("3YR_PS_GRAD_ELL_RATING", "3YR_PS_GRAD_ELL_BEST_GR");
			}
		}

		public override void Test(Row row, Errors errors)
		{
			Columns.ForEach(t => AssertRating(row, t.Item1, t.Item2, Rating, errors));
		}

		protected override bool AssertRating(Row row, string ratingColumn, string valueColumn, Func<double, string> ratingLookup, Errors errors, bool passIfBlank = false)
		{
			if(!Defined(row, valueColumn, errors) && !Defined(row, valueColumn, errors))
			{
				return true;
			}
			return base.AssertRating(row, ratingColumn, valueColumn, ratingLookup, errors, passIfBlank);
		}

		string Rating(double value)
		{
			if (value >= 90.0) return Exceeds;
			if (value >= 80.0) return Meets;
			if (value >= 65.0) return Approaching;
			return DoesNotMeet;
		}
	}
}
