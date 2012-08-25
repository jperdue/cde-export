using cde.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace cde.district.validation.tests
{
	public abstract class BaseTest
	{
		public abstract void Test(Row row, List<string> errors);

		protected bool AssertTrue(Row row, bool result, string message, List<string> errors)
		{
			if (!result)
			{
				errors.Add(GetType().Name + " - " + message);
			}
			return result;
		}

		protected bool AssertDefined(Row row, string column, List<string> errors)
		{
			if (AssertTrue(row, row.ContainsKey(column), "Column undefined: " + column, errors))
			{
				return AssertTrue(row, !String.IsNullOrEmpty(row[column]), "Value undefined for " + column, errors);
			}
			return false;
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
			var sum = partColumns.Select(c => double.Parse(row[c])).Sum();

			var message = resultColumn + "(" + total + ") != " + partColumns.Aggregate((current, next) => current + " + " + next) + "(" + sum + ")";
			return AssertTrue(row, total.ToString() == sum.ToString(), message, errors);
		}

		protected bool AssertDivide(Row row, string resultColumn, string numeratorColumn, string denominatorColumn, List<string> errors)
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
			return AssertTrue(row, result.ToString() == divide.ToString(), message, errors);
		}
	}
}
