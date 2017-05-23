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
    public class CalendarEventRepository : IRepository<CalendarEvent>
    {
        private readonly string path = @"C:\temp\db.txt";
        private IList<CalendarEvent> eventList;

        public CalendarEventRepository()
        {
            Deserialize();
        }

        public IEnumerable<CalendarEvent> List
        {
            get
            {
                Deserialize();
                return eventList;
            }
        }

        public void Add(CalendarEvent entity)
        {
            eventList.Add(entity);
            Serialize(eventList);
        }

        public void Delete(CalendarEvent entity)
        {
            Deserialize();
            var eventToDelete = FindById(entity.Id);
            eventList.Remove(eventToDelete);
        }

        public CalendarEvent FindById(string Id)
        {
            Deserialize();
            return eventList.First(x => x.Id == Id);
        }

        public void Update(CalendarEvent entity)
        {
            CalendarEvent eventToUpdate = FindById(entity.Id);
            eventToUpdate = entity;
            Serialize(eventList);
        }

        private void Deserialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path,
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
            eventList = (List<CalendarEvent>)formatter.Deserialize(stream);
            stream.Close();
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


    }
}