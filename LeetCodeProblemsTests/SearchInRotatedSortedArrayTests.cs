using System;
using System.Collections.Generic;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class SearchInRotatedSortedArrayTests
    {
        [Test]
        public void SearchInRotatedSortedArrayTest1()
        {
            var result = GetTestResult(GetTestArray(), 0);
            Assert.AreEqual(4, result);
        }

        [Test]
        public void SearchInRotatedSortedArrayTest2()
        {
            var result = GetTestResult(GetTestArray(), 5);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void SearchInRotatedSortedArrayTest3()
        {
            var result = GetTestResult(GetTestArray(), 3);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void SearchInRotatedSortedArrayTest4()
        {
            var result = GetTestResult(new int[] {1}, 3);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void SearchInRotatedSortedArrayTest5()
        {
            var result = GetTestResult(new int[] {3,5,1}, 1);
            Assert.AreEqual(2, result);
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