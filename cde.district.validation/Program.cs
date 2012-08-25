using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cde.utils;
using System.IO;
using cde.district.validation.tests;

namespace cde.district.validation
{
	class Program
	{
		const string output = "output";

		static void Main(string[] args)
		{
			Setup();

			//CompareFiles("input/marie.txt", "input/raj.txt");

			Directory.EnumerateFiles("input").ForEach(ValidateFile);
		}

		static void CompareFiles(string filename1, string filename2)
		{
			using (var writer = new StreamWriter(output + "/diff.txt"))
			{
				Extension.GetRows(filename1).EnumerateWith(Extension.GetRows(filename2), (r1, r2) => DiffRows(r1, r2, writer));
			}
		}

		static void DiffRows(Row row1, Row row2, StreamWriter writer)
		{
			var errors = new List<string>();
			if(row1.Count != row2.Count)
			{
				errors.Add("Different column counts");
			}
			var smaller = row1.Count < row2.Count ? row1 : row2;
			var bigger = row1.Count >= row2.Count ? row1 : row2;
			foreach(var pair in smaller)
			{
				if(!bigger.ContainsKey(pair.Key))
				{
					errors.Add("Missing column: " + pair.Key);
				}
				else if(bigger[pair.Key] != pair.Value)
				{
					errors.Add("Mismatched value on column: " + pair.Key + "(" + pair.Value + "," + bigger[pair.Key] + ")");
				}
			}
			if(errors.Count > 0)
			{
				writer.WriteLine("Errors on line " + row1.LineNumber + " (" + row1.Name + ")");
				errors.ForEach(e => writer.WriteLine("    " + e));
			}
		}

		static void Setup()
		{
			if (Directory.Exists(output))
			{
				Directory.GetFiles(output).ForEach(f => File.Delete(f));
			}
			Directory.CreateDirectory(output);
		}

		static void ValidateFile(string filename)
		{
			var runner = new TestRunner();
			var outputFile = output + "\\" + new FileInfo(filename).Name;
			using (var writer = new StreamWriter(outputFile))
			{
				foreach (var row in Extension.GetRows(filename))
				{
					var errors = runner.Run(row);
					if (errors.Count > 0)
					{
						writer.WriteLine("---------- " + row + " ----------");

						errors.ForEach(e => writer.WriteLine(e));

						writer.WriteLine();
					}
				}
			}
		}
	}
}
