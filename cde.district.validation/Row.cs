﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.district.validation
{
	public class Row : IEnumerable<KeyValuePair<string, string>>
	{
		const string Year = "ACADEMIC_YEAR";
		const string District = "DIST_NUMBER";
        const string School = "SCHOOL_NUMBER";
		const string DistrictName = "DISTRICT_NAME";
		const string SchoolLevel = "EMH_CODE";

        private Dictionary<string, string> data = new Dictionary<string, string>();
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
                else if(this.ContainsKey(School))
                {
                    return this[School];
                }
                else if (this.ContainsKey(District))
                {
                    return this[District];
                }
                else
                {
                    return "Unknown District or School Number";
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

        public bool ContainsKey(string key)
        {
            return data.ContainsKey(key);
        }

        public int Count
        {
            get { return data.Count; }
        }

        public string this[string key]
        {
            get
            {
                if (ContainsKey(key))
                {
                    return data[key];
                }
                else
                {
                    throw new Exception("Key (" + key + ") not found for row: " + Id);
                }
            }
            set { data[key] = value; }
        }

		public EDataType Type;

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
