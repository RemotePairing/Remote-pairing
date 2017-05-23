using CodeMate.WebApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeMate.WebApp.Models
{
    [Serializable]
    public class CalendarEvent : IEntity
    {
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string duration { get; set; }
        public bool AllDay { get; set; }
    }
}