using System;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class WiggleSortTests
    {
        [Test]
        public void FindMedianForAlmostAllEqual()
        {
            var nums = new int[] { 21, 20, 21 };
            var sut = new WiggleSortSolution();
            var median = sut.FindMedian(nums);

            Assert.AreEqual(20, median);
        }
    }
}