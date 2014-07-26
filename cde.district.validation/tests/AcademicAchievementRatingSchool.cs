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
				{ "E", new double[] { 49.18, 71.65, 89.10 } },
				{ "M", new double[] { 50.44, 71.43, 88.24 } },
				{ "H", new double[] { 54.92, 73.33, 87.23 } }
			};
		}

		Dictionary<string, double[]> GetMath1()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 48.60, 70.89, 89.34 } },
				{ "M", new double[] { 29.72, 52.48, 75.00 } },
				{ "H", new double[] { 15.97, 33.52, 54.79 } }
			};
		}

		Dictionary<string, double[]> GetWrite1()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 32.48, 53.52, 76.83 } },
				{ "M", new double[] { 34.95, 57.77, 79.67 } },
				{ "H", new double[] { 30.96, 50.00, 72.24 } }
			};
		}

		Dictionary<string, double[]> GetSci1()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 19.67, 47.53, 75.96 } },
				{ "M", new double[] { 23.85, 48.00, 75.11 } },
				{ "H", new double[] { 27.50, 50.00, 72.41 } }
			};
		}

		Dictionary<string, double[]> GetRead3()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 50.00, 72.05, 88.21 } },
				{ "M", new double[] { 50.56, 71.35, 87.40 } },
				{ "H", new double[] { 53.34, 72.21, 86.17 } }
			};
		}

		Dictionary<string, double[]> GetMath3()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 48.73, 70.11, 87.48 } },
				{ "M", new double[] { 29.69, 51.63, 74.41 } },
				{ "H", new double[] { 13.49, 30.53, 52.19 } }
			};
		}

		Dictionary<string, double[]> GetWrite3()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 32.56, 54.84, 76.51 } },
				{ "M", new double[] { 36.84, 58.34, 79.17 } },
				{ "H", new double[] { 30.00, 49.57, 71.00 } }
			};
		}

		Dictionary<string, double[]> GetSci3()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 20.46, 45.36, 72.65 } },
				{ "M", new double[] { 25.00, 48.72, 71.26 } },
				{ "H", new double[] { 27.93, 50.00, 71.45 } }
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
