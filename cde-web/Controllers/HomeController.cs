using cde.district.validation;
using cde.district.validation.tests;
using cde_web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cde_web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Get Started";
			ViewBag.Tests = GetTests();

			return View();
		}

		[HttpPost]
		public ActionResult Test(HttpPostedFileBase file)
		{
			ViewBag.Message = "Results";

			if (file != null && file.ContentLength > 0)
			{
				var results = Test(file.InputStream, Request.Params["testname"]);
				ViewBag.TotalErrors = results.Sum(r => r.Errors.Count);
				return View(results);
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult Diff(IEnumerable<HttpPostedFileBase> files)
		{
			ViewBag.Message = "Results";

			var fileList = files.ToList();
			if (fileList.Count == 2)
			{
				var file1 = files.ToList()[0];
				var file2 = files.ToList()[1];

				if (file1.ContentLength > 0 && file2.ContentLength > 0)
				{
					return View(Diff(file1.InputStream, file2.InputStream));
				}
			}

			return RedirectToAction("Index");
		}

		List<Result> Diff(Stream stream1, Stream stream2)
		{
			return new Differ().CompareFiles(stream1, stream2).ToList();
		}

		List<Result> Test(Stream stream, string testName)
		{
			var results = new List<Result>();
			var runner = new TestRunner();
			var errors = Extension.GetRows(stream).Select(r => runner.Run(r, testName)).SelectMany(e => e);
			foreach (var group in errors.GroupBy(e => e.Message))
			{
				results.Add(new Result { Title = group.Key, Errors = group.Select(e => e.Row.ToString() ).ToList()});
			}
			return results;
		}

		IEnumerable<SelectListItem> GetTests()
		{
			yield return new SelectListItem { Selected = true, Text = "All", Value = "All" };
			foreach(var test in TestRunner.Tests.OrderBy(t => t.GetPrettyName()))
			{
				yield return new SelectListItem { Text = test.GetPrettyName(), Value = test.GetPrettyName() };
			}
		}
	}
}
