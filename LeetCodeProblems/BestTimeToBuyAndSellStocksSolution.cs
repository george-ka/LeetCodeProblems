using System;

namespace LeetCodeChallenges
{
    ///
    /// 309. Best Time to Buy and Sell Stock with Cooldown
    /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/
    ///
    /// Sample
    ///   0  1   2  3   4  5
    /// [ 1, 10, 2, 10, 3, 10 ]
    /// Build a solution tree like that
    ///               ______(root)________________________
    ///           -1 /  -10|   -2|     -10\     -3\     -10\
    ///        (buy@0) (buy@1) (buy@2) (buy@3) (buy@4)   (buy@5)
    ///  let's depth first search from the first branch
    /// on the next level try to find all sell options with positive income 
    /// we should do this sell search up to the local maximum
    ///       +10 / - we can see that next value is lower so this is local maximum 
    ///               so we should stop our sell search here
    ///      (sell@1)
    ///       Next possible buy option is 3
    ///     -10 /
    ///     (buy@3)  
    ///      we can't sell it with profit, so discard this branch (return that maximum profit is 0)
    ///      we should momoize it too
    ///            -3 |  
    ///           (buy@4) - recursively go to the next possible index = 4
    ///           +10 |
    ///           (sell@5) - max profit = 7, memoize
    ///          no other options 
    ///          return the max profit to the first node and memoize at buy calls 
    ///          this branch profit is -1 + 10 - 3 + 10 = 16
    ///        let's go back to the ground floor
    ///                 -10|
    ///                (buy@1) - we can't sell it with profit, go back to the root
    ///                        -2|
    ///                        (buy@2)
    ///                          |
    ///                    +10 /
    ///                    (sell@3) 
    ///                    this is a leaf we can't go further
    ///                    go back to the root with max profit = 8
    ///                                -10\
    ///                               (buy@3) - memoized, profit 0, go to root
    ///                                        -3|
    ///                                       (buy@4) - memoized, profit = 7
    public class BestTimeToBuyAndSellStocksSolution
    {
        public int MaxProfit(int[] prices) 
        {
            return 0;
        }
    }
}