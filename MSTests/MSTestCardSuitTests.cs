using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayingCards;

namespace PlayingCardsTests
{
    [TestClass]
    public class MSTestCardSuitTests
    {
        private TestContext suitContextInstance;
        public TestContext TestContext
        {
            get => suitContextInstance;
            set => suitContextInstance = value;
        }
        [TestMethod]
        public void TestCardSuitConstructorWithClubs()
        {
            var cardSuit = new CardSuit(CardSuit.SuitNames.Clubs);

            Assert.AreEqual(CardSuit.SuitNames.Clubs, cardSuit.Suit);
        }

        [TestMethod]
        public void TestCardSuitConstructorWithDiamonds()
        {
            var cardSuit = new CardSuit(CardSuit.SuitNames.Diamonds);

            Assert.AreEqual(CardSuit.SuitNames.Diamonds, cardSuit.Suit);
        }

        [TestMethod]
        public void TestCardSuitConstructorWithHearts()
        {
            var cardSuit = new CardSuit(CardSuit.SuitNames.Hearts);

            Assert.AreEqual(CardSuit.SuitNames.Hearts, cardSuit.Suit);
        }

        [TestMethod]
        public void TestCardSuitConstructorWithSpades()
        {
            var cardSuit = new CardSuit(CardSuit.SuitNames.Spades);

            Assert.AreEqual(CardSuit.SuitNames.Spades, cardSuit.Suit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCardSuitConstructorWithInvalidSuit()
        {
            var cardSuit = new CardSuit((CardSuit.SuitNames)(-1));
        }

        [TestMethod]
        public void TestToStringClubs()
        {
            var cardSuit = new CardSuit(CardSuit.SuitNames.Clubs);

            Assert.AreEqual("♣", cardSuit.ToString());
        }

        [TestMethod]
        public void TestToStringDiamonds()
        {
            var cardSuit = new CardSuit(CardSuit.SuitNames.Diamonds);

            Assert.AreEqual("♦", cardSuit.ToString());
        }

        [TestMethod]
        public void TestToStringHearts()
        {
            var cardSuit = new CardSuit(CardSuit.SuitNames.Hearts);

            Assert.AreEqual("♥", cardSuit.ToString());
        }

        [TestMethod]
        public void TestToStringSpades()
        {
            var cardSuit = new CardSuit(CardSuit.SuitNames.Spades);

            Assert.AreEqual("♠", cardSuit.ToString());
        }

        [TestMethod]
        [DeploymentItem("CardSuitToStringTestData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "CardSuitToStringTestData.xml",
            "Row",
            DataAccessMethod.Sequential) ]
        public void ToStringTest()
        {
            CardSuit.SuitNames suit = (CardSuit.SuitNames)Enum.Parse(typeof(CardSuit.SuitNames),
                (string)TestContext.DataRow["Suit"]);
            string result = (string)TestContext.DataRow["Result"];

            var cardSuit = new CardSuit(suit);
            Assert.AreEqual(result, cardSuit.ToString());
        }
        
        [DataTestMethod]
        [DataRow(CardSuit.SuitNames.Clubs, "♣")]
        [DataRow(CardSuit.SuitNames.Diamonds, "♦")]
        public void DataDrivenToStringTest(CardSuit.SuitNames suit, String result)
        {
            var cardSuit = new CardSuit(suit);
            Assert.AreEqual(result, cardSuit.ToString());
        }
    }
}