using System;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class QueensAttackingTheKingTests 
    {
        [Test]
        public void QueensAttackingTheKingTest1()
        {
            var qatk = new QueensAttackingTheKing();

            var queens = new int[][] { new[] { 0,1 }, new[] { 1, 0 }, new[] { 4,0 }, new[] { 0,4 }, new [] { 3,3 }, new [] {2,4} };
            var king = new[] { 0,0 };
            var result = qatk.QueensAttacktheKing(queens, king);

            Console.WriteLine("Closest queens:");
            foreach (var queen in result)
            {
                Console.WriteLine($"{queen[0]},{queen[1]}");
            }

            Assert.AreEqual(3, result.Count);
            CollectionAssert.AreEqual(new [] {1, 0}, result[0]);
            CollectionAssert.AreEqual(new [] {0, 1}, result[1]);
            CollectionAssert.AreEqual(new [] {3, 3}, result[2]);
        }
    }
}
