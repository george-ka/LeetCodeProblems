using System;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class ThreeSumClosestTests
    {
        private static void RunTest(int[] nums, int target, int expected)
        {
            Console.WriteLine("Running test for");
            PrintArray(nums);
            var solution = new ThreeSumClosestSolution();
            var closestSum = solution.ThreeSumClosest(nums, target);
            Console.WriteLine($"Target: {target}, expected: {expected}, result: {closestSum}");
            Assert.AreEqual(expected, closestSum);
        }

        private static void PrintArray(int[] nums)
        {
            foreach (var i in nums)
            {
                Console.Write(i);
                Console.Write(", ");
            }

            Console.WriteLine();
        }

        [Test]
        public void ThreeSumClosestTest1()
        {
            var nums = new[] { -1, 2, 1 , -4 };
            var target = 1;
            RunTest(nums, target, 2);
        }

        [Test]
        public void ThreeSumClosestTest2()
        {
            var nums = new[] { -39, -5, 1, 4 , 6, 11, 22, 33 };
            var target = 2;
            RunTest(nums, target, 2);
        }

        [Test]
        public void ThreeSumClosestTest3()
        {
            var nums = new[] {0,2,1,-3};
            var target = 1;
            RunTest(nums, target, 0);
        }

        [Test]
        public void ThreeSumClosestTest4()
        {
            var nums = new[] {4,0,5,-5,3,3,0,-4,-5};
            var target = -2;
            RunTest(nums, target, -2);
        }

        [Test]
        public void ThreeSumClosestTest5()
        {
            var nums = new[] {-55,-24,-18,-11,-7,-3,4,5,6,9,11,23,33};
            var target = 0;
            RunTest(nums, target, target);
        }
    }
}