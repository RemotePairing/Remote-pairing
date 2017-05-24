using CodeMate.WebApp.DataAccess;
using CodeMate.WebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace CodeMate.WebApp.Repositories
{
    using System.Data.Entity.Migrations;
    using DAL;

    public class CalendarEventRepository : IRepository<CalendarEvent>
    {
        private readonly string path = @"C:\temp\db.txt";
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
        }

        public CalendarEvent FindById(string Id)
        {
            return List.First(x => x.Id == Id);
        }

        public void Update(CalendarEvent entity)
        {
            _calendarDbContext.CalendarEvents.AddOrUpdate(entity);
        }        
    }
}