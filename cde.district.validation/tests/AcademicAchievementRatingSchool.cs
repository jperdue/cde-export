using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class AcademicAchievementRatingSchool : BaseTest
	{
		Dictionary<string, double[]> GetRead1()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 49.20, 71.60, 89.10 } },
				{ "M", new double[] { 50.40, 71.40, 73.30 } },
				{ "H", new double[] { 54.90, 73.30, 87.20  } }
			};
		}

		Dictionary<string, double[]> GetMath1()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 48.60, 70.90, 89.30 } },
				{ "M", new double[] { 29.70, 52.50, 75.00 } },
				{ "H", new double[] { 16.00, 33.50, 54.80 } }
			};
		}

		Dictionary<string, double[]> GetWrite1()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 32.50, 53.50, 76.80 } },
				{ "M", new double[] { 35.00, 57.80, 79.70 } },
				{ "H", new double[] { 31.00, 50.00, 72.20 } }
			};
		}

		Dictionary<string, double[]> GetSci1()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 19.70, 47.50, 76.00 } },
				{ "M", new double[] { 23.80, 48.00, 75.10 } },
				{ "H", new double[] { 25.70, 50.00, 72.40 } }
			};
		}

		Dictionary<string, double[]> GetRead3()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 50.00, 72.00, 88.20 } },
				{ "M", new double[] { 50.60, 71.40, 87.40 } },
				{ "H", new double[] { 53.30, 72.20, 86.20 } }
			};
		}

		Dictionary<string, double[]> GetMath3()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 48.70, 70.10, 87.50 } },
				{ "M", new double[] { 29.70, 51.60, 74.40 } },
				{ "H", new double[] { 13.50, 30.50, 52.20 } }
			};
		}

		Dictionary<string, double[]> GetWrite3()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 32.60, 54.80, 76.50 } },
				{ "M", new double[] { 36.80, 58.30, 79.20 } },
				{ "H", new double[] { 30.00, 49.60, 71.00 } }
			};
		}

		Dictionary<string, double[]> GetSci3()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 20.50, 25.00, 27.90 } },
				{ "M", new double[] { 25.00, 48.70, 71.03 } },
				{ "H", new double[] { 27.90, 50.00, 71.50 } }
			};
		}

		public override void Test(Row row, Errors errors)
		{
			if (row.Type == EDataType.District) return;

			AssertRating(row, "1YR_ACH_PA_PCT_READ", "1YR_ACH_RATING_READ", GetRead1(), errors);
			AssertRating(row, "1YR_ACH_PA_PCT_MATH", "1YR_ACH_RATING_MATH", GetMath1(), errors);
			AssertRating(row, "1YR_ACH_PA_PCT_WRITE", "1YR_ACH_RATING_WRITE", GetWrite1(), errors);
			AssertRating(row, "1YR_ACH_PA_PCT_SCI", "1YR_ACH_RATING_SCI", GetSci1(), errors);

			AssertRating(row, "3YR_ACH_PA_PCT_READ", "3YR_ACH_RATING_READ", GetRead3(), errors);
			AssertRating(row, "3YR_ACH_PA_PCT_MATH", "3YR_ACH_RATING_MATH", GetMath3(), errors);
			AssertRating(row, "3YR_ACH_PA_PCT_WRITE", "3YR_ACH_RATING_WRITE", GetWrite3(), errors);
			AssertRating(row, "3YR_ACH_PA_PCT_SCI", "3YR_ACH_RATING_SCI", GetSci3(), errors);
		}

		bool AssertRating(Row row, string percentColumn, string ratingColumn, Dictionary<string, double[]> cutoffs, Errors errors)
		{
			if(!Defined(row, percentColumn, errors) && !Defined(row, ratingColumn, errors))
			{
				return true;
			}

			return AssertRating(row, ratingColumn, percentColumn, v => GetRating(row.Level, v, cutoffs), errors);
		}

		string GetRating(string level, double value, Dictionary<string, double[]> cutoffs)
		{
			return GetRating(value, cutoffs[level]);
		}

		string GetRating(double value, double[] cutoffs)
		{
			if (value < cutoffs[0]) return DoesNotMeet;
			if (value < cutoffs[1]) return Approaching;
			if (value < cutoffs[2]) return Meets;
			return Exceeds;
		}
	}
}
