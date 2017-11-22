using System;
using System.Linq;
using CodeKata.FizzBuzz;
using NUnit.Framework;

namespace CodeKata.Test.FizzBuzz
{
    [TestFixture]
    public class Class1Test
    {
        [Test]
        [TestCase(1, "1")]
        [TestCase(3, "Fizz")]
        [TestCase(13, "Fizz")]
        [TestCase(31, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        [TestCase(52, "Buzz")]
        public void TestFizzBuzzStringHolen(int input, string output)
        {
            var uebersetzteString = Class1.FizzBuzzStringHolen(input);
            Assert.That(uebersetzteString, Is.EqualTo(output));
        }

        [Test]
        public void TesteAusgabe1Bis100()
        {
            var uebersetzteString = Class1.Ausgabe1Bis100();
            Assert.That(uebersetzteString.StartsWith("1 2 Fizz 4 Buzz Fizz 7"), Is.True);

            var anzahlDerLeerzeichen = uebersetzteString.Count(chr => chr == ' ');
            Assert.That(anzahlDerLeerzeichen, Is.EqualTo(99));

            Console.Out.Write(uebersetzteString);
        }
    }
}
