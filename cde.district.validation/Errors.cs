using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation
{
	public class Errors : IEnumerable<Errors.Value>
	{
		List<Value> Values = new List<Value>();

		public int Count
		{
			get { return Values.Count; }
		}

		public void Add(Row row, string message)
		{
			Values.Add(new Value { Row = row, Message = message });
		}

		public class Value
		{
			public Row Row;
			public string Message;
		}

		public IEnumerator<Errors.Value> GetEnumerator()
		{
			return Values.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
