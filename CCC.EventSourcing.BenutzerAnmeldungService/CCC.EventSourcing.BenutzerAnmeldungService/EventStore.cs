using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CCC.EventSourcing.BenutzerAnmeldungService
{
    public class EventStore : IEventStore
    {
        private readonly IList<Event> events = new List<Event>();

        public void Append(Event myEvent)
        {
            events.Add(myEvent);
        }

        //todo Benamung fetch??
        public IReadOnlyCollection<T> HoleEvents<T>(string aggregateId) where T : Event
        {
            //todo: Wegen Aggregate, wird Probleme machen, Wie ist das Konzept??
            var filteredEvents = events.Where(itm => itm.HoleGetAggregateId() == aggregateId)
                .OfType<T>()
                .OrderBy(itm => itm.TimeStamp).ToList();

            return new ReadOnlyCollection<T>(filteredEvents.ToList());
        }

        public IReadOnlyCollection<Event> HoleEvents(string aggregateId)
        {
            var passendeEvents = events.Where(x => x.HoleGetAggregateId().CompareTo(aggregateId) == 0);
            return new ReadOnlyCollection<Event>(passendeEvents.ToList());
        }

        //todo: Holeaggregat ist falsch. Man holt hier eine Transformation bzw. macht eine Abfrage
        public Benutzer HoleBenutzer(string aggregateId)
        {
            Benutzer aggregat = null;
            var events = HoleEvents(aggregateId);

            foreach (var myEvent in events)
            {
                if (myEvent.GetType() == typeof(BenutzerRegistriert))
                {


                    ////{
                    ////aggregat = new Benutzer
                    ////{
                    ////    Vorname = ((BenutzerRegistriert)myEvent).Vorname,
                    ////    Nachname = ((BenutzerRegistriert)myEvent).Nachname,
                    ////    Benutzername = ((BenutzerRegistriert)myEvent).Benutzername,
                    ////    Passwort = ((BenutzerRegistriert)myEvent).Passwort
                    ////};
                }
                else if (myEvent.GetType() == typeof(PasswortGeandert))
                {
                    ////aggregat.Passwort = ((PasswortGeandert)myEvent).NeuesPasswort;
                    aggregat.Apply((PasswortGeandert)myEvent);
                }
            }

            return aggregat;
        }

        public Benutzer HoleAggregat(string aggregateId)
        {
            //TODO: default-Konstruktion
            Benutzer aggregat = null;

            var events = HoleEvents(aggregateId);

            foreach (var myEvent in events)
            {
                if (myEvent.GetType() == typeof(BenutzerRegistriert))
                {


                    ////{
                    ////aggregat = new Benutzer
                    ////{
                    ////    Vorname = ((BenutzerRegistriert)myEvent).Vorname,
                    ////    Nachname = ((BenutzerRegistriert)myEvent).Nachname,
                    ////    Benutzername = ((BenutzerRegistriert)myEvent).Benutzername,
                    ////    Passwort = ((BenutzerRegistriert)myEvent).Passwort
                    ////};
                }
                else if (myEvent.GetType() == typeof(PasswortGeandert))
                {
                    ////aggregat.Passwort = ((PasswortGeandert)myEvent).NeuesPasswort;
                    aggregat.Apply((PasswortGeandert)myEvent);
                }
            }

            return aggregat;
        }
    }
}