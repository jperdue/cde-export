using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using cde.district.validation;

namespace cde.district.validation.tests
{
	public abstract class BaseTest
	{
		protected const string DoesNotMeet = "Does Not Meet";
		protected const string Approaching = "Approaching";
		protected const string Meets = "Meets";
		protected const string Exceeds = "Exceeds";
		protected const string Unknown = "Unknown Rating";

		static Dictionary<Type, string> prettyNames = new Dictionary<Type, string>();

		public string GetPrettyName()
		{
			var type = GetType();
			if(!prettyNames.ContainsKey(type))
			{
				prettyNames[type] = type.Name.SplitCamelCase();
			}
			return prettyNames[type];
		}


		public abstract void Test(Row row, List<string> errors);

		protected bool AssertTrue(Row row, bool result, string message, List<string> errors)
		{
			if (!result)
			{
				errors.Add(GetPrettyName() + " - " + message);
			}
			return result;
		}

		protected bool AssertDefined(Row row, string column, List<string> errors)
		{
			if(Ignore.Column(row, column))
			{
				return false;
			}

			if (AssertTrue(row, row.ContainsKey(column), "Column undefined: " + column, errors))
			{
				return AssertTrue(row, Defined(row, column), "Value undefined for " + column, errors);
			}
			return false;
		}

		protected bool Defined(Row row, string column)
		{
			return !String.IsNullOrWhiteSpace(row[column]);
		}

		protected bool AssertDefined(Row row, IEnumerable<string> columns, List<string> errors)
		{
			return !columns.Any(c => !AssertDefined(row, c, errors));
		}

		protected bool AssertSum(Row row, string resultColumn, IEnumerable<string> partColumns, List<string> errors)
		{
			if(!AssertDefined(row, new [] { resultColumn }.Concat(partColumns), errors))
			{
				return false;
			}
			var total = double.Parse(row[resultColumn]);
			var sum = Sum(row, partColumns);

			var message = resultColumn + "(" + total + ") != " + partColumns.Aggregate((current, next) => current + " + " + next) + "(" + sum + ")";
			return AssertTrue(row, total.ToString() == sum.ToString(), message, errors);
		}

		protected double Sum(Row row, IEnumerable<string> partColumns)
		{
			return partColumns.Select(c => double.Parse(row[c])).Sum();
		}

		protected virtual bool AssertDivide(Row row, string resultColumn, string numeratorColumn, string denominatorColumn, List<string> errors)
		{
			if (!AssertDefined(row, new [] { resultColumn, numeratorColumn, denominatorColumn }, errors))
			{
				return false;
			}
			var result = double.Parse(row[resultColumn]);
			var numerator = double.Parse(row[numeratorColumn]);
			var denominator = double.Parse(row[denominatorColumn]);
			var divide = numerator / denominator * 100.0;

			var message = resultColumn + "(" + result + ") != " + numeratorColumn + "/" + denominatorColumn + "(" + divide + ")";
			return AssertTrue(row, result.Format() == divide.Format(), message, errors);
		}

		protected bool AssertRating(Row row, string ratingColumn, string percentOfPointsRatingColumn, Func<double, String> ratingLookup, List<string> errors)
		{
			if (AssertDefined(row, new[] { ratingColumn, percentOfPointsRatingColumn }, errors))
			{
				var rating = row[ratingColumn];
				double percent;
				if (AssertNumber(row, percentOfPointsRatingColumn, out percent, errors))
				{
					var expectedRating = ratingLookup(percent);

					var message = "'" + rating + "' != '" + expectedRating + "' (" + percent + "%) for " + ratingColumn + ", " + percentOfPointsRatingColumn;
					return AssertTrue(row, rating == expectedRating, message, errors);
				}
			}
			return false;
		}

		protected bool AssertNumber(Row row, string numberColumn, out double value, List<string> errors)
		{
			var numberValue = row[numberColumn];
			if (double.TryParse(numberValue, out value))
			{
				return true;
			}
			errors.Add("Value in '" + numberColumn + "' cannot be converted to a number (" + numberValue + ")");
			return false;
		}

		protected bool AssertEqual(Row row, string column1, string column2, List<string> errors)
		{
			if (AssertDefined(row, new[] { column1, column2 }, errors))
			{
				var column1Value = row[column1];
				var column2Value = row[column2];
				var message = column1 + " (" + column1Value + ") != " + column2 + " (" + column2Value + ")";
				return AssertTrue(row, column1Value == column2Value, message, errors);
			}
			return false;
		}

		protected bool AssertGreaterThan(Row row, string column1, string column2, List<string> errors)
		{
			double value1, value2;
			if(AssertNumber(row, column1, out value1, errors) &&
				AssertNumber(row, column2, out value2, errors))
			{
				var message = column1 + " (" + value1 + ") not greater than " + column2 + " (" + value2 + ")";
				return AssertTrue(row, value1 > value2, message, errors);
			}
			return false;
		}

		protected bool AssertSubtract(Row row, string column1, string column2, string resultColumn, List<string> errors)
		{
			double value1, value2, result;
			if (AssertNumber(row, column1, out value1, errors) &&
				AssertNumber(row, column2, out value2, errors) &&
				AssertNumber(row, resultColumn, out result, errors))
			{
				var message = column1 + " (" + value1 + ") - " + column2 + " (" + value2 + ") != " + resultColumn + " (" + result + ")";
				return AssertTrue(row, value1 - value2 == result, message, errors);
			}
			return false;
		}
	}
}
