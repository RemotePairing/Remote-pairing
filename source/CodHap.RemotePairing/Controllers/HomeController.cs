namespace CodHap.RemotePairing.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using Models;
    using SampleLib.Utils;

    public class HomeController : Controller
    {
        readonly DateTime _linkTimeLocal = Assembly.GetExecutingAssembly().GetLinkerTime();

        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEvents(DateTime start, DateTime end)
        {
            var rows = _context.CalendarEvents.ToList();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }


        public bool AddEvent(string name, string startDate, string time, string duration)
        {
            var dt = ParseDateAndTime(startDate, time);

            var newCalendarEvent = new CalendarEvent
            {
                title = name,
                start = dt.ToString("s"),
                end = dt.AddMinutes(Convert.ToInt32(duration)).ToString("s"),
                duration = duration,
                allDay = false
            };

            _context.CalendarEvents.Add(newCalendarEvent);
            _context.SaveChanges();
            return true;
        }

        private DateTime ParseDateAndTime(string date, string time)
        {
            var res = DateTime.ParseExact(date + " " + time, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
            return res;
        }

        public ActionResult About()
        {
            ViewBag.Message =
                $"Application build on: {_linkTimeLocal.ToLongTimeString()} {_linkTimeLocal.ToLongDateString()}";
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}