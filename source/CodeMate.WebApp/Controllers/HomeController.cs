using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeMate.WebApp.Controllers
{
    using Models;
    using System.Globalization;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    public class HomeController : Controller
    {
        private List<CalendarEvent> eventList;
        private readonly string path = @"C:\temp\db.txt";
        Random r = new Random();
        public HomeController()
        {
            eventList = Deserialize();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEvents(DateTime start, DateTime end)
        {
            //var fromDate = ConvertFromUnixTimestamp(start);
            //var toDate = ConvertFromUnixTimestamp(end);

            //Get the events
            //You may get from the repository also
            var rows = Deserialize().ToArray();

            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        private void Serialize(Object obj)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path,
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, obj);
            stream.Close();
        }

        private List<CalendarEvent> Deserialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path,
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
            List<CalendarEvent> obj = (List<CalendarEvent>)formatter.Deserialize(stream);
            stream.Close();
            return obj;
        }

        public bool AddEvent(string name, string startDate, string time, string duration)
        {
            try
            {
                int size = eventList.Count;
                var dt = ParseDateAndTime(startDate, time);
                eventList.Add(new CalendarEvent
                {
                    Id = r.Next(10000).ToString(),
                    title = name,
                    start = dt.ToString("s"),
                    end = dt.AddMinutes(Convert.ToInt32(duration)).ToString("s"),
                    duration = duration,
                    AllDay = false
                });

                Serialize(eventList);
            }
            catch (Exception ex)
            {

                throw;
            }

            return true;
        }

        private DateTime ParseDateAndTime(string date, string time)
        {
            var res = DateTime.ParseExact(date + " " + time, "dd-mm-yyyy HH:MM", CultureInfo.InvariantCulture);
            return res;
        }

        private List<CalendarEvent> InitEvents()
        {
            eventList = new List<CalendarEvent>();
            CalendarEvent newEvent = new CalendarEvent
            {
                Id = 3.ToString(),
                title = $"Event 0",
                start = DateTime.UtcNow.AddDays(1).AddMinutes(30).ToString("s"),
                end = DateTime.UtcNow.AddDays(1).AddMinutes(60).ToString("s"),                    
                AllDay = false
            };
            eventList.Add(newEvent);

            eventList.Add(new CalendarEvent
            {
                Id = 4.ToString(),
                title = $"Event 1",
                start = DateTime.UtcNow.AddDays(2).AddMinutes(30).ToString("s"),
                end = DateTime.UtcNow.AddDays(2).AddMinutes(60).ToString("s"),
                AllDay = false
            });

            return eventList;
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
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