Event-Sourcing-Katas

Code Katas um das Konzept von Event Sourcing und CQRS zu verstehen, �ben und vertiefen.

�bung A
Implementiere bitte die folgende Schnittstelle so, dass die �nderungen als Ereignis aufgebildet und aufgezeichnet werden.

public interface IBenutzerAnmeldungService
{
	void BenutzerRegistrieren(string benutzername, string vorname, string nachname, string passwort);
	bool DarfBenutzerAnmelden(string benutzername, string passwort);
}

In welcher Form und wo diese Ereignisse gespeichert werden sollen, kannst du selber entscheiden.

Diese sind zu beachten: Es darf keine relationale Datenbank als Speichermedium genutzt werden. Die Ereignisse werden in Vergangenheit formuliert. Plausibilit�tspr�fungen d�rfen ignoriert werden. Ausnahmsweise d�rfen die Passw�rter als Plaintext gespeichert und geschickt werden. Unit-Tests m�ssen geschrieben werden. Du kannst dir selber entscheiden, ob Test-first oder Test-nach.
Ziel der �bung A: Eine andere Sichtweise beim Entwickeln einer L�sung einnehmen.

�bung B:
Erweitere bitte die Schnittstelle, damit der Benutzer sein Passwort �ndern kann.

public interface IBenutzerAnmeldungService
{
	void BenutzerRegistrieren(string benutzername, string vorname, string nachname, string passwort);
	bool DarfBenutzerAnmelden(string benutzername, string passwort);
	void PasswortAendern(string benutzername, string altesPasswort, string neuesPasswort);
}

Diese sind zu beachten: Das neue Passwort darf nicht weniger als 6 Zeichen beinhalten. Unit-Tests m�ssen geschrieben werden. Du kannst dir selber entscheiden, ob Test-first oder Test-nach.
Ziel der �bung B: Events filtern, die �ber gleiche DomainObjekte bzw. Aggregaten operieren. Das Aggregate-Konzept verstehen. Ein Gef�hl f�r Platzieren von Business Regeln bekommen.

�bung C:
Implementiere eine andere Komponente, die Mails an Administrator schickt wenn ein neuer Benutzer registriert wurde.

�bung D:
NEventStore als Speichermedium f�r die Ereignisse einsetzen. Zielverst�ndnis: Der Einsatz eines Event Stores bietet den Vorteil, dass alle �nderungen am System jederzeit durch eine Wiederholung der Events deterministisch nachgestellt werden k�nnen.
�bung E:

Entwirf deine Schnittstelle erneut, dass du die Funktionen, die Zustand �ndern und die Funktionen, die nur Daten abfragen, von einander trennst.
