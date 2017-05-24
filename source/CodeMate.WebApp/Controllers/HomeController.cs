namespace CodeMate.WebApp.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;
    using Models;
    using Repositories;

    public class HomeController : Controller
    {
        private Random r = new Random();
        private CalendarEventRepository calendarEventRepo = new CalendarEventRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEvents(DateTime start, DateTime end)
        {
            var rows = calendarEventRepo.List.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }


        public bool AddEvent(string name, string startDate, string time, string duration)
        {
            var dt = ParseDateAndTime(startDate, time);

            var newCalendarEvent = new CalendarEvent
            {
                Id = r.Next(10000).ToString(),
                title = name,
                start = dt.ToString("s"),
                end = dt.AddMinutes(Convert.ToInt32(duration)).ToString("s"),
                duration = duration,
                AllDay = false
            };

            calendarEventRepo.Add(newCalendarEvent);

            return true;
        }

        private DateTime ParseDateAndTime(string date, string time)
        {
            var res = DateTime.ParseExact(date + " " + time, "dd-mm-yyyy HH:MM", CultureInfo.InvariantCulture);
            return res;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}