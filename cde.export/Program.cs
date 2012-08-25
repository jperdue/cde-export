using ExcelGenerator.SpreadSheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using cde.utils;

namespace cde.export
{
	class Program
	{
		const string output = "output";

		static void Main(string[] args)
		{
			Setup();

			Merge(GetDistricts()).OrderBy(d => d.id).ForEach(d => Write(d));
		}

		static void Setup()
		{
			if (Directory.Exists(output))
			{
				Directory.Delete(output, true);
			}
			Directory.CreateDirectory(output);
		}

		static void Write(District district)
		{
			if (district.rows.Count > 0)
			{
				Console.WriteLine(district.ToString());
				//WriteFile(district);
				WriteExcel(district);
			}
		}

		static void WriteFile(District district)
		{
			var file = output + "/" + district.GetFileName("txt");
			using (var writer = new StreamWriter(file))
			{
				writer.WriteLine(district.header);
				district.rows.ForEach(r => writer.WriteLine(r));
			}
		}

		static void WriteExcel(District district)
		{
			var file = output + "/" + district.GetFileName("xls");
			Workbook workbook = new Workbook();
			Worksheet worksheet = new Worksheet(district.id);
			foreach (var parts in district.GetRows().Select(r => r.Split('\t')))
			{
				ExcelGenerator.SpreadSheet.Row row = new ExcelGenerator.SpreadSheet.Row();
				parts.ForEach(p => row.Cells.Add(new Cell(p)));
				worksheet.Rows.Add(row);
			}
			workbook.Worksheets.Add(worksheet);
			workbook.save(file);
		}

		static IEnumerable<District> Merge(IEnumerable<District> source) {
			foreach(var group in source.GroupBy(d => d.id)) {
				var district = group.First();
				group.Skip(1).ForEach(d => district.rows.AddRange(d.rows));
				yield return district;
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
					district.name = parts[2];
				}
				else
				{
					if (district.id != parts[1])
					{
						yield return district;
						district = new District { id = parts[1], name = parts[2] };
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
