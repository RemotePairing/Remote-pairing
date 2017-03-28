using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeMate.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page3.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Great success!";

            return View();
        }
    }
}