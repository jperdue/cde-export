using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public class AcademicAchievementRating : BaseTest
	{
		Dictionary<string, double[]> GetRead1()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 59.30, 71.50, 84.40 } },
				{ "M", new double[] { 58.87, 70.50, 83.57 } },
				{ "H", new double[] { 57.14, 71.53, 84.78 } }
			};
		}

		Dictionary<string, double[]> GetMath1()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 57.99, 70.51, 84.60 } },
				{ "M", new double[] { 34.46, 50.00, 68.84 } },
				{ "H", new double[] { 18.30, 32.16, 52.06 } }
			};
		}

		Dictionary<string, double[]> GetWrite1()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 38.48, 54.72, 69.66 } },
				{ "M", new double[] { 42.37, 56.36, 72.27 } },
				{ "H", new double[] { 32.85, 48.61, 67.56 } }
			};
		}

		Dictionary<string, double[]> GetSci1()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 29.46, 48.00, 69.72 } },
				{ "M", new double[] { 28.57, 45.60, 69.09 } },
				{ "H", new double[] { 30.27, 48.93, 70.39 } }
			};
		}

		Dictionary<string, double[]> GetRead3()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 60.45, 72.19, 85.16 } },
				{ "M", new double[] { 56.61, 69.22, 81.53 } },
				{ "H", new double[] { 57.63, 71.31, 83.80 } }
			};
		}

		Dictionary<string, double[]> GetMath3()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 56.84, 70.37, 83.42 } },
				{ "M", new double[] { 36.37, 49.11, 65.33 } },
				{ "H", new double[] { 17.78, 30.51, 48.02 } }
			};
		}

		Dictionary<string, double[]> GetWrite3()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 41.44, 55.78, 71.02 } },
				{ "M", new double[] { 41.85, 56.80, 70.87 } },
				{ "H", new double[] { 33.82, 49.70, 67.71 } }
			};
		}

		Dictionary<string, double[]> GetSci3()
		{
			return new Dictionary<string, double[]>
			{
				{ "E", new double[] { 32.93, 47.50, 66.52 } },
				{ "M", new double[] { 30.02, 46.81, 65.86 } },
				{ "H", new double[] { 31.43, 49.18, 67.31 } }
			};
		}

		public override void Test(Row row, Errors errors)
		{
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
