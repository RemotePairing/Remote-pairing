namespace CodeMate.WebApp.Repositories
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DataAccess;
    using DAL;
    using Models;

    public class CalendarEventRepository : IRepository<CalendarEvent>
    {
        private readonly CalendarDbContext _calendarDbContext;

        public CalendarEventRepository()
        {
            _calendarDbContext = new CalendarDbContext();
        }

        public IEnumerable<CalendarEvent> List => _calendarDbContext.CalendarEvents.AsEnumerable();

        public void Add(CalendarEvent entity)
        {
            _calendarDbContext.CalendarEvents.Add(entity);
            _calendarDbContext.SaveChanges();
        }

        public void Delete(CalendarEvent entity)
        {
            var eventToDelete = FindById(entity.Id);
            _calendarDbContext.CalendarEvents.Remove(eventToDelete);
            _calendarDbContext.SaveChanges();
        }

        public CalendarEvent FindById(string Id)
        {
            return List.First(x => x.Id == Id);
        }

        public void Update(CalendarEvent entity)
        {
            _calendarDbContext.CalendarEvents.AddOrUpdate(entity);
            _calendarDbContext.SaveChanges();
        }
    }
}