using System;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class BestTimeToBuyAndSellStocksTests
    {
        [Test]
        public void Test1()
        {
            var sut = new BestTimeToBuyAndSellStocksSolution();
            var result = sut.MaxProfit(new [] { 1, 10, 2, 10, 3, 10 });
            Assert.AreEqual(16, result);
        }
    }
}