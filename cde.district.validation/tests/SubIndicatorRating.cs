using cde.utils;
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
				yield return new Tuple<string, string>("RDPF_1YR_ACH_RATING_READ", "RDPF_1YR_ACH_PTS_EARN_READ");
				yield return new Tuple<string, string>("RDPF_1YR_ACH_RATING_MATH", "RDPF_1YR_ACH_PTS_EARN_MATH");
				yield return new Tuple<string, string>("RDPF_1YR_ACH_RATING_WRITE", "RDPF_1YR_ACH_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("RDPF_1YR_ACH_RATING_SCI", "RDPF_1YR_ACH_PTS_EARN_SCI");
				yield return new Tuple<string, string>("RDPF_3YR_ACH_RATING_READ", "RDPF_3YR_ACH_PTS_EARN_READ");
				yield return new Tuple<string, string>("RDPF_3YR_ACH_RATING_MATH", "RDPF_3YR_ACH_PTS_EARN_MATH");
				yield return new Tuple<string, string>("RDPF_3YR_ACH_RATING_WRITE", "RDPF_3YR_ACH_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("RDPF_3YR_ACH_RATING_SCI", "RDPF_3YR_ACH_PTS_EARN_SCI");
				yield return new Tuple<string, string>("RDPF_1YR_GRO_RATING_READ", "RDPF_1YR_GRO_PTS_EARN_READ");
				yield return new Tuple<string, string>("RDPF_1YR_GRO_RATING_MATH", "RDPF_1YR_GRO_PTS_EARN_MATH");
				yield return new Tuple<string, string>("RDPF_1YR_GRO_RATING_WRITE", "RDPF_1YR_GRO_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("RDPF_3YR_GRO_RATING_READ", "RDPF_3YR_GRO_PTS_EARN_READ");
				yield return new Tuple<string, string>("RDPF_3YR_GRO_RATING_MATH", "RDPF_3YR_GRO_PTS_EARN_MATH");
				yield return new Tuple<string, string>("RDPF_3YR_GRO_RATING_WRITE", "RDPF_3YR_GRO_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("RDPF_1YR_GG_FRL_RATING_READ", "RDPF_1YR_GG_FRL_PTS_EARN_READ");
				yield return new Tuple<string, string>("RDPF_1YR_GG_MIN_RATING_READ", "RDPF_1YR_GG_MIN_PTS_EARN_READ");
				yield return new Tuple<string, string>("RDPF_1YR_GG_DIS_RATING_READ", "RDPF_1YR_GG_DIS_PTS_EARN_READ");
				yield return new Tuple<string, string>("RDPF_1YR_GG_ELL_RATING_READ", "RDPF_1YR_GG_ELL_PTS_EARN_READ");
				yield return new Tuple<string, string>("RDPF_1YR_GG_BPA_RATING_READ", "RDPF_1YR_GG_BPA_PTS_EARN_READ");
				yield return new Tuple<string, string>("RDPF_1YR_GG_FRL_RATING_MATH", "RDPF_1YR_GG_FRL_PTS_EARN_MATH");
				yield return new Tuple<string, string>("RDPF_1YR_GG_MIN_RATING_MATH", "RDPF_1YR_GG_MIN_PTS_EARN_MATH");
				yield return new Tuple<string, string>("RDPF_1YR_GG_DIS_RATING_MATH", "RDPF_1YR_GG_DIS_PTS_EARN_MATH");
				yield return new Tuple<string, string>("RDPF_1YR_GG_ELL_RATING_MATH", "RDPF_1YR_GG_ELL_PTS_EARN_MATH");
				yield return new Tuple<string, string>("RDPF_1YR_GG_FRL_RATING_WRITE", "RDPF_1YR_GG_FRL_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("RDPF_1YR_GG_MIN_RATING_WRITE", "RDPF_1YR_GG_MIN_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("RDPF_1YR_GG_DIS_RATING_WRITE", "RDPF_1YR_GG_DIS_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("RDPF_1YR_GG_ELL_RATING_WRITE", "RDPF_1YR_GG_ELL_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("RDPF_1YR_GG_BPA_RATING_WRITE", "RDPF_1YR_GG_BPA_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("RDPF_1YR_GG_FRL_RATING_READ", "RDPF_1YR_GG_FRL_PTS_EARN_READ");
				yield return new Tuple<string, string>("RDPF_1YR_GG_MIN_RATING_READ", "RDPF_1YR_GG_MIN_PTS_EARN_READ");
				yield return new Tuple<string, string>("RDPF_1YR_GG_DIS_RATING_READ", "RDPF_1YR_GG_DIS_PTS_EARN_READ");
				yield return new Tuple<string, string>("RDPF_1YR_GG_ELL_RATING_READ", "RDPF_1YR_GG_ELL_PTS_EARN_READ");
				yield return new Tuple<string, string>("RDPF_1YR_GG_BPA_RATING_READ", "RDPF_1YR_GG_BPA_PTS_EARN_READ");
				yield return new Tuple<string, string>("RDPF_3YR_GG_FRL_RATING_MATH", "RDPF_3YR_GG_FRL_PTS_EARN_MATH");
				yield return new Tuple<string, string>("RDPF_3YR_GG_MIN_RATING_MATH", "RDPF_3YR_GG_MIN_PTS_EARN_MATH");
				yield return new Tuple<string, string>("RDPF_3YR_GG_DIS_RATING_MATH", "RDPF_3YR_GG_DIS_PTS_EARN_MATH");
				yield return new Tuple<string, string>("RDPF_3YR_GG_ELL_RATING_MATH", "RDPF_3YR_GG_ELL_PTS_EARN_MATH");
				yield return new Tuple<string, string>("RDPF_3YR_GG_FRL_RATING_WRITE", "RDPF_3YR_GG_FRL_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("RDPF_3YR_GG_MIN_RATING_WRITE", "RDPF_3YR_GG_MIN_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("RDPF_3YR_GG_DIS_RATING_WRITE", "RDPF_3YR_GG_DIS_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("RDPF_3YR_GG_ELL_RATING_WRITE", "RDPF_3YR_GG_ELL_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("RDPF_3YR_GG_BPA_RATING_WRITE", "RDPF_3YR_GG_BPA_PTS_EARN_WRITE");
				yield return new Tuple<string, string>("RDPF_1YR_PS_GRAD_RATING", "RDPF_1YR_PS_GRAD_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_1YR_PS_DROP_RATING ", "RDPF_1YR_PS_DROP_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_1YR_PS_ACT_RATING", "RDPF_1YR_PS_ACT_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_3YR_PS_GRAD_RATING", "RDPF_3YR_PS_GRAD_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_3YR_PS_DROP_RATING ", "RDPF_3YR_PS_DROP_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_3YR_PS_ACT_RATING", "RDPF_3YR_PS_ACT_PTS_EARN");
			}
		}

		IEnumerable<Tuple<string, string>> PointColumns
		{
			get
			{
				yield return new Tuple<string, string>("RDPF_1YR_GRO_RATING_ELP", "RDPF_1YR_GRO_PTS_EARN_ELP");
				yield return new Tuple<string, string>("RDPF_3YR_GRO_RATING_ELP", "RDPF_3YR_GRO_PTS_EARN_ELP");
				yield return new Tuple<string, string>("RDPF_1YR_PS_GRAD_FRL_RATING", "RDPF_1YR_PS_GRAD_FRL_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_1YR_PS_GRAD_MIN_RATING", "RDPF_1YR_PS_GRAD_MIN_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_1YR_PS_GRAD_IEP_RATING", "RDPF_1YR_PS_GRAD_IEP_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_1YR_PS_GRAD_ELL_RATING", "RDPF_1YR_PS_GRAD_ELL_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_3YR_PS_GRAD_FRL_RATING", "RDPF_3YR_PS_GRAD_FRL_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_3YR_PS_GRAD_MIN_RATING", "RDPF_3YR_PS_GRAD_MIN_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_3YR_PS_GRAD_IEP_RATING", "RDPF_3YR_PS_GRAD_IEP_PTS_EARN");
				yield return new Tuple<string, string>("RDPF_3YR_PS_GRAD_ELL_RATING", "RDPF_3YR_PS_GRAD_ELL_PTS_EARN");
			}
		}

		public override void Test(Row row, List<string> errors)
		{
			Columns.ForEach(t => AssertRating(row, t.Item1, t.Item2, GetRating, errors));
			PointColumns.ForEach(t => AssertRating(row, t.Item1, t.Item2, GetPointRating, errors));
		}

		string GetRating(double value)
		{
			switch((int)value)
			{
				case 4: return "Exceeds";
				case 3: return "Meets";
				case 2: return "Approaching";
				default: return "Does Not Meet";
			}
		}

		string GetPointRating(double value)
		{
			if (value == 1.0) return "Exceeds";
			if (value == 0.75) return "Meets";
			if (value == 0.5) return "Approaching";
			if (value == 0.25) return "Does Not Meet";
			return "Unknown Rating";
		}
	}
}
