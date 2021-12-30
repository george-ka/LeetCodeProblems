using System;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class NumberOfProvincesTests 
    {
        [Test]
        public void NumberOfProvincesTest1()
        {
            var grid = new int[][] 
            {
                new [] { 1,0,0,1 },
                new [] { 0,1,1,0 },
                new [] { 0,1,1,1 },
                new [] { 1,0,1,1 }
            };

            var result = CountIslands(grid);
            Assert.AreEqual(1, result);
        }

        private static int CountIslands(int[][] grid)
        {
            var sut = new NumberOfProvinces();
            return sut.FindCircleNum(grid);
        }
    }
}