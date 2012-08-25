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

		protected bool AssertThat(Row row, bool result, string message, List<string> errors)
		{
			if (!result)
			{
				errors.Add(GetType().Name + " - " + message);
			}
			return result;
		}

		protected bool AssertUndefined(Row row, string column, List<string> errors)
		{
			if (AssertThat(row, row.ContainsKey(column), "Column undefined: " + column, errors))
			{
				return AssertThat(row, !String.IsNullOrEmpty(row[column]), "Value undefined for " + column, errors);
			}
			return false;
		}
	}
}
