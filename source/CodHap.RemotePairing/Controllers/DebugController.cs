using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodHap.RemotePairing.Models;

namespace CodHap.RemotePairing.Controllers
{
    public class DebugController : Controller
    {
        private ApplicationDbContext _context;
        public DebugController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Debug
        public ActionResult Index()
        {
            return View(_context.CalendarEvents.ToList());
        }

        // GET: Debug/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarEvent calendarEvent = _context.CalendarEvents.Find(id);
            if (calendarEvent == null)
            {
                return HttpNotFound();
            }
            return View(calendarEvent);
        }

        // GET: Debug/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Debug/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,title,start,end,duration,allDay")] CalendarEvent calendarEvent)
        {
            if (ModelState.IsValid)
            {
                _context.CalendarEvents.Add(calendarEvent);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calendarEvent);
        }

        // GET: Debug/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarEvent calendarEvent = _context.CalendarEvents.Find(id);
            if (calendarEvent == null)
            {
                return HttpNotFound();
            }
            return View(calendarEvent);
        }

        // POST: Debug/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,title,start,end,duration,allDay")] CalendarEvent calendarEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(calendarEvent).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calendarEvent);
        }

        // GET: Debug/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarEvent calendarEvent = _context.CalendarEvents.Find(id);
            if (calendarEvent == null)
            {
                return HttpNotFound();
            }
            return View(calendarEvent);
        }

        // POST: Debug/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CalendarEvent calendarEvent = _context.CalendarEvents.Find(id);
            _context.CalendarEvents.Remove(calendarEvent);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
