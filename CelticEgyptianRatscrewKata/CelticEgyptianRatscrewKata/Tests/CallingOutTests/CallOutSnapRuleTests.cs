using System.Collections.Generic;
using CelticEgyptianRatscrewKata.CallingOut;
using NSubstitute;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests.CallingOutTests
{
    public class CallOutSnapRuleTests
    {
        private const Rank c_TopCardRank = Rank.Ace;
        private const Rank c_OtherCardRank = Rank.Eight;

        private readonly Cards m_SingleCardStack = new Cards(new[]
        {
            new Card(Suit.Clubs, c_TopCardRank)
        });

        private readonly Cards m_TwoCardStack = new Cards(new[]
        {
            new Card(Suit.Clubs, c_TopCardRank),
            new Card(Suit.Clubs, c_OtherCardRank),
        });

        [Test]
        public void SnapNotValidOnEmptyStack()
        {
            var mockCalledRankProvider = CreateMockCalledRankProvider(c_TopCardRank);

            var isSnapValid = ValidateSnap(mockCalledRankProvider, Cards.Empty());

            Assert.That(isSnapValid, Is.False);
        }

        [Test]
        public void SnapValidWhenSingleCardMatchesCalledRank()
        {
            var mockCalledRankProvider = CreateMockCalledRankProvider(c_TopCardRank);

            var isSnapValid = ValidateSnap(mockCalledRankProvider, m_SingleCardStack);

            Assert.That(isSnapValid, Is.True);
        }

        [Test]
        public void SnapNotValidWhenSingleCardDoesNotMatchCalledRank()
        {
            var mockCalledRankProvider = CreateMockCalledRankProvider(c_OtherCardRank);

            var isSnapValid = ValidateSnap(mockCalledRankProvider, m_SingleCardStack);

            Assert.That(isSnapValid, Is.False);
        }

        [Test]
        public void SnapValidWhenFirstCardOfMultipleCardsMatchesCalledRank()
        {
            var mockCalledRankProvider = CreateMockCalledRankProvider(c_TopCardRank);

            var isSnapValid = ValidateSnap(mockCalledRankProvider, m_TwoCardStack);

            Assert.That(isSnapValid, Is.True);
        }

        [Test]
        public void SnapNotValidWhenSecondCardOfMultipleCardsMatchesCalledRank()
        {
            var mockCalledRankProvider = CreateMockCalledRankProvider(c_OtherCardRank);

            var isSnapValid = ValidateSnap(mockCalledRankProvider, m_TwoCardStack);

            Assert.That(isSnapValid, Is.False);
        }

        private static ICalledRankProvider CreateMockCalledRankProvider(Rank calledRank)
        {
            var mockCalledRankProvider = Substitute.For<ICalledRankProvider>();
            mockCalledRankProvider.GetCurrentRank().Returns(calledRank);
            return mockCalledRankProvider;
        }

        private static bool ValidateSnap(ICalledRankProvider mockCalledRankProvider, Cards cardStack)
        {
            var rule = new CallOutSnapRule(mockCalledRankProvider);
            return rule.IsSnapValid(cardStack);
        }
    }
}
