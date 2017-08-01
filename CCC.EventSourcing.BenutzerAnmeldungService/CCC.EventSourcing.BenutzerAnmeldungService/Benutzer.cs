using System.Collections.Generic;
using System.Linq;

namespace CCC.EventSourcing.BenutzerAnmeldungService
{
    //todo    Klarmachen, dass es hier nicht um ein Aggregat geht, sondern um ein ReadModel
    public class Benutzer
    {
        public Benutzer()
        {
        }

        public string Benutzername { get; internal set; }
        public string Passwort { get; internal set; }
        public string Vorname { get; internal set; }
        public string Nachname { get; internal set; }

        public void Apply(BenutzerRegistriert myEvent)
        {
            this.Vorname = myEvent.Vorname;
            this.Nachname = myEvent.Nachname;
            this.Benutzername = myEvent.Benutzername;
            this.Passwort = myEvent.Passwort;
        }

        //todo: Replay anstatt Apply   
        public void Apply(PasswortGeandert myEvent)
        {
            this.Passwort = myEvent.NeuesPasswort;
        }

        public void AktuellenZustandHolen()
        {
            ////var eventBenutzerRegistriert = alleEvents.OfType<BenutzerRegistriert>().SingleOrDefault();

            ////Benutzername = eventBenutzerRegistriert.Benutzername;
            ////Passwort = alleEvents.OfType<PasswortGeandert>().Last().NeuesPasswort;
            ////Vorname = eventBenutzerRegistriert.Vorname;
            ////Nachname = eventBenutzerRegistriert.Nachname;
        }

        public void ApplyEvents(IReadOnlyCollection<Event> alleEvents)
        {
            var eventBenutzerRegistriert = alleEvents.OfType<BenutzerRegistriert>().SingleOrDefault();

            Benutzername = eventBenutzerRegistriert.Benutzername;
            Passwort = alleEvents.OfType<PasswortGeandert>().Last().NeuesPasswort;
            Vorname = eventBenutzerRegistriert.Vorname;
            Nachname = eventBenutzerRegistriert.Nachname;
        }
    }
}