using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class SubIndicatorRating : BaseTest
	{
		IEnumerable<Tuple<string, string>> Columns
		{
			get
			{
				yield return new Tuple<string, string>("1YR_ACH_RATING_READ", "1YR_ACH_PTS_EARN_READ");
				yield return new Tuple<string, string>("1YR_ACH_RATING_MATH", "1YR_ACH_PTS_EARN_MATH");
				yield return new Tuple<string, string>("1YR_ACH_RATING_WRITE", "1YR_ACH_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("1YR_ACH_RATING_SCI", "1YR_ACH_PTS_EARN_SCI");
				yield return new Tuple<string, string>("3YR_ACH_RATING_READ", "3YR_ACH_PTS_EARN_READ");
				yield return new Tuple<string, string>("3YR_ACH_RATING_MATH", "3YR_ACH_PTS_EARN_MATH");
				yield return new Tuple<string, string>("3YR_ACH_RATING_WRITE", "3YR_ACH_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("3YR_ACH_RATING_SCI", "3YR_ACH_PTS_EARN_SCI");
				yield return new Tuple<string, string>("1YR_GRO_RATING_READ", "1YR_GRO_PTS_EARN_READ");
				yield return new Tuple<string, string>("1YR_GRO_RATING_MATH", "1YR_GRO_PTS_EARN_MATH");
				yield return new Tuple<string, string>("1YR_GRO_RATING_WRITE", "1YR_GRO_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("3YR_GRO_RATING_READ", "3YR_GRO_PTS_EARN_READ");
				yield return new Tuple<string, string>("3YR_GRO_RATING_MATH", "3YR_GRO_PTS_EARN_MATH");
				yield return new Tuple<string, string>("3YR_GRO_RATING_WRITE", "3YR_GRO_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("1YR_GG_FRL_RATING_READ", "1YR_GG_FRL_PTS_EARN_READ");
				yield return new Tuple<string, string>("1YR_GG_MIN_RATING_READ", "1YR_GG_MIN_PTS_EARN_READ");
				yield return new Tuple<string, string>("1YR_GG_DIS_RATING_READ", "1YR_GG_DIS_PTS_EARN_READ");
				yield return new Tuple<string, string>("1YR_GG_ELL_RATING_READ", "1YR_GG_ELL_PTS_EARN_READ");
				yield return new Tuple<string, string>("1YR_GG_BPA_RATING_READ", "1YR_GG_BPA_PTS_EARN_READ");
				yield return new Tuple<string, string>("1YR_GG_FRL_RATING_MATH", "1YR_GG_FRL_PTS_EARN_MATH");
				yield return new Tuple<string, string>("1YR_GG_MIN_RATING_MATH", "1YR_GG_MIN_PTS_EARN_MATH");
				yield return new Tuple<string, string>("1YR_GG_DIS_RATING_MATH", "1YR_GG_DIS_PTS_EARN_MATH");
				yield return new Tuple<string, string>("1YR_GG_ELL_RATING_MATH", "1YR_GG_ELL_PTS_EARN_MATH");
				yield return new Tuple<string, string>("1YR_GG_FRL_RATING_WRITE", "1YR_GG_FRL_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("1YR_GG_MIN_RATING_WRITE", "1YR_GG_MIN_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("1YR_GG_DIS_RATING_WRITE", "1YR_GG_DIS_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("1YR_GG_ELL_RATING_WRITE", "1YR_GG_ELL_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("1YR_GG_BPA_RATING_WRITE", "1YR_GG_BPA_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("1YR_GG_FRL_RATING_READ", "1YR_GG_FRL_PTS_EARN_READ");
				yield return new Tuple<string, string>("1YR_GG_MIN_RATING_READ", "1YR_GG_MIN_PTS_EARN_READ");
				yield return new Tuple<string, string>("1YR_GG_DIS_RATING_READ", "1YR_GG_DIS_PTS_EARN_READ");
				yield return new Tuple<string, string>("1YR_GG_ELL_RATING_READ", "1YR_GG_ELL_PTS_EARN_READ");
				yield return new Tuple<string, string>("1YR_GG_BPA_RATING_READ", "1YR_GG_BPA_PTS_EARN_READ");
				yield return new Tuple<string, string>("3YR_GG_FRL_RATING_MATH", "3YR_GG_FRL_PTS_EARN_MATH");
				yield return new Tuple<string, string>("3YR_GG_MIN_RATING_MATH", "3YR_GG_MIN_PTS_EARN_MATH");
				yield return new Tuple<string, string>("3YR_GG_DIS_RATING_MATH", "3YR_GG_DIS_PTS_EARN_MATH");
				yield return new Tuple<string, string>("3YR_GG_ELL_RATING_MATH", "3YR_GG_ELL_PTS_EARN_MATH");
				yield return new Tuple<string, string>("3YR_GG_FRL_RATING_WRITE", "3YR_GG_FRL_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("3YR_GG_MIN_RATING_WRITE", "3YR_GG_MIN_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("3YR_GG_DIS_RATING_WRITE", "3YR_GG_DIS_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("3YR_GG_ELL_RATING_WRITE", "3YR_GG_ELL_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("3YR_GG_BPA_RATING_WRITE", "3YR_GG_BPA_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("1YR_PS_GRAD_RATING", "1YR_PS_GRAD_PTS_EARN");
				yield return new Tuple<string, string>("1YR_PS_DROP_RATING", "1YR_PS_DROP_PTS_EARN");
				yield return new Tuple<string, string>("1YR_PS_ACT_RATING", "1YR_PS_ACT_PTS_EARN");
				yield return new Tuple<string, string>("3YR_PS_GRAD_RATING", "3YR_PS_GRAD_PTS_EARN");
				yield return new Tuple<string, string>("3YR_PS_DROP_RATING", "3YR_PS_DROP_PTS_EARN");
				yield return new Tuple<string, string>("3YR_PS_ACT_RATING", "3YR_PS_ACT_PTS_EARN");
			}
		}

		IEnumerable<Tuple<string, string>> ElpColumns
		{
			get
			{
				yield return new Tuple<string, string>("1YR_GRO_RATING_ELP", "1YR_GRO_PTS_EARN_ELP");
				yield return new Tuple<string, string>("3YR_GRO_RATING_ELP", "3YR_GRO_PTS_EARN_ELP");
			}
		}

		IEnumerable<Tuple<string, string>> PointColumns
		{
			get
			{
				yield return new Tuple<string, string>("1YR_PS_GRAD_FRL_RATING", "1YR_PS_GRAD_FRL_PTS_EARN");
				yield return new Tuple<string, string>("1YR_PS_GRAD_MIN_RATING", "1YR_PS_GRAD_MIN_PTS_EARN");
				yield return new Tuple<string, string>("1YR_PS_GRAD_IEP_RATING", "1YR_PS_GRAD_IEP_PTS_EARN");
				yield return new Tuple<string, string>("1YR_PS_GRAD_ELL_RATING", "1YR_PS_GRAD_ELL_PTS_EARN");
				yield return new Tuple<string, string>("3YR_PS_GRAD_FRL_RATING", "3YR_PS_GRAD_FRL_PTS_EARN");
				yield return new Tuple<string, string>("3YR_PS_GRAD_MIN_RATING", "3YR_PS_GRAD_MIN_PTS_EARN");
				yield return new Tuple<string, string>("3YR_PS_GRAD_IEP_RATING", "3YR_PS_GRAD_IEP_PTS_EARN");
				yield return new Tuple<string, string>("3YR_PS_GRAD_ELL_RATING", "3YR_PS_GRAD_ELL_PTS_EARN");
			}
		}

		public override void Test(Row row, Errors errors)
		{
			Columns.ForEach(t => AssertRating(row, t.Item1, t.Item2, GetRating, errors, true));
			PointColumns.ForEach(t => AssertRating(row, t.Item1, t.Item2, GetPointRating, errors, true));
			ElpColumns.ForEach(t => AssertRating(row, t.Item1, t.Item2, GetElpRating, errors, true));
		}

        protected override bool AssertRating(Row row, string ratingColumn, string valueColumn, Func<double, string> ratingLookup, Errors errors, bool passIfBlank = false)
        {
            if (Defined(row, ratingColumn, errors))
            {
                return base.AssertRating(row, ratingColumn, valueColumn, ratingLookup, errors, passIfBlank);
            }
            return true;
        }

		string GetRating(double value)
		{
			switch((int)value)
			{
				case 4: return Exceeds;
				case 3: return Meets;
				case 2: return Approaching;
				default: return DoesNotMeet;
			}
		}

		string GetPointRating(double value)
		{
			if (value == 1.0) return Exceeds;
			if (value == 0.75) return Meets;
			if (value == 0.5) return Approaching;
			if (value == 0.25) return DoesNotMeet;
			return Unknown;
		}

		string GetElpRating(double value)
		{
			if (value == 2.0) return Exceeds;
			if (value == 1.5) return Meets;
			if (value == 1.0) return Approaching;
			if (value == 0.5) return DoesNotMeet;
			return Unknown;
		}
	}
}
