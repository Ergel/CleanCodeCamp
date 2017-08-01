using System;

namespace CCC.EventSourcing.BenutzerAnmeldungService
{
    public abstract class Event
    {
        public abstract string HoleGetAggregateId();

        public DateTime TimeStamp { get; private set; }

        protected Event()
        {
            this.TimeStamp = DateTime.Now;
        }
    }
}