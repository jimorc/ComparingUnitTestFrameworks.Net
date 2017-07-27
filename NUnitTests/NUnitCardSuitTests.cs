using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using PlayingCards;

namespace NUnitTests
{
    [TestFixture]
    public class NUnitCardSuitTests
    {
        [Test]
        public void TestCardSuitConstructorWithInvalidSuit()
        {
            ActualValueDelegate<object> testDelegate = () => new CardSuit((CardSuit.SuitNames)(-1));
            Assert.That(testDelegate, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void TestCardSuitConstructorWithInvalidSuit2()
        {
            var exception = Assert.Throws< ArgumentOutOfRangeException>(() 
                => new CardSuit((CardSuit.SuitNames)(-1)));
            bool invalidSuit = exception.Message.Contains("The suit value is not valid.");
            Assert.That(invalidSuit);
        }


        [Test]
        public void TestToStringClubs()
        {
            var cardSuit = new CardSuit(CardSuit.SuitNames.Clubs);
            var clubs = cardSuit.ToString();
            Assert.That(clubs, Is.EqualTo("♣"));
        }

        [Test]
        public void TestToStringDiamonds()
        {
            var cardSuit = new CardSuit(CardSuit.SuitNames.Diamonds);
            var diamonds = cardSuit.ToString();
            Assert.That(diamonds, Is.EqualTo("♦"));
        }

        [TestCase(CardSuit.SuitNames.Clubs, "♣")]
        [TestCase(CardSuit.SuitNames.Diamonds, "♦")]
        public void ToStringTestCaseTest(CardSuit.SuitNames suit, string result)
        {
            var cardSuit = new CardSuit(suit);
            var suitString = cardSuit.ToString();
            Assert.AreEqual(result, suitString);
        }

        [TestCaseSource("ToStringCases")]
        public void ToStringTestCaseSourceTest(CardSuit.SuitNames suit,
            string result)
        {
            var cardSuit = new CardSuit(suit);
            var suitString = cardSuit.ToString();
            Assert.AreEqual(result, suitString);
        }

        static object[] ToStringCases =
        {
            new object[] { CardSuit.SuitNames.Clubs, "♣" },
            new object[] { CardSuit.SuitNames.Diamonds, "♦" }
        };
    }
}
