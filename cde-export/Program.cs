using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cde_export
{
	class Program
	{
		const string output = "output";

		static void Main(string[] args)
		{
			Setup();

			GetDistricts().OrderBy(d => d.id).ForEach(d => WriteFile(d));
			Console.ReadKey();
		}

		static void Setup()
		{
			if (Directory.Exists(output))
			{
				Directory.Delete(output, true);
			}
			Directory.CreateDirectory(output);
		}

		static void WriteFile(District district)
		{
			var file = output + "/" + district.id + ".txt";
			if (File.Exists(file))
			{
				File.AppendAllLines(file, district.rows);
			}
			else
			{
				using (var writer = new StreamWriter(file))
				{
					Console.WriteLine(district.ToString());
					writer.WriteLine(district.header);
					district.rows.ForEach(r => writer.WriteLine(r));
				}
			}
		}

		static IEnumerable<District> GetDistricts()
		{
			var first = true;
			string header = null;
			District district = new District();
			foreach (var line in GetLines())
			{
				var parts = line.Split('\t').ToList();
				if (first)
				{
					first = false;
					header = line;
					district.id = parts[1];
				}
				else
				{
					if (district.id != parts[1])
					{
						yield return district;
						district = new District { id = parts[1] };
					}
					district.header = header;
					district.rows.Add(line);
				}
			}
		}

		static IEnumerable<string> GetLines()
		{
			using (var file = new StreamReader("district.txt"))
			{
				var line = (String)null;
				while ((line = file.ReadLine()) != null)
				{
					yield return line;
				}
			}
		}
	}
}
