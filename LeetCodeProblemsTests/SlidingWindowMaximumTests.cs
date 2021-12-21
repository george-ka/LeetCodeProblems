using System;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class SlidingWindowMaximumTests 
    {
        [Test]
        public void MaxHeapConstructTest()
        {
            var sut = BuildHeap();
            Console.WriteLine(sut.ToString());
            Console.WriteLine(sut.ToTreeString());

            Assert.AreEqual("51, 50, 6, 10, 7, 5, 4, 8, 1, 0, -1, -2, -3, -4, -5, 2, 3, ", sut.ToString());
        }

        [Test]
        public void MaxHeapDeleteRootTest()
        {
            var sut = BuildHeap();
            sut.DeleteAt(1);
            Console.WriteLine(sut.ToTreeString());
            Console.WriteLine(sut.ToString());
            Assert.AreEqual("50, 10, 6, 8, 7, 5, 4, 3, 1, 0, -1, -2, -3, -4, -5, 2, ", sut.ToString());
        }

        [Test]
        public void SlidingWindowMaximumRegularTest()
        {
            var sut = new SlidingWindowMaximum2();
            var nums = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };
            var result = sut.MaxSlidingWindow(nums, 3);
            Assert.AreEqual(new int[] { 3, 3, 5, 5, 6, 7 }, result);
        }

        [Test]
        public void SlidingWindowMaximumOneValueTest()
        {
            var sut = new SlidingWindowMaximum2();
            var nums = new int[] { 1 };
            var result = sut.MaxSlidingWindow(nums, 1);
            Assert.AreEqual(new int[] { 1 }, result);
        }

        [Test]
        public void FailedLeetCodeTest1()
        {
            var sut = new SlidingWindowMaximum2();
            var nums = new int[] {-5769,-7887,-5709,4600,-7919,9807,1303,-2644,1144,-6410,-7159,-2041,9059,-663,4612,-257,2870,-6646,8161,3380,6823,1871,-4030,-1758,4834,-5317,6218,-4105,6869,8595,8718,-4141,-3893,-4259,-3440,-5426,9766,-5396,-7824,-3941,4600,-1485,-1486,-4530,-1636,-2088,-5295,-5383,5786,-9489,3180,-4575,-7043,-2153,1123,1750,-1347,-4299,-4401,-7772,5872,6144,-4953,-9934,8507,951,-8828,-5942,-3499,-174,7629,5877,3338,8899,4223,-8068,3775,7954,8740,4567,6280,-7687,-4811,-8094,2209,-4476,-8328,2385,-2156,7028,-3864,7272,-1199,-1397,1581,-9635,9087,-6262,-3061,-6083,-2825,-8574,5534,4006,-2691,6699,7558,-453,3492,3416,2218,7537,8854,-3321,-5489,-945,1302,-7176,-9201,-9588,-140,1369,3322,-7320,-8426,-8446,-2475,8243,-3324,8993,8315,2863,-7580,-7949,4400};
            var result = sut.MaxSlidingWindow(nums, 6);
            var expected = new int[] {9807,9807,9807,9807,9807,9807,1303,9059,9059,9059,9059,9059,9059,8161,8161,8161,8161,8161,8161,6823,6823,6218,6218,6869,8595,8718,8718,8718,8718,8718,8718,9766,9766,9766,9766,9766,9766,4600,4600,4600,4600,-1485,-1486,5786,5786,5786,5786,5786,5786,3180,3180,1750,1750,1750,1750,5872,6144,6144,6144,8507,8507,8507,8507,8507,8507,7629,7629,7629,8899,8899,8899,8899,8899,8899,8740,8740,8740,8740,8740,6280,6280,2209,2385,2385,7028,7028,7272,7272,7272,7272,7272,9087,9087,9087,9087,9087,9087,5534,5534,5534,6699,7558,7558,7558,7558,7558,7558,8854,8854,8854,8854,8854,8854,1302,1302,1302,1369,3322,3322,3322,3322,3322,8243,8243,8993,8993,8993,8993,8993,8993};
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FailedLeetCodeTestSmallerSample()
        {
            var sut = new SlidingWindowMaximum2();
            var nums = new int[] {7629,5877,3338,8899,4223,-8068,3775,7954,8740,4567,6280,-7687,-4811,-8094,2209,-4476,-8328};
            var result = sut.MaxSlidingWindow(nums, 6);
            var expected = new int[] {8899,8899,8899,8899,8740,8740,8740,8740,8740,6280,6280,2209 };
            Assert.AreEqual(expected, result);
        }
        

        private SlidingWindowMaximum.MaxHeap<int> BuildHeap()
        {
            var sut = new SlidingWindowMaximum.MaxHeap<int>(17);
            sut.Add(3);
            sut.Add(7);
            sut.Add(5);
            sut.Add(8);
            sut.Add(10);
            sut.Add(6);
            sut.Add(4);
            sut.Add(2);
            sut.Add(1);
            sut.Add(0);
            sut.Add(-1);
            sut.Add(-2);
            sut.Add(-3);
            sut.Add(-4);
            sut.Add(-5);
            sut.Add(50);
            sut.Add(51);

            return sut;
        }
    }
}