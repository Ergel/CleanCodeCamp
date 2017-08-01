using CCC.EventSourcing.BenutzerAnmeldungService;
using NUnit.Framework;

namespace CCC.EventSourcing.Test.BenutzerAnmeldungService
{
    [TestFixture]
    public class BenutzerAnmeldungServiceTest
    {
        [Test]
        public void TesteBenutzerRegistrieren()
        {
            var benutzerDienst = new EventSourcing.BenutzerAnmeldungService.BenutzerAnmeldungService(new EventStore());
            benutzerDienst.BenutzerRegistrieren("merkel", "angela", "merkel", "hochgeheim");

            Assert.That(benutzerDienst.DarfBenutzerAnmelden("merkel", "hochgeheim"), Is.True);
        }

        [Test]
        public void TesteRegistrierteBenutzerDarfAnmelden()
        {
            var benutzerDienst = new EventSourcing.BenutzerAnmeldungService.BenutzerAnmeldungService(new EventStore());
            benutzerDienst.BenutzerRegistrieren("merkel", "angela", "merkel", "hochgeheim");

            Assert.That(benutzerDienst.DarfBenutzerAnmelden("merkel", "hochgeheim"), Is.True);
        }

        [Test]
        public void TesteNichtRegistrierteBenutzerDarfNichtAnmelden()
        {
            var benutzerDienst = new EventSourcing.BenutzerAnmeldungService.BenutzerAnmeldungService(new EventStore());
            Assert.That(benutzerDienst.DarfBenutzerAnmelden("nicht registrierte Benutzer", "kennwort"), Is.False);
        }

        [Test]
        public void TesteRegistrierteBenutzerDarfMitFalschemPasswortNichtAnmelden()
        {
            var benutzerDienst = new EventSourcing.BenutzerAnmeldungService.BenutzerAnmeldungService(new EventStore());
            benutzerDienst.BenutzerRegistrieren("merkel", "angela", "merkel", "hochgeheim"); Assert.That(benutzerDienst.DarfBenutzerAnmelden("nicht registrierte Benutzer", "kennwort"), Is.False);

            Assert.That(benutzerDienst.DarfBenutzerAnmelden("merkel", "falschespasswort"), Is.False);
        }

        [Test]
        public void TesteBenutzerDarfAnmeldenNachPasswortAendern()
        {
            var benutzerDienst = new EventSourcing.BenutzerAnmeldungService.BenutzerAnmeldungService(new EventStore());
            benutzerDienst.BenutzerRegistrieren("merkel", "angela", "merkel", "hochgeheim");

            Assert.That(benutzerDienst.DarfBenutzerAnmelden("merkel", "hochgeheim"), Is.True);

            var neuesPasswort = "harbers123";
            benutzerDienst.PasswortAendern("merkel", "hochgeheim", neuesPasswort);
            Assert.That(benutzerDienst.DarfBenutzerAnmelden("merkel", neuesPasswort), Is.True);
        }

        [Test]
        public void TestePasswortAendernMitUngueltigemAktuellenPasswort()
        {
            var benutzerDienst = new EventSourcing.BenutzerAnmeldungService.BenutzerAnmeldungService(new EventStore());
            benutzerDienst.BenutzerRegistrieren("merkel", "angela", "merkel", "hochgeheim");

            Assert.That(benutzerDienst.DarfBenutzerAnmelden("merkel", "hochgeheim"), Is.True);

            var neuesPasswort = "harbers123";
            benutzerDienst.PasswortAendern("merkel", "hochgeheimnichtrichtig", neuesPasswort);
            Assert.That(benutzerDienst.DarfBenutzerAnmelden("merkel", neuesPasswort), Is.False);

            Assert.That(benutzerDienst.DarfBenutzerAnmelden("merkel", "hochgeheim"), Is.True);
        }

        [Test]
        public void TestePasswortAendernMitUngueltigemNeuenPasswort()
        {
            var benutzerDienst = new EventSourcing.BenutzerAnmeldungService.BenutzerAnmeldungService(new EventStore());
            benutzerDienst.BenutzerRegistrieren("merkel", "angela", "merkel", "hochgeheim");

            Assert.That(benutzerDienst.DarfBenutzerAnmelden("merkel", "hochgeheim"), Is.True);

            var neuesPasswort = "123";
            benutzerDienst.PasswortAendern("merkel", "hochgeheim", neuesPasswort);
            Assert.That(benutzerDienst.DarfBenutzerAnmelden("merkel", neuesPasswort), Is.False);

            Assert.That(benutzerDienst.DarfBenutzerAnmelden("merkel", "hochgeheim"), Is.True);
        }
    }
}
