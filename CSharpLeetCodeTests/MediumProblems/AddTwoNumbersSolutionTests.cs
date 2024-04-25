using CSharpLeetCode.MediumProblems;

namespace CSharpLeetCodeTests.MediumProblems
{
    [TestClass()]
    public class AddTwoNumbersSolutionTests
    {
        [TestMethod()]
        public void AddTwoNumbers_ShouldSatisfy_Example1()
        {
            // arrange
            var list1 = ListNode.createOf(2, 4, 3);
            var list2 = ListNode.createOf(5, 6, 4);

            // act
            var sum = AddTwoNumbersSolution.AddTwoNumbers(list1, list2);

            // assert
            var s = sum.ToString();
            Assert.AreEqual("7 -> 0 -> 8", sum.ToString());
        }

        [TestMethod()]
        public void AddTwoNumbers_ShouldSatisfy_Example2()
        {
            // arrange
            var list1 = ListNode.createOf(0);
            var list2 = ListNode.createOf(0);

            // act
            var sum = AddTwoNumbersSolution.AddTwoNumbers(list1, list2);

            // assert
            var s = sum.ToString();
            Assert.AreEqual("0", sum.ToString());
        }

        [TestMethod()]
        public void AddTwoNumbers_ShouldSatisfy_Example3()
        {
            // arrange
            var list1 = ListNode.createOf(9, 9, 9, 9, 9, 9, 9);
            var list2 = ListNode.createOf(9, 9, 9, 9);

            // act
            var sum = AddTwoNumbersSolution.AddTwoNumbers(list1, list2);

            // assert
            var s = sum.ToString();
            Assert.AreEqual("8 -> 9 -> 9 -> 9 -> 0 -> 0 -> 0 -> 1", sum.ToString());
        }
    }
}