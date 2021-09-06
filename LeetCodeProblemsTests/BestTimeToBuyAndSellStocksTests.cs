using System;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class BestTimeToBuyAndSellStocksTests
    {
        [Test]
        public void MaximizeProfitTest1()
        {
            MaximizeProfit(new [] { 1, 10, 2, 10, 3, 10 }, 16);
        }

        [Test]
        public void MaximizeProfitTest2()
        {
            MaximizeProfit(new [] { 1, 1, 1, 1, 2, 2, 3, 4, 5, 6, 7, 1, 10 }, 14);
        }

        [Test]
        public void MaximizeProfitTest3()
        {
            MaximizeProfit(new [] { 1, 1, 1, 1, 1, 1, 1 }, 0);
        }

        [Test]
        public void MaximizeProfitTest4()
        {
            MaximizeProfit(new [] { 1, 1, 1, 1, 1, 1, 2 }, 1);
        }

        [Test]
        public void MaximizeProfitTest5()
        {
            MaximizeProfit(new [] { 1, 1, 1, 1, 1, 1, 2, 1 }, 1);
        }

        [Test]
        public void MaximizeProfitTest6()
        {
            MaximizeProfit(new [] { 1, 2 }, 1);
        }

        [Test]
        public void MaximizeProfitTest7()
        {
            MaximizeProfit(new [] { 1 }, 0);
        }

        [Test]
        public void MaximizeProfitTest8()
        {
            MaximizeProfit(new [] { 10, 9, 8, 7 }, 0);
        }

        [Test]
        public void MaximizeProfitTest9()
        {
            MaximizeProfit(new [] { 6, 1, 3, 2, 4, 7 }, 6);
        }

        private void MaximizeProfit(int[] prices, int expected)
        {
            var sut = new BestTimeToBuyAndSellStocksSolution();
            var result = sut.MaxProfit(prices);
            Assert.AreEqual(expected, result);
        }

    }
}