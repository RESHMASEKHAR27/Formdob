using Formdob.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Formdob.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new User();
            return View(model);
        }

        [HttpPost]
        public ActionResult Submit(User model)
        {
           
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - model.DateOfBirth.Year;
            if (currentDate < model.DateOfBirth.AddYears(age)) age--;

            if (age < 18 && Request.Form["submitButton"] == "below18")
            {
                return RedirectToAction("Kids");
            }
            else if (age >= 18 && Request.Form["submitButton"] == "above18")
            {
               
                return RedirectToAction("Adult");
            }
            else
            {
               
                return RedirectToAction("Submit");
            }
        }

        public ActionResult Kids()
        {
            
            return View();
        }

        public ActionResult Adult()
        {
            
            return View();
        }

        public ActionResult Submit()
        {
           
            return View();
        }
    


    public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
