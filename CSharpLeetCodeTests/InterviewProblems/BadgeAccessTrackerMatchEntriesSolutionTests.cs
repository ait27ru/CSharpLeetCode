using CSharpLeetCode.InterviewProblems.Atlassian;

namespace CSharpLeetCodeTests.InterviewProblems
{
    [TestClass()]
    public class BadgeAccessTrackerMatchEntriesSolutionTests
    {
        private readonly BadgeAccessTrackerMatchEntriesSolution _solution = new();

        [TestMethod()]
        public void FindNonMatchingRecords_ShouldSatisfyExample1()
        {
            // arrange
            var data = TestData.recordSet1;
            var expectedMissingExits = new HashSet<string>() { "Paul", "Joe", "Steve", "Curtis" };
            var expectedMissingEntries = new HashSet<string>() { "Pauline", "Martha", "Curtis", "Joe" };


            // act
            var result = _solution.FindNonMatchingRecords(data);

            // assert
            Assert.IsTrue(expectedMissingExits.SetEquals(result.Item1.ToHashSet()));
            Assert.IsTrue(expectedMissingEntries.SetEquals(result.Item2.ToHashSet()));
        }

        [TestMethod()]
        public void FindNonMatchingRecords_ShouldSatisfyExample2()
        {
            // arrange
            var data = TestData.recordSet2;
            var expectedMissingExits = new HashSet<string>();
            var expectedMissingEntries = new HashSet<string>();

            // act
            var result = _solution.FindNonMatchingRecords(data);

            // assert
            Assert.IsTrue(expectedMissingExits.SetEquals(result.Item1.ToHashSet()));
            Assert.IsTrue(expectedMissingEntries.SetEquals(result.Item2.ToHashSet()));
        }

        [TestMethod()]
        public void FindNonMatchingRecords_ShouldSatisfyExample3()
        {
            // arrange
            var data = TestData.recordSet3;
            var expectedMissingExits = new HashSet<string>() { "Paul" };
            var expectedMissingEntries = new HashSet<string>() { "Paul" };

            // act
            var result = _solution.FindNonMatchingRecords(data);

            // assert
            Assert.IsTrue(expectedMissingExits.SetEquals(result.Item1.ToHashSet()));
            Assert.IsTrue(expectedMissingEntries.SetEquals(result.Item2.ToHashSet()));
        }

        [TestMethod()]
        public void FindNonMatchingRecords_ShouldSatisfyExample4()
        {
            // arrange
            var data = TestData.recordSet4;
            var expectedMissingExits = new HashSet<string>() { "Raj", "Paul" };
            var expectedMissingEntries = new HashSet<string>() { "Paul" };

            // act
            var result = _solution.FindNonMatchingRecords(data);

            // assert
            Assert.IsTrue(expectedMissingExits.SetEquals(result.Item1.ToHashSet()));
            Assert.IsTrue(expectedMissingEntries.SetEquals(result.Item2.ToHashSet()));
        }
        private static class TestData
        {
            public static readonly ValueTuple<string, string>[] recordSet1 = [
                ("Paul", "enter"),
                ("Pauline", "exit"),
                ("Paul", "enter"),
                ("Paul", "exit"),
                ("Martha", "exit"),
                ("Joe", "enter"),
                ("Martha", "enter"),
                ("Steve", "enter"),
                ("Martha", "exit"),
                ("Jennifer", "enter"),
                ("Joe", "enter"),
                ("Curtis", "exit"),
                ("Curtis", "enter"),
                ("Joe", "exit"),
                ("Martha", "enter"),
                ("Martha", "exit"),
                ("Jennifer", "exit"),
                ("Joe", "enter"),
                ("Joe", "enter"),
                ("Martha", "exit"),
                ("Joe", "exit"),
                ("Joe", "exit")
                ];

            public static readonly ValueTuple<string, string>[] recordSet2 = [
                ("Paul", "enter"),
                ("Paul", "exit")
                ];

            public static readonly ValueTuple<string, string>[] recordSet3 = [
                ("Paul", "enter"),
                ("Paul", "enter"),
                ("Paul", "exit"),
                ("Paul", "exit")
                ];

            public static readonly ValueTuple<string, string>[] recordSet4 = [
                ("Raj", "enter"),
                ("Paul", "enter"),
                ("Paul", "exit"),
                ("Paul", "exit"),
                ("Paul", "enter"),
                ("Raj", "enter")
                ];
        }
    }
}