using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace directory_diff
{
	public class School
	{
		public int Year;
		public int DistrictId;
		public string DistrictName;
		public int SchoolId;
		public string SchoolName;
		public bool Matched = false;

		public string Key
		{
			get { return Year + "-" + DistrictId.ToString("D4") + "-" + SchoolId.ToString("D4") + ".pdf"; }
		}
	}
}
