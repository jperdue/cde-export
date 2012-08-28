using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using cde.district.validation.tests;

namespace cde.district.validation
{
	public class TestRunner
	{
		static List<BaseTest> tests = null;

		public static IEnumerable<BaseTest> Tests
		{
			get
			{
				if(tests == null)
				{
					tests = new List<BaseTest>();
					foreach(var type in Assembly.GetExecutingAssembly().GetTypes())
					{
						if(type.BaseType == typeof(BaseTest))
						{
							tests.Add((BaseTest)type.GetConstructor(Type.EmptyTypes).Invoke(null));
						}
					}
				}
				return tests;
			}
		}

		public Errors Run(Row row)
		{
			return Run(row, "All");
		}

		public Errors Run(Row row, string testName)
		{
			var errors = new Errors();
			var testsToRun = Tests;
			if(testName != "All")
			{
				testsToRun = testsToRun.Where(t => t.GetPrettyName() == testName);
			}
			testsToRun.ForEach(t => t.Test(row, errors));
			return errors;
		}
	}
}
