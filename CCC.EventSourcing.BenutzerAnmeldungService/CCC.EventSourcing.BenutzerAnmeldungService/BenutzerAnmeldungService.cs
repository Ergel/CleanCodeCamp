﻿namespace CCC.EventSourcing.BenutzerAnmeldungService
{
    public class BenutzerAnmeldungService : IBenutzerAnmeldungService
    {
        public IEventStore EventStore { get; }

        public void BenutzerRegistrieren(string benutzername, string vorname, string nachname, string passwort)
        {
            var eventBenutzerRegistriert = new BenutzerRegistriert(benutzername, passwort, vorname, nachname);
            this.EventStore.Append(eventBenutzerRegistriert);
        }

        public bool DarfBenutzerAnmelden(string benutzername, string passwort)
        {
            //var benutzerRegistriertEvent =
            //    EventStore.HoleEvents<BenutzerRegistriert>(benutzername).FirstOrDefault();

            //if (benutzerRegistriertEvent == null)
            //{
            //    return false;
            //}

            //var letztePasswortGeandertEvent = EventStore.HoleEvents<PasswortGeandert>(benutzername).LastOrDefault();

            //var aktuellesPasswort = benutzerRegistriertEvent.Passwort;
            //if (letztePasswortGeandertEvent != null)
            //{
            //    aktuellesPasswort = letztePasswortGeandertEvent.NeuesPasswort;
            //}

            //TODO:benutzer instanzieren, damit wir das passwort auslesen können -> EventStore.HoleAggregat
            Benutzer benutzer = this.EventStore.HoleAggregat(benutzername);
            if (benutzer == null)
            {
                return false;
            }

            return benutzer.Passwort == passwort;
        }

        public object HoleAktuellenZustand(string aggregateId)
        {
            var alleEvents = EventStore.HoleEvents(aggregateId);

            var benutzer = new Benutzer();
            benutzer.ApplyEvents(alleEvents);

            return benutzer;
        }

        public void PasswortAendern(string benutzername, string altesPasswort, string neuesPasswort)
        {
            //TODO: Was soll mit dem Geschehen passieren?
            if (DarfBenutzerAnmelden(benutzername, altesPasswort) == false)
            {
                return;
            }

            if (neuesPasswort.Length < 6)
            {
                return;
            }

            var passwortGeandertEvent = new PasswortGeandert(benutzername, neuesPasswort);
            this.EventStore.Append(passwortGeandertEvent);
        }

        public BenutzerAnmeldungService(IEventStore eventStore)
        {
            this.EventStore = eventStore;
        }
    }

    public class PasswortGeandert : Event
    {
        public string Benutzername { get; }
        public string NeuesPasswort { get; }

        public PasswortGeandert(string benutzername, string neuesPasswort)
        {
            Benutzername = benutzername;
            NeuesPasswort = neuesPasswort;
        }

        public override string HoleGetAggregateId()
        {
            return this.Benutzername;
        }
    }
}