using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using cde.utils;
using cde.district.validation.tests;

namespace cde.district.validation
{
	public class TestRunner
	{
		static List<BaseTest> tests = null;

		List<BaseTest> Tests
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

		public List<string> Run(Row row)
		{
			var errors = new List<string>();
			Tests.ForEach(t => t.Test(row, errors));
			return errors;
		}
	}
}
