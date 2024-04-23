using CSharpLeetCode.EasyProblems;

namespace CSharpLeetCodeTests.EasyProblems
{
    [TestClass]
    public class ValidParenthesesTests
    {
        private ValidParentheses solution = new ValidParentheses();

        [TestMethod]
        public void IsValid_ShouldSatisfy_Example1()
        {
            // arrange
            var inputString = "()";
            // act
            var result = solution.IsValid(inputString);
            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_ShouldSatisfy_Example2()
        {
            // arrange
            var inputString = "()";
            // act
            var result = solution.IsValid(inputString);
            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_ShouldSatisfy_Example3()
        {
            // arrange
            var inputString = "(]";
            // act
            var result = solution.IsValid(inputString);
            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_ShouldSatisfy_Example4()
        {
            // arrange
            var inputString = "({[]})";
            // act
            var result = solution.IsValid(inputString);
            // assert
            Assert.IsTrue(result);
        }
    }
}
