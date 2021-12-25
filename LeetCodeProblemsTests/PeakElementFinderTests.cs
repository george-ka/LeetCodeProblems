using System;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class PeakElementFinderTests 
    {
        [Test]
        public void FindPeakElementTest1()
        {
            var nums = new int[] { 0, 1, 2, 100, 3, 2, 1, 100, 0};
            var result = FindPeak(nums);

            Assert.AreEqual(3, result);
        }

        [Test]
        public void FindPeakElementTest2()
        {
            var nums = new int[] { 0, 1, 2, 1, 3, 2, 1 };
            var result = FindPeak(nums);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void FindPeakElementEdgeTest()
        {
            var nums = new int[] { 2, 0, 1, 2, 100, 3, 2, 1, 100, 0};
            var result = FindPeak(nums);
            
            Assert.AreEqual(0, result);
        }

        [Test]
        public void FindPeakElementEdgeTest2()
        {
            var nums = new int[] { 0, 1, 2, 100, 3, 2, 1, 5 };
            var result = FindPeak(nums);
            
            Assert.AreEqual(7, result);
        }

        private int FindPeak(int[] nums)
        {
            var sut = new PeakElementFinder();
            var result = sut.FindPeakElement(nums);
            Console.WriteLine(result);
            return result;
        }
    }
}