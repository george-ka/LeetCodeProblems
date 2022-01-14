using System;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class HouseRobberTests
    {
        [Test]
        public void HouseRobberTest1()
        {
            var houses = new [] { 10, 11, 20, 12, 20, 10, 10, 15, 10, 16 };
            var result = RunTest(houses);
            Assert.AreEqual(71, result);
        }

        [Test]
        public void HouseRobberTest2()
        {
            var houses = new [] { 10, 11, 20, 12  };
            var result = RunTest(houses);
            Assert.AreEqual(30, result);
        }

        [Test]
        public void HouseRobberTest3()
        {
            var houses = new [] { 10, 14, 2, 12, 3 };
            var result = RunTest(houses);
            Assert.AreEqual(26, result);
        }

        [Test]
        public void HouseRobberTest4()
        {
            var houses = new [] { 100, 14, 2, 12, 300 };
            var result = RunTest(houses);
            Assert.AreEqual(314, result);
        }

        private static int RunTest(int[] houses)
        {
            var sut = new HouseRobber2();
            return sut.Rob(houses);
        }
    }
}