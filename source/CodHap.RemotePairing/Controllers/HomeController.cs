namespace CodHap.RemotePairing.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using Models;
    using Repositories;
    using SampleLib.Utils;

    public class HomeController : Controller
    {
        private Random r = new Random();
        private readonly CalendarEventRepository _calendarEventRepo = new CalendarEventRepository();
        readonly DateTime _linkTimeLocal = Assembly.GetExecutingAssembly().GetLinkerTime();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEvents(DateTime start, DateTime end)
        {
            var rows = _calendarEventRepo.List.ToArray();
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
                allDay = false
            };

            _calendarEventRepo.Add(newCalendarEvent);

            return true;
        }

        private DateTime ParseDateAndTime(string date, string time)
        {
            DateTime res;
            res = DateTime.ParseExact(date + " " + time, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
            return res;
        }

        public ActionResult About()
        {
            ViewBag.Message = $"Application build on: {_linkTimeLocal.ToLongTimeString()} {_linkTimeLocal.ToLongDateString()}";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}