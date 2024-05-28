using CSharpLeetCode.InterviewProblems;

namespace CSharpLeetCodeTests.InterviewProblems
{
    [TestClass()]
    public class BadgeAccessTrackerFrequentEntriesSolutionTests
    {
        private readonly BadgeAccessTrackerFrequentEntriesSolution _solution = new();

        [TestMethod()]
        public void FindFrequentUsers_ShouldSatisfyExample1()
        {
            // arrange
            var testData = TestData.recordSet1;

            // act
            var result = _solution.FindFrequentUsers(testData);

            // assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod()]
        public void FindFrequentUsers_ShouldSatisfyExample2()
        {
            // arrange
            var testData = TestData.recordSet2;

            // act
            var result = _solution.FindFrequentUsers(testData);

            // assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Paul", result[0].Item1);
            CollectionAssert.AreEqual(new List<int> { 800, 805, 810 }, result[0].Item2);
        }

        [TestMethod()]
        public void FindFrequentUsers_ShouldSatisfyExample3()
        {
            // arrange
            var testData = TestData.recordSet3;

            // act
            var result = _solution.FindFrequentUsers(testData);

            // assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Paul", result[0].Item1);
            CollectionAssert.AreEqual(new List<int> { 800, 805, 810 }, result[0].Item2);
            Assert.AreEqual("Raj", result[1].Item1);
            CollectionAssert.AreEqual(new List<int> { 1200, 1205, 1210 }, result[1].Item2);
        }

        private static class TestData
        {
            public static readonly List<ValueTuple<string, int>> recordSet1 = new()
            {
                ("Paul", 800)
            };

            public static readonly List<ValueTuple<string, int>> recordSet2 = new()
            {
                ("Paul", 800), ("Paul", 805), ("Paul", 810),
                ("Raj", 900)
            };

            public static readonly List<ValueTuple<string, int>> recordSet3 = new()
            {
                ("Paul", 800), ("Paul", 805), ("Paul", 810),
                ("Raj", 900), ("Raj", 1200), ("Raj", 1205), ("Raj", 1210)
            };

        }
    }
}