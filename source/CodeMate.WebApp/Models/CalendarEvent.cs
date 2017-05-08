using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeMate.WebApp.Models
{
    public class CalendarEvent
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Url { get; set; }
        public bool AllDay { get; set; }
    }
}