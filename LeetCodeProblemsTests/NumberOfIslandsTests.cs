using System;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class NumberOfIslandsTests 
    {
        [Test]
        public void NumberOfIslandsTest1()
        {
            var grid = new char[][] 
            {
                new char[] { '1','1','0','0','0' },
                new char[] { '1','1','0','0','0' },
                new char[] { '0','0','1','0','0' },
                new char[] { '0','0','0','1','1' }
            };

            var result = CountIslands(grid);
            Assert.AreEqual(3, result);
        }

        private static int CountIslands(char[][] grid)
        {
            var sut = new NumberOfIslands();
            return sut.NumIslands(grid);
        }
    }
}