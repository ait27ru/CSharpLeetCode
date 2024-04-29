using CSharpLeetCode.EasyProblems;

namespace CSharpLeetCodeTests.EasyProblems
{
    [TestClass]
    public class ValidParenthesesSolutionTests
    {
        private readonly ValidParenthesesSolution _solution = new();

        [TestMethod]
        public void IsValid_ShouldSatisfy_Example1()
        {
            // arrange
            var inputString = "()";
            // act
            var result = _solution.IsValid(inputString);
            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_ShouldSatisfy_Example2()
        {
            // arrange
            var inputString = "()";
            // act
            var result = _solution.IsValid(inputString);
            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_ShouldSatisfy_Example3()
        {
            // arrange
            var inputString = "(]";
            // act
            var result = _solution.IsValid(inputString);
            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_ShouldSatisfy_Example4()
        {
            // arrange
            var inputString = "({[]})";
            // act
            var result = _solution.IsValid(inputString);
            // assert
            Assert.IsTrue(result);
        }
    }
}
