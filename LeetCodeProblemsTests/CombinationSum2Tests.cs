using System;
using System.Collections.Generic;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class CombinationSum2Tests 
    {
        [Test]
        public void CombinationSum2Test1()
        {
            var nums = new int[] { 10,1,2,7,6,1,5 };
            var sut = new CombinationSum2Solution();
            var result = sut.CombinationSum2(nums, 8);

            Assert.AreEqual(4, result.Count);
        }

        [Test]
        public void CombinationSum2Test2()
        {
            var nums = new int[] { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 };
            var sut = new CombinationSum2Solution();
            var result = sut.CombinationSum2(nums, 30);

            Assert.AreEqual(1, result.Count);
        }
    }
}