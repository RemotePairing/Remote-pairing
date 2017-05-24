using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeMate.WebApp.DAL
{
    using Models;

    public class CalendarContextInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CalendarDbContext>
    {
        protected override void Seed(CalendarDbContext context)
        {
            var calendarEvent = new CalendarEvent()
            {
                title = "Event initialized from DB",
                Id = "1",
                start = DateTime.UtcNow.ToString(),
                end = DateTime.UtcNow.AddMinutes(45).ToString()
            };

            context.CalendarEvents.Add(calendarEvent);
            context.SaveChanges();
        }
    }
}