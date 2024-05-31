using CSharpLeetCode.InterviewProblems;

namespace CSharpLeetCodeTests.InterviewProblems
{
    [TestClass()]
    public class AnalyseServerLogsTests
    {
        private readonly AnalyseServerLogs _solution = new();

        [TestMethod()]
        public void GetStaleServerCount_ShouldSatisfyCondition1()
        {
            // arrange
            var n = 3;

            var log_data = new List<List<int>>
            {
                new List<int> { 1, 4 },
                new List<int> { 1, 3 },
                new List<int> { 2, 6 },
                new List<int> { 1, 5 },
            };

            var query = new List<int> { 10, 11 };

            var x = 5;

            // act
            var res = _solution.GetStaleServerCount(n, log_data, query, x);

            // assert
            CollectionAssert.AreEqual(new List<int> { 1, 2 }, res);
        }

        [TestMethod()]
        public void GetStaleServerCount_ShouldSatisfyCondition2()
        {
            // arrange
            var n = 6;

            var log_data = new List<List<int>>
            {
                new List<int> { 3, 2 },
                new List<int> { 4, 3 },
                new List<int> { 2, 6 },
                new List<int> { 6, 3 },
            };

            var query = new List<int> { 3, 2, 6 };

            var x = 2;

            // act
            var res = _solution.GetStaleServerCount(n, log_data, query, x);

            // assert
            CollectionAssert.AreEqual(new List<int> { 3, 5, 5 }, res);
        }
    }
}