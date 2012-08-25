using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.utils
{
	public class Row : Dictionary<string, string>
	{
		const string Year = "RDPF_ACADEMIC_YEAR";
		const string District = "RDPF_DIST_NUMBER";
		const string DistrictName = "RDPF_DISTRICT_NAME";
		const string SchoolLevel = "RDPF_EMH_CODE";

		public int LineNumber;

		public string Name
		{
			get { return this[District] + "-" + this[SchoolLevel]; }
		}

		public override string ToString()
		{
			return Name + " (" + LineNumber + ")";
		}
	}
}
