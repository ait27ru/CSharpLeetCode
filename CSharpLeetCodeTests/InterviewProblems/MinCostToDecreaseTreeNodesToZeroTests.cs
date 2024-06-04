using CSharpLeetCode.InterviewProblems;

namespace CSharpLeetCodeTests.InterviewProblems
{
    [TestClass()]
    public class MinCostToDecreaseTreeNodesToZeroTests
    {
        private readonly MinCostToDecreaseTreeNodesToZero _solution = new();

        [TestMethod()]
        public void GetMinCost_TestCase1()
        {
            // arrange
            var val = new List<int> { 3, 1, 2 };
            var nodes = 3;
            var tFrom = new List<int> { 1, 1 };
            var tTo = new List<int> { 2, 3 };

            // act
            var res = _solution.GetMinCost(val, nodes, tFrom, tTo);

            // assert
            Assert.AreEqual(1, res);
        }

        [TestMethod()]
        public void GetMinCost_TestCase2()
        {
            // arrange
            var val = new List<int> { 3, 2, 4, 2, 5 };
            var nodes = 5;
            var tFrom = new List<int> { 1, 1, 3, 3 };
            var tTo = new List<int> { 2, 3, 4, 5 };

            // act
            var res = _solution.GetMinCost(val, nodes, tFrom, tTo);

            // assert
            Assert.AreEqual(2, res);
        }

        [TestMethod()]
        public void GetMinCost_TestCase3()
        {
            // arrange
            var val = new List<int> { 3, 2, 5, 2, 4 };
            var nodes = 5;
            var tFrom = new List<int> { 1, 1, 3, 5 };
            var tTo = new List<int> { 2, 3, 4, 5 };

            // act
            var res = _solution.GetMinCost(val, nodes, tFrom, tTo);

            // assert
            Assert.AreEqual(1, res);
        }

        [TestMethod()]
        public void GetMinCost_TestCase4()
        {
            // arrange
            var val = new List<int> { 3, 5, 4, 7, 2, 9 };
            var nodes = 6;
            var tFrom = new List<int> { 1, 1, 2, 2, 3 };
            var tTo = new List<int> { 2, 3, 4, 5, 6 };

            // act
            var res = _solution.GetMinCost(val, nodes, tFrom, tTo);

            // assert
            Assert.AreEqual(3, res);
        }
    }
}