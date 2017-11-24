namespace CodHap.RemotePairing.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Models;

    public class RpEventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RpEventController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Details(long id)
        {
            CalendarEvent calEvent = _context.CalendarEvents.SingleOrDefault(x => x.Id == id);
            if (calEvent == null)
                return HttpNotFound($"No calendar event in DB with ID={id}");
            return View(calEvent);
        }
    }
}