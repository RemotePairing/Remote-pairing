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

            ViewBag.Message = "Your keys:" + GetSettings();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Great success!";

            return View();
        }

        public string GetSettings()
        {
            string res="";
            var settings = System.Configuration.ConfigurationManager.AppSettings;
            foreach (string key in settings)
            {
                res += $"key {key.ToString()} value: {settings[key]}\n";
            }
            return res;
        }
    }
}