namespace CCC.EventSourcing.BenutzerAnmeldungService
{
    public class BenutzerRegistriert : Event
    {
        public string Benutzername { get; set; }
        public string Passwort { get; }
        public string Vorname { get; }
        public string Nachname { get; }

        public BenutzerRegistriert(string benutzername, string passwort, string vorname, string nachname)
        {
            Benutzername = benutzername;
            Passwort = passwort;
            Vorname = vorname;
            Nachname = nachname;
        }

        public override string HoleGetAggregateId()
        {
            return this.Benutzername;
        }
    }
}