using CSharpLeetCode.MediumProblems;

namespace CSharpLeetCodeTests.MediumProblems
{
    [TestClass()]
    public class CoinChangeSolutionTests
    {
        private readonly CoinChangeSolution _solution = new();

        [TestMethod()]
        public void CoinChangeSolution_ShouldSatisfy_Example1()
        {
            // arrange
            int[] coins = [1, 2, 5];
            int amount = 11;

            // act
            var coinsNumber = _solution.CoinChange(coins, amount);

            // assert
            Assert.AreEqual(3, coinsNumber);
        }

        [TestMethod()]
        public void CoinChangeSolution_ShouldSatisfy_Example2()
        {
            // arrange
            int[] coins = [2];
            int amount = 3;

            // act
            var coinsNumber = _solution.CoinChange(coins, amount);

            // assert
            Assert.AreEqual(-1, coinsNumber);
        }

        [TestMethod()]
        public void CoinChangeSolution_ShouldSatisfy_Example3()
        {
            // arrange
            int[] coins = [1];
            int amount = 0;

            // act
            var coinsNumber = _solution.CoinChange(coins, amount);

            // assert
            Assert.AreEqual(0, coinsNumber);
        }
    }
}