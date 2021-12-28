using System;
using System.Collections.Generic;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class ContainerWithMostWaterTests
    {
        [Test]
        public void ContainerWithMostWaterWide()
        {
            var h = new int[] { 1, 0, 0, 0, 2, 9, 5, 0, 0, 0, 1 };
            var result = GetMax(h);
            Assert.AreEqual(10, result);
        }

        [Test]
        public void ContainerWithMostWaterTest1()
        {
            var h = new int[] { 1,8,6,2,5,4,8,3,7 };
            var result = GetMax(h);
            Assert.AreEqual(49, result);
        }

        [Test]
        public void ContainerWithMostWaterTestEdge()
        {
            var h = new int[] { 1, 1 };
            var result = GetMax(h);
            Assert.AreEqual(1, result);
        }

        private static int GetMax(int[] heigths)
        {
            var sut = new ContainerWithMostWater();
            return sut.MaxArea(heigths);
        }
    }
}   