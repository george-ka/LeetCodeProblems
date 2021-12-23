using System;
using System.Collections.Generic;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class FindRangeInSortedArrayTests
    {
        [Test]
        public void FindRangeInSortedArrayTest1()
        {
            var result = GetTestResult(GetTestArray(), 0);
            Assert.AreEqual(4, result);
        }

        private int GetTestResult(int[] nums, int target)
        {
            var sut = new SearchInRotatedSortedArray();
            return sut.Search(nums, target);
        }

        private int[] GetTestArray()
        {
            return new int[] { 4,5,6,7,0,1,2 };
        }
    }
}