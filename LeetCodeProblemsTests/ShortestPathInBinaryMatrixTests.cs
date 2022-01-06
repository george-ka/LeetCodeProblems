using System;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class ShortestPathInBinaryMatrixTests 
    {
        [Test]
        public void ShortestPathInBinaryMatrixTest1()
        {
            var grid = new int[][] 
            {
                new int[] { 0,1,0,0,0 },
                new int[] { 0,1,0,0,0 },
                new int[] { 0,0,1,0,0 },
                new int[] { 0,0,0,1,0 },
                new int[] { 0,0,0,1,0 }
            };

            var result = FindShortestPath(grid);
            Assert.AreEqual(7, result);
        }

        [Test]
        public void ShortestPathInBinaryMatrixTest2()
        {
            var grid = new int[][] 
            {
                new int[] { 0,1,0,0,0 },
                new int[] { 0,1,0,1,0 },
                new int[] { 0,0,1,1,0 },
                new int[] { 0,0,0,1,0 },
                new int[] { 0,1,0,1,0 }
            };

            var result = FindShortestPath(grid);
            Assert.AreEqual(9, result);
        }

        [Test]
        public void ShortestPathInBinaryMatrixTest3()
        {
            var grid = new int[][] 
            {
                new int[] { 0,1,0,0,0,0 },
                new int[] { 0,1,0,1,1,0 },
                new int[] { 0,1,1,0,1,0 },
                new int[] { 0,0,0,0,1,0 },
                new int[] { 1,1,1,1,1,0 },
                new int[] { 1,1,1,1,1,0 }
            };

            var result = FindShortestPath(grid);
            Assert.AreEqual(14, result);
        }

        [Test]
        public void ShortestPathInBinaryMatrixTest4()
        {
            var grid = new int[][] 
            {
                new int[] { 0,0,0,0,1,1 },
                new int[] { 0,1,0,0,1,0 },
                new int[] { 1,1,0,1,0,0 },
                new int[] { 0,1,0,0,1,1 },
                new int[] { 0,1,0,0,0,1 },
                new int[] { 0,0,1,0,0,0 }
            };

            var result = FindShortestPath(grid);
            Assert.AreEqual(7, result);
        }

        [Test]
        public void ShortestPathInBinaryMatrixTest5()
        {
            // This test exposes a downside that step down is more preferrable than step right
            // Next test reverses that and if we just change the riority the same problem will occur
            // It means that we need to try both ways. Some ways have the same priority and thus have 
            // to be checked both.
            // Or we can try to chose direction based on distance 
            // d(target - next1) < d(target - next2) => chose next1
            // d = sqrt((xt-xn1)^2 + (yt-yn1)^2)
            // for point (3, 2) next1 = (4, 2), next2 = (3, 3), target = (5, 5)
            // d1 = sqrt((5-4)^2 + (5-2)^2) = sqrt(1 + 9) = sqrt(10) = 3.162
            // d2 = sqrt((5-3)^2 + (5-3)^2) = sqrt(8) = 2.828
            // therefore d2 < d1 and we should go right from point (3,2) 
            var grid = new int[][] 
            {
                new int[] { 0,1,0,0,0,0 },
                new int[] { 0,1,1,1,1,1 },
                new int[] { 0,0,0,0,1,1 },
                new int[] { 0,1,0,0,0,1 },
                new int[] { 1,0,0,1,0,1 },
                new int[] { 0,0,1,0,1,0 }
            };

            var result = FindShortestPath(grid);
            Assert.AreEqual(7, result);
        }

        [Test]
        public void ShortestPathInBinaryMatrixTest6()
        {
            var grid = new int[][] 
            {
                //          0 1 2 3 4 5 6
                new int[] { 0,0,1,0,0,0,0 }, // 0
                new int[] { 0,1,0,0,0,0,1 }, // 1
                new int[] { 0,0,1,0,1,0,0 }, // 2
                new int[] { 0,0,0,1,1,1,0 }, // 3
                new int[] { 1,0,0,1,1,0,0 }, // 4
                new int[] { 1,1,1,1,1,0,1 }, // 5
                new int[] { 0,0,1,0,0,0,0 }  // 6
            };

            var result = FindShortestPath(grid);
            Assert.AreEqual(10, result);
        }

        // After this test  I gave up and understood, that there is no heuristic, that would give
        // the best answer apriori.
        // You need to check all the fucking options to make sure that you've found the shortest path
        // See you need to go "back" counterintuitively from (1,1) to (2,0) and not to (1,2), because 
        // it's closer to the target :'(
        [Test]
        public void ShortestPathInBinaryMatrixTest7()
        {
            var grid = new int[][] 
            {
                new int[] { 0,0,1,0,0,1,0,1,0 }, // 0
                new int[] { 0,0,0,0,0,0,0,0,0 }, // 1
                new int[] { 0,1,1,0,1,1,1,1,1 }, // 2
                new int[] { 0,0,0,1,0,0,0,0,0 }, // 3
                new int[] { 1,1,0,0,0,1,0,0,0 }, // 4
                new int[] { 1,0,1,0,0,1,0,0,1 }, // 5
                new int[] { 1,1,1,1,0,0,1,0,0 }, // 6
                new int[] { 1,0,0,1,0,0,1,1,1 }, // 7
                new int[] { 0,0,0,0,0,0,0,0,0 }  // 8
                //          0 1 2 3 4 5 6 7 8 
            };

            var result = FindShortestPath(grid);
            Assert.AreEqual(11, result);
        } 

        [Test]
        public void ShortestPathInBinaryMatrixTrivialTest()
        {
            var grid = new int[][] 
            {
                new int[] { 0,0 }, // 0
                new int[] { 0,0 }
            };

            var result = FindShortestPath(grid);
            Assert.AreEqual(2, result);
        } 

        [Test]
        public void ShortestPathInBinaryMatrixTrivialTest2()
        {
            var grid = new int[][] 
            {
                new int[] { 0 },
            };

            var result = FindShortestPath(grid);
            Assert.AreEqual(1, result);
        } 

        [Test]
        public void ShortestPathInBinaryMatrixTestNegative1()
        {
            var grid = new int[][] 
            {
                new int[] { 0,1,0,1,0 },
                new int[] { 0,1,0,1,0 },
                new int[] { 0,0,1,1,0 },
                new int[] { 0,0,0,1,0 },
                new int[] { 0,1,0,1,0 }
            };

            var result = FindShortestPath(grid);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void ShortestPathInBinaryMatrixTest8()
        {
            var grid = new int[][] 
            {
                new int[] { 0,0,0,0,0,0,0,0 }, // 0
                new int[] { 0,0,1,0,0,0,0,1 }, // 1
                new int[] { 1,0,0,0,0,0,0,0 }, // 2
                new int[] { 0,0,0,0,0,1,1,0 }, // 3
                new int[] { 0,0,1,0,1,0,1,1 }, // 4
                new int[] { 0,0,0,0,0,0,0,0 }, // 5
                new int[] { 0,0,0,1,1,1,0,0 }, // 6
                new int[] { 1,0,1,1,1,0,0,0 }, // 7
                //          0 1 2 3 4 5 6 7 
            };

            var result = FindShortestPath(grid);
            Assert.AreEqual(9, result);
        } 

        private int FindShortestPath(int[][] grid)
        {
            var sut = new ShortestPathInBinaryMatrix();
            return sut.ShortestPathBinaryMatrix(grid);
        }
    }
}
