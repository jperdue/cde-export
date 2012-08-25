using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation
{
	public class Error
	{
		public string Message;
		public string Filename;

		public override string ToString()
		{
			return Filename + ": " + Message;
		}
	}
}
