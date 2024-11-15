/*
An e-commerce company is currently celebrating ten years in business. They are having a sale to honor their privileged members,
those who have been using their services for the past five years. They receive the best discounts indicated by any discount tags attached to the product.
Determine the minimum cost to purchase all products listed. As each potential price is calculated, truncate it to its integer part before adding it
to the total. Return the cost to purchase all items as an integer.

There are three types of discount tags:

* Type 0: discounted price, the item is sold for a given price.
* Type 1: percentage discount, the customer is given a fixed percentage discount from the retail price.
* Type 2: fixed discount, the customer is given a fixed amount off from the retail price.

Example

products = [['10', 'd0', 'd1'], ['15', 'EMPTY', 'EMPTY'], ['20', 'd1', 'EMPTY']] 
discounts = [['d0', '1','27'], ['d1', '2', '5']]

The products array elements are in the form ['price', 'tag 1', 'tag 2',.... 'tag m-1']. 
There may be zero or more discount codes associated with a product. 
Discount tags in the products array may be 'EMPTY' which is the same as a null value. 

The discounts array elements are in the form ['tag', 'type', 'amount'].
Discount tags are not unique.

1. If a privileged member buys product 1 listed at a price of 10 with two discounts available:
* Under discount d0 of type 1, the discounted price is 10 - 10 * 0.27 = 7.30, round to 7.
* Under discount d1 of type 2, the discounted price is 10 - 5 = 5.
* The price to purchase the product 1 is the lower of the two, or 5 in this case

2. The second product is priced at 15 because there are no discounts available

3. The third product is priced at 20. Using discount tag d1 of type 2, the discounted price is 20 - 5 = 15

The total price to purchase the three items is 5 + 15 + 15 = 35.

Notes: Not all items will have the maximum number of tags. Empty tags may not exist in input, or they may be filled with the string EMPTY. 
These are equivalent as demonstrated in the example.

--------------------------------
n - number of products
m - number of discount tags across all products
d - number of distinct discounts
k - average number of discounts per tag

Time complexity:

Building the discount map: O(d)
Main loop, calculate mininum prices: O(n * m * k)

Combined time: O(d + n * m * k)

--------------------------------
Space Complexity:

Discount map O(d * k)

Combined space: O(d * k)

 */

namespace CSharpLeetCode.InterviewProblems;

public class FindTheLowestPriceOfDiscountedProducts
{
    private record Discount(int type, double amount);

    public int FindLowestPrice(List<List<string>> products, List<List<string>> discounts)
    {
        var discountMap = new Dictionary<string, List<Discount>>();

        foreach (var discount in discounts)
        {
            var tag = discount[0];
            var type = int.Parse(discount[1]);
            var amount = double.Parse(discount[2]);

            if (!discountMap.ContainsKey(tag))
            {
                discountMap[tag] = new();
            }
            discountMap[tag].Add(new Discount(type, amount));
        }

        var totalCost = 0;

        foreach (var product in products)
        {
            double productPrice = double.Parse(product[0]);
            double minPrice = productPrice;

            for (int i = 1; i < product.Count; i++)
            {
                string discountTag = product[i];

                if (discountTag == "EMPTY" || string.IsNullOrEmpty(discountTag))
                    continue;

                if (discountMap.TryGetValue(discountTag, out var productDiscounts))
                {
                    foreach (var productDiscount in productDiscounts)
                    {
                        var discountedPrice = GetDiscountedPrice(productPrice, productDiscount);
                        minPrice = Math.Min(minPrice, discountedPrice);
                    }
                }
            }
            totalCost += (int)Math.Floor(minPrice);
        }

        return totalCost;
    }

    private double GetDiscountedPrice(double price, Discount discount)
    {
        var discountedPrice = discount.type switch
        {
            0 => discount.amount,
            1 => price - (price * discount.amount / 100),
            2 => price - discount.amount,
            _ => throw new ArgumentException($"Unknown discount type: {discount.type}")
        };
        return discountedPrice < 0 ? 0 : discountedPrice;
    }
}
