using System;
using LeetCodeChallenges;

namespace LeetCodeProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            MaximizeProfit(new [] { 3, 4, 5, 6, 7, 1, 10 }, 12);
            Console.WriteLine("Hello World!");
        }

        private static void MaximizeProfit(int[] prices, int expected)
        {
            var sut = new BestTimeToBuyAndSellStocksSolution();
            var result = sut.MaxProfit(prices);
            // Assert.AreEqual(expected, result);
            Console.WriteLine($"{expected} {result}");
        }
    }
}
