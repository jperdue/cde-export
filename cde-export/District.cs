using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cde_export
{
	public class District
	{
        public string id;
        public List<string> rows = new List<string>();
        public string header;

		public override string ToString()
		{
			return id + "(" + rows.Count + ")";
		}
    }
}
