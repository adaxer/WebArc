using Microsoft.AspNetCore.Mvc;
using Southwind.Contracts.Models;
using System.Diagnostics;

namespace Southwind.Presentation.Web.Controllers
{
    //[Route("[controller]")]
    public class HomeController : Controller
    {
        //[HttpGet("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
