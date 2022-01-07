using System;
using System.Collections.Generic;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class AllSubsetsTests 
    {
        [Test]
        public void AllSubsetsForSetWithDuplicatesTest1()
        {
            var nums = new [] { 1, 2, 2, 3 };

            var result = GenerateSubsets(nums);
            Assert.AreEqual(12, result.Count);
        }

        [Test]
        public void AllSubsetsForSetWithDuplicatesTest2()
        {
            var nums = new [] { 1, 2, 2, 2, 3 };

            var result = GenerateSubsets(nums);
            Assert.AreEqual(16, result.Count);
        }

        [Test]
        public void AllSubsetsForSetWithDuplicatesTest3()
        {
            var nums = new [] { 1, 2, 2 };

            var result = GenerateSubsets(nums);
            Assert.AreEqual(6, result.Count);
        }

        private IList<IList<int>> GenerateSubsets(int[] nums)
        {
            var sut = new AllSubsets2();
            var result = sut.SubsetsWithDup(nums);
            foreach (var set in result)
            {
                Console.WriteLine();
                Console.Write("[");
                for (var i = 0; i < set.Count; i++)
                {
                    Console.Write($"{set[i]}, ");
                }

                Console.Write("]");
            }

            return result;
        }
   }
}