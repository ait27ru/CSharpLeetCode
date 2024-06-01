using CSharpLeetCode.InterviewProblems;

namespace CSharpLeetCodeTests.InterviewProblems
{
    [TestClass()]
    public class TurnstilePassTimesTests
    {
        private readonly TurnstilePassTimes _solution = new();

        [TestMethod()]
        public void GetTimes_TestCase1()
        {
            // arrange
            var time = new List<int> { 0, 0, 1, 5 };
            var direction = new List<int> { 0, 1, 1, 0 };

            // act
            var result = _solution.GetTimes(time, direction);

            // assert
            CollectionAssert.AreEqual(new List<int> { 2, 0, 1, 5 }, result);
        }

        [TestMethod()]
        public void GetTimes_TestCase2()
        {
            // arrange
            var time = new List<int> { 0, 1, 1, 3, 3 };
            var direction = new List<int> { 0, 1, 0, 0, 1 };

            // act
            var result = _solution.GetTimes(time, direction);

            // assert
            CollectionAssert.AreEqual(new List<int> { 0, 2, 1, 4, 3 }, result);
        }
    }
}
