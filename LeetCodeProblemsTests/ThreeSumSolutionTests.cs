using System;
using System.Collections.Generic;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class ThreeSumSolutionTests
    {
        private static IList<IList<int>> RunTest(int[] nums)
        {
            Console.WriteLine("Running test for");
            PrintArray(nums);
            var solution = new ThreeSumSolution();
            var sums = solution.ThreeSum(nums);

            Console.WriteLine("Found following combinations which add to zero:");
            foreach (var sum in sums)
            {
                PrintArray(sum);
            }

            return sums;
        }

        private static void PrintArray(IList<int> nums)
        {
            foreach (var i in nums)
            {
                Console.Write(i);
                Console.Write(", ");
            }

            Console.WriteLine();
        }

        [Test]
        public void ThreeSumTest1()
        {
            var nums = new[] { -1, -1, 2, 1 , -4 };
            var result = RunTest(nums);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(new int[] { -1, -1, 2 }, result[0]);
        }

        [Test]
        public void ThreeSumTest2()
        {
            var nums = new[] { -39, -5, 1, 4 , 6, 11, 22, 33 };
            RunTest(nums);
        }

        [Test]
        public void ThreeSumTest3()
        {
            var nums = new[] { 0,0 };
            var result = RunTest(nums);
            Assert.AreEqual(0, result.Count);
        }

    }
}