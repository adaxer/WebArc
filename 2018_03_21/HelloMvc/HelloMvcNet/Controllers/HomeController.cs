using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloMvcNet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View(DateTime.Now);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Nix()
        {
            return View();
        }

        [Route("Home/Special/Info/{name}/{value}/{isok}")]
        public ActionResult Info(string name, bool? isok, int? value)
        {
           // var objects = shopService.GetCategories();
            return View(/*objects*/);
        }
    }
}