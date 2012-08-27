using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation
{
	public class Error
	{
		public string Column;
		public string District;
		public string Message;

		public Error(string district, string column, string message)
		{
			District = district;
			Column = column;
			Message = message;
		}
	}
}
