namespace CodHap.RemotePairing.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using DAL;
    using Models;

    public class RpEventController : Controller
    {
        private readonly CalendarDbContext db = new CalendarDbContext();

        public ActionResult Details(string id)
        {
            CalendarEvent calEvent = db.CalendarEvents.FirstOrDefault(x => x.Id == id);
            if (calEvent == null)
                return HttpNotFound($"No calendar event in DB with ID={id}");
            return View(calEvent);
        }
    }
}