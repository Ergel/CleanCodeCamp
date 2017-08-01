namespace CCC.EventSourcing.BenutzerAnmeldungService
{
    public interface IBenutzerAnmeldungService
    {
        void BenutzerRegistrieren(string benutzername, string vorname, string nachname, string passwort);
        bool DarfBenutzerAnmelden(string benutzername, string passwort);
        void PasswortAendern(string benutzername, string altesPasswort, string neuesPasswort);
    }
}