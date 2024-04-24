/*
    https://leetcode.com/problems/coin-change/description/
    You are given an integer array coins representing coins of different denominations and
    an integer amount representing a total amount of money.
    Return the fewest number of coins that you need to make up that amount.
    If that amount of money cannot be made up by any combination of the coins, return -1.
    You may assume that you have an infinite number of each kind of coin.
*/

namespace CSharpLeetCode.MediumProblems
{
    public class CoinChange
    {
        public int CoinChangeSolution(int[] coins, int amount)
        {
            var maxAmount = amount + 1;

            int[] dp = new int[maxAmount];
            Array.Fill(dp, maxAmount);

            dp[0] = 0;

            for (int currentAmount = 1; currentAmount < maxAmount; currentAmount++)
            {
                foreach (var coin in coins)
                {
                    if (currentAmount - coin >= 0)
                    {
                        dp[currentAmount] = Math.Min(dp[currentAmount], 1 + dp[currentAmount - coin]);
                    }
                }
            }

            if (dp[amount] == maxAmount)
                return -1;
            else
                return dp[amount];
        }
    }
}
