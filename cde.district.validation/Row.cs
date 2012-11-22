using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation
{
	public class Row : Dictionary<string, string>
	{
		const string Year = "ACADEMIC_YEAR";
		const string District = "DIST_NUMBER";
        const string School = "SCHOOL_NUMBER";
		const string DistrictName = "DISTRICT_NAME";
		const string SchoolLevel = "EMH_CODE";

		public int LineNumber;

		public string Name
		{
			get { return Id + "-" + Level; }
		}

        public string Id
        {
            get { return Type == EDataType.District ? this[District] : this[School]; }
        }


		public override string ToString()
		{
			return Name + " (" + LineNumber + ")";
		}

		public string Level
		{
			get { return this[SchoolLevel]; }
		}

		public EDataType Type;
	}
}
