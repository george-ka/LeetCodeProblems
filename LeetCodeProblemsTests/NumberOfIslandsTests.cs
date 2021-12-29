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

        [Test]
        public void NumberOfIslandsTest2()
        {
            var grid = new char[][] 
            {
                new char[] { '1','1','1','1','0' },
                new char[] { '1','1','0','1','0' },
                new char[] { '1','1','0','0','0' },
                new char[] { '0','0','0','0','0' }
            };

            var result = CountIslands(grid);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void NumberOfIslandsTest3()
        {
            var grid = new char[][] 
            {
                new char[] { '1','0','1','0','1' },
                new char[] { '1','0','1','0','1' },
                new char[] { '1','1','1','1','1' },
                new char[] { '0','0','0','0','1' }
            };

            var result = CountIslands(grid);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void NumberOfIslandsTest4()
        {
            var grid = new char[][] 
            {
                new char[] { '1','1','1','1','1','0','1','1','1','1' },
                new char[] { '1','0','1','0','1','1','1','1','1','1' },
                new char[] { '0','1','1','1','0','1','1','1','1','1' },
                new char[] { '1','1','0','1','1','0','0','0','0','1' },
                new char[] { '1','0','1','0','1','0','0','1','0','1' },
                new char[] { '1','0','0','1','1','1','0','1','0','0' },
                new char[] { '0','0','1','0','0','1','1','1','1','0' },
                new char[] { '1','0','1','1','1','0','0','1','1','1' },
                new char[] { '1','1','1','1','1','1','1','1','0','1' },
                new char[] { '1','0','1','1','1','1','1','1','1','0' }
            };

            PrintGrid(grid);
            var result = CountIslands(grid);
            
            PrintGrid(grid);

            Assert.AreEqual(2, result);
        }

        private static int CountIslands(char[][] grid)
        {
            var sut = new NumberOfIslands2();
            return sut.NumIslands(grid);
        }

        private static void PrintGrid(char[][] grid)
        {
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    Console.Write(((int)grid[i][j]).ToString("D2") + ",");
                }

                Console.WriteLine();
            }
        }
    }
}