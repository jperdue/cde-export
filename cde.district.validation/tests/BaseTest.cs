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

		protected bool AssertThat(bool result, Row row, string message, List<string> errors)
		{
			if (!result)
			{
				errors.Add(GetType().Name + " - " + message);
			}
			return result;
		}
	}
}
