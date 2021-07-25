using NUnit.Framework;
using LeetCodeProblems;

namespace LeetCodeProblemsTests
{
    public class BestTimeToBuyAndSellStocksTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var sut = new BestTimeToBuyAndSellStocksSolution();
            var result = sut.MaxProfit(new [] { 1, 10, 2, 10, 3, 10 });
            Console.WriteLine($"Result: {result}, expected: 16");
            
            Assert.Pass();
        }
    }
}