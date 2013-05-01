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
            get 
            {
                if (Type == EDataType.District)
                {
                    return this.ContainsKey(District) ? this[District] : "Unknown District ID";
                }
                else 
                {
                    return this.ContainsKey(School) ? this[School] : this[District];
                }
            }
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
