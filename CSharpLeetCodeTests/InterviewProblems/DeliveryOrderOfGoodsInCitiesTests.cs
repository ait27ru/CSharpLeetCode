using CSharpLeetCode.InterviewProblems;

namespace CSharpLeetCodeTests.InterviewProblems
{
    [TestClass()]
    public class DeliveryOrderOfGoodsInCitiesTests
    {
        private readonly DeliveryOrderOfGoodsInCities _solution = new();

        [TestMethod()]
        public void Order_TestCase1()
        {
            // arrange
            var cityNodes = 4;
            var cityFrom = new List<int> { 1, 2, 2 };
            var cityTo = new List<int> { 2, 3, 4 };
            var company = 1;

            // act
            var res = _solution.Order(cityNodes, cityFrom, cityTo, company);

            // assert
            CollectionAssert.AreEqual(new List<int> { 2, 3, 4 }, res);
        }

        [TestMethod()]
        public void Order_TestCase2()
        {
            // arrange
            var cityNodes = 3;
            var cityFrom = new List<int> { 1 };
            var cityTo = new List<int> { 2 };
            var company = 2;

            // act
            var res = _solution.Order(cityNodes, cityFrom, cityTo, company);

            // assert
            CollectionAssert.AreEqual(new List<int> { 1 }, res);
        }

        [TestMethod()]
        public void Order_TestCase3()
        {
            // arrange
            var cityNodes = 5;
            var cityFrom = new List<int> { 1, 1, 2, 3, 1 };
            var cityTo = new List<int> { 2, 3, 4, 5, 5 };
            var company = 1;

            // act
            var res = _solution.Order(cityNodes, cityFrom, cityTo, company);

            // assert
            CollectionAssert.AreEqual(new List<int> { 2, 3, 5, 4 }, res);
        }
    }
}