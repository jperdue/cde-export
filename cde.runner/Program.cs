using cde.district.validation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cde.runner
{
	class Program
	{
		const string output = "output";

		static void Main(string[] args)
		{
			Setup();

			CompareFiles("input/marie.txt", "input/raj.txt");

			Directory.EnumerateFiles("input").ForEach(ValidateFile);
		}

		static void CompareFiles(string filename1, string filename2)
		{
			using (var writer = new StreamWriter(output + "/diff.txt"))
			{
				foreach(var result in new Differ().CompareFiles(filename1, filename2))
				{
					writer.WriteLine("---------- " + result.Title + " ----------");
					result.Errors.ForEach(e => writer.WriteLine(e));
				}
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
			var output = "output";
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

						errors.ForEach(e => writer.WriteLine(e.Message));

						writer.WriteLine();
					}
				}
			}
		}
	}
}
