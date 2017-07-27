using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using PlayingCards;

namespace xUnitTests
{

    public class xUnitCardSuitTests
    {
        [Fact]
        public void TestCardSuitConstructorWithInvalidSuit()
        {
            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() 
                => new CardSuit((CardSuit.SuitNames)(-1)));

            bool invalidSuit = ex.Message.Contains("The suit value is not valid.");

            Assert.True(invalidSuit);
        }

        [Fact]
        public void TestToStringClubs()
        {
            var cardSuit = new CardSuit(CardSuit.SuitNames.Clubs);
        
            Assert.Equal("♣", cardSuit.ToString());
        }

        [Fact]
        public void TestToStringDiamonds()
        {
            var cardSuit = new CardSuit(CardSuit.SuitNames.Diamonds);

            Assert.Equal("♦", cardSuit.ToString());
        }

        [Theory]
        [InlineData(CardSuit.SuitNames.Clubs, "♣")]
        [InlineData(CardSuit.SuitNames.Diamonds, "♦")]
        public void ToStringTestCaseTest(CardSuit.SuitNames suit, string result)
        {
            var cardSuit = new CardSuit(suit);
            var suitString = cardSuit.ToString();
            Assert.Equal(result, suitString);
        }

        [Theory]
        [MemberData("ToStringData", MemberType = typeof(ToStringCasesDataSource))]
        public void ToStringTestCaseSourceTest(CardSuit.SuitNames suit,
            string result)
        {
            var cardSuit = new CardSuit(suit);
            var suitString = cardSuit.ToString();
            Assert.Equal(result, suitString);
        }

        public static class ToStringCasesDataSource
        {
            private static readonly List<object[]> toStringCases =
                new List<object[]>
                { 
                    new object[] { CardSuit.SuitNames.Clubs, "♣" },
                    new object[] { CardSuit.SuitNames.Diamonds, "♦" }
                };

            public static IEnumerable<object[]> ToStringData
            {
                get => toStringCases;
            }
        }
    }
}
