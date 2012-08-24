using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace directory_diff
{
	class Program
	{
		static void Main(string[] args)
		{
			FindFiles(File.ReadAllText("path.txt"));
		}

		static void FindFiles(string path)
		{
			var matchedSchools = new Dictionary<string, School>();
			foreach(var school in GetSchools())
			{
				matchedSchools[school.Key] = school;
			}

			using (var writer = new StreamWriter("results.txt"))
			{
				foreach (var file in Directory.EnumerateFiles(path).Select(f => new FileInfo(f)))
				{
					var key = file.Name.Replace(" ", "").Replace('–','-');
					if (matchedSchools.ContainsKey(key))
					{
						matchedSchools[key].Matched = true;
					}
					else
					{
						writer.WriteLine("Could not find a school for file: " + key);
					}
				}

				foreach (var school in matchedSchools.Values.Where(s => !s.Matched))
				{
					writer.WriteLine("Could not find file for school: " + school.Key);
				}
			}
		}

		static IEnumerable<School> GetSchools()
		{
			foreach(var line in GetLines())
			{
				var parts = line.Split('\t');
				yield return new School
				{
					Year = int.Parse(parts[0]),
					DistrictId = int.Parse(parts[1]),
					DistrictName = parts[2],
					SchoolId = int.Parse(parts[3]),
					SchoolName = parts[4]
				};
			}
		}

		static IEnumerable<string> GetLines()
		{
			using (var file = new StreamReader("schools.txt"))
			{
				var first = true;
				var line = (String)null;
				while ((line = file.ReadLine()) != null)
				{
					if (first)
					{
						first = false;
					}
					else
					{
						yield return line;
					}
				}
			}
		}
	}
}
