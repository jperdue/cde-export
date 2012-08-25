using cde.district.validation;
using cde.district.validation.tests;
using cde.utils;
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

			return View();
		}

		[HttpPost]
		public ActionResult Test(HttpPostedFileBase file)
		{
			ViewBag.Message = "Results";

			if (file.ContentLength > 0)
			{
				return View(Test(file.InputStream));
			}

			return RedirectToAction("Index");
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		List<Result> Test(Stream stream)
		{
			var results = new List<Result>();
			var runner = new TestRunner();
			foreach (var row in Extension.GetRows(stream))
			{
				var errors = runner.Run(row);
				if (errors.Count > 0)
				{
					results.Add(new Result { Title = row.ToString(), Errors = errors });
				}
			}
			return results;
		}
	}
}
