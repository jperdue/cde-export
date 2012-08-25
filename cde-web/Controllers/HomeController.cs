using cde.district.validation;
using cde.district.validation.tests;
using cde.utils;
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
				var fileName = Path.GetFileName(file.FileName);
				var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
				//file.SaveAs(path);
				var errors = new List<Error> { new Error { Message = "barf" }, new Error { Message = "fart" } };
				return View(errors);
			}

			return RedirectToAction("Index");
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		List<Error> Test(Stream stream)
		{
			var runner = new TestRunner();
				foreach (var row in Extension.GetRows(stream))
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
