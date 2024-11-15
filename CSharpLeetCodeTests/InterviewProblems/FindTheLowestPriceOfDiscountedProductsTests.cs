using CSharpLeetCode.InterviewProblems;

namespace CSharpLeetCodeTests.InterviewProblems;

[TestClass()]
public class FindTheLowestPriceOfDiscountedProductsTests
{
    private readonly FindTheLowestPriceOfDiscountedProducts _solution = new();


    [TestMethod()]
    public void FindLowestPrice_TestCase1()
    {
        // arrange
        var products = new List<List<string>>()
        {
            new List<string> { "10", "d0", "d1" },
            new List<string> { "15", "EMPTY", "EMPTY" },
            new List<string> { "20", "d1", "EMPTY", string.Empty }
        };

        var discounts = new List<List<string>>()
        {
            new List<string> { "d0", "1", "27" },
            new List<string> { "d1", "2", "5" },
        };

        // act
        var result = _solution.FindLowestPrice(products, discounts);

        // assert
        Assert.AreEqual(35, result);
    }

    [TestMethod()]
    public void FindLowestPrice_TestCase2()
    {
        // arrange
        var products = new List<List<string>>()
        {
            new List<string> { "10", "d0", "d1" },
            new List<string> { "15", "EMPTY", "EMPTY" },
            new List<string> { "20", "d1", "EMPTY", string.Empty }
        };

        var discounts = new List<List<string>>()
        {
            new List<string> { "d0", "1", "27" },
            new List<string> { "d1", "2", "5" },
            new List<string> { "d1", "2", "40" },
        };

        // act
        var result = _solution.FindLowestPrice(products, discounts);

        // assert
        Assert.AreEqual(15, result);
    }

    [TestMethod()]
    public void FindLowestPrice_TestCase3()
    {
        // arrange
        var products = new List<List<string>>()
        {
            new List<string> { "10", "sale", "january-sale" },
            new List<string> { "200", "sale", "EMPTY" },
        };

        var discounts = new List<List<string>>()
        {
            new List<string> { "sale", "0", "10" },
            new List<string> { "january-sale", "1", "10" }
        };

        // act
        var result = _solution.FindLowestPrice(products, discounts);

        // assert
        Assert.AreEqual(19, result);
    }

    [TestMethod()]
    public void FindLowestPrice_TestCase4()
    {
        // arrange
        var products = new List<List<string>>()
        {
            new List<string> { "10", "sale", "january-sale" },
            new List<string> { "200", "sale", "EMPTY" },
        };

        var discounts = new List<List<string>>()
        {
            new List<string> { "sale", "0", "10" },
            new List<string> { "january-sale", "1", "10" },
            new List<string> { "sale1", "2", "10" },

        };

        // act
        var result = _solution.FindLowestPrice(products, discounts);

        // assert
        Assert.AreEqual(19, result);
    }

    [TestMethod()]
    public void FindLowestPrice_TestCase5()
    {
        // arrange
        var products = new List<List<string>>()
        {
            new List<string> { "100", "dcoupon1" },
            new List<string> { "50", "dcoupon1" },
            new List<string> { "30", "dcoupon1" },
            new List<string> { "100", "dcoupon2" },
            new List<string> { "50", "dcoupon2" },
            new List<string> { "30", "dcoupon1" },
        };

        var discounts = new List<List<string>>()
        {
            new List<string> { "sale", "0", "10" },
            new List<string> { "january-sale", "1", "10" }
        };

        // act
        var result = _solution.FindLowestPrice(products, discounts);

        // assert
        Assert.AreEqual(360, result);
    }
}