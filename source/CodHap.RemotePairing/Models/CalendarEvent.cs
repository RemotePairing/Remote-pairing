namespace CodHap.RemotePairing.Models
{
    using System;
    using DataAccess;

    [Serializable]
    public class CalendarEvent : IEntity
    {
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string duration { get; set; }
        public bool allDay { get; set; }
        public string description => "This is an awesome project";
        public string tags => "C# | HTML | JS";
        public string location => "remote";
    }
}