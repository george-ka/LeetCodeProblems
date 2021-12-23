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
            var result = GetTestResult(GetTestArray(), 7);
            Assert.AreEqual(new int[] { 1, 2 }, result);
        }

        [Test]
        public void FindRangeInSortedArrayTest2()
        {
            var result = GetTestResult(GetTestArray(), 8);
            Assert.AreEqual(new int[] { 3, 4 }, result);
        }

        [Test]
        public void FindRangeInSortedArrayTest3()
        {
            var result = GetTestResult(GetTestArray(), 5);
            Assert.AreEqual(new int[] { 0, 0 }, result);
        }

        [Test]
        public void FindRangeInSortedArrayTest4()
        {
            var result = GetTestResult(GetTestArray(), 10);
            Assert.AreEqual(new int[] { 5, 5 }, result);
        }

        [Test]
        public void FindRangeInSortedArrayTest5()
        {
            var result = GetTestResult(GetTestArray(), 11);
            Assert.AreEqual(new int[] { -1, -1 }, result);
        }
        
        [Test]
        public void FindRangeInSortedArrayTest6()
        {
            var result = GetTestResult(GetTestArray(), 6);
            Assert.AreEqual(new int[] { -1, -1 }, result);
        }

        [Test]
        public void FindRangeInSortedEmptyArrayTest()
        {
            var result = GetTestResult(new int[0], 11);
            Assert.AreEqual(new int[] { -1, -1 }, result);
        }

        [Test]
        public void FindRangeInSortedOneItemArrayTest()
        {
            var result = GetTestResult(new int[] { 1 }, 1);
            Assert.AreEqual(new int[] { 0, 0 }, result);
        }

        [Test]
        public void FindRangeInSortedOneItemArrayTest2()
        {
            var result = GetTestResult(new int[] { 1 }, 11);
            Assert.AreEqual(new int[] { -1, -1 }, result);
        }

        [Test]
        public void FindRangeInSortedTwoItemArrayTest2()
        {
            var result = GetTestResult(new int[] { 1, 1 }, 1);
            Assert.AreEqual(new int[] { 0, 1 }, result);
        }

        private int[] GetTestResult(int[] nums, int target)
        {
            var sut = new FindRangeInSortedArray();
            return sut.SearchRange(nums, target);
        }

        private int[] GetTestArray()
        {
            return new int[] { 5,7,7,8,8,10 };
        }
    }
}