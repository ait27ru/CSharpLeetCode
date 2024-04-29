using CSharpLeetCode.MediumProblems;

namespace CSharpLeetCodeTests.MediumProblems
{
    [TestClass()]
    public class PerfectSquaresSolutionTests
    {
        private readonly PerfectSquaresSolution _solution = new();

        [TestMethod()]
        public void NumSquares_ShouldSatisfy_MinValueEdgeCase()
        {
            var num = _solution.NumSquares(1);
            // 1 = 1 (1x1)
            Assert.AreEqual(1, num);
        }

        [TestMethod()]
        public void NumSquares_ShouldSatisfy_MaxValueEdgeCase()
        {
            var num = _solution.NumSquares(10_000);
            // 10000 = 10000 (100x100)
            Assert.AreEqual(1, num);
        }

        [TestMethod()]
        public void NumSquares_ShouldSatisfy_Example1()
        {
            var num = _solution.NumSquares(12);
            // 12 = 4 + 4 + 4
            Assert.AreEqual(3, num);
        }

        [TestMethod()]
        public void NumSquares_ShouldSatisfy_Example2()
        {
            var num = _solution.NumSquares(13);
            // 13 = 4 + 9
            Assert.AreEqual(2, num);
        }

        [TestMethod()]
        public void NumSquares_ShouldSatisfy_Example3()
        {
            var num = _solution.NumSquares(5);
            // 5 = 4 + 1
            Assert.AreEqual(2, num);
        }
    }
}