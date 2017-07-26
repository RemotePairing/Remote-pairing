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
        public bool AllDay { get; set; }
    }
}