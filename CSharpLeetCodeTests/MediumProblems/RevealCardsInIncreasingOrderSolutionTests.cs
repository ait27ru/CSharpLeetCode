using CSharpLeetCode.MediumProblems;

namespace CSharpLeetCodeTests.MediumProblems
{
    [TestClass()]
    public class RevealCardsInIncreasingOrderSolutionTests
    {
        private readonly RevealCardsInIncreasingOrderSolution _solution = new();

        [TestMethod()]
        public void DeckRevealedInIncreasingOrder_ShouldSatisfy_Example1()
        {
            // arrange
            var deck = new int[] { 17, 13, 11, 2, 3, 5, 7 };

            // act
            var newDeck = _solution.DeckRevealedInIncreasingOrder(deck);

            // assert
            CollectionAssert.AreEqual(new int[] { 2, 13, 3, 11, 5, 17, 7 }, newDeck);
        }

        [TestMethod()]
        public void DeckRevealedInIncreasingOrder_ShouldSatisfy_Example2()
        {
            // arrange
            var deck = new int[] { 1, 1000 };

            // act
            var newDeck = _solution.DeckRevealedInIncreasingOrder(deck);

            // assert
            CollectionAssert.AreEqual(new int[] { 1, 1000 }, newDeck);
        }
    }
}