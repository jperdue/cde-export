using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cde.export
{
	public class District
	{
        public string id;
        public List<string> rows = new List<string>();
        public string header;
		public string name;

		public override string ToString()
		{
			return id + "(" + rows.Count + ")";
		}

		public IEnumerable<string> GetRows() {
			yield return header;
			foreach(var row in rows) {
				yield return row;
			}
		}

		public String GetFileName(string extension) {
			return id + "-" + name.Replace('/','-').Replace(':',' ') + "." + extension;
		}
    }
}
