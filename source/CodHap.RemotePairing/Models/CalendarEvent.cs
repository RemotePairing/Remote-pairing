namespace CodHap.RemotePairing.Models
{
    using System;
    using DataAccess;

    [Serializable]
    public class CalendarEvent : IEntity
    {
        public string Title { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Duration { get; set; }
        public bool AllDay { get; set; }
    }
}