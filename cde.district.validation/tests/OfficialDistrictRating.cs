using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class OfficialDistrictRating : BaseTest
	{
        const string IncludedEMHForA = "INCLUDED_EMH_FOR_A";

		IEnumerable<Tuple<string, string>> Columns
		{
			get
			{
                yield return new Tuple<string, string>("A_TTL_DPF_RATING_CALC", "1_3_TOTAL_PCT_PTS_EARN");
                yield return new Tuple<string, string>("A_TTL_DPF_RATING_OFFICIAL", "1_3_TOTAL_PCT_PTS_EARN");
            }
		}

		public override void Test(Row row, Errors errors)
		{
            if (row.Type == EDataType.School || row.Level != "A")
            {
                return;
            }

    		Columns.ForEach(t => AssertRating(row, t.Item1, t.Item2, RatingDistrict, errors));
        }

		string RatingDistrict(double value)
		{
			if (value < 42.0) return "Accredited with Turnaround Plan";
			if (value < 52.0) return "Accredited w/Priority Improvement Plan";
			if (value < 64.0) return "Accredited with Improvement Plan";
			if (value < 80.0) return "Accredited";
			return "Accredited with Distinction";
		}
	}
}
