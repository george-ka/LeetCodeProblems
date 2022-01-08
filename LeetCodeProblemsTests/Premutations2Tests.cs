using System;
using System.Collections.Generic;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class Premutations2Tests
    {
        [Test]
        public void Premutations2Test1()
        {
            var result = GetTestResult(new [] { 1, 2, 3 });

            foreach (var res in result)
            {
                Console.WriteLine("Next premutation..");
                res.PrintList();
            }

            Assert.AreEqual(6, result.Count);
        }

        [Test]
        public void Premutations2Test2()
        {
            var result = GetTestResult(new [] { 1, 2, 2 });

            foreach (var res in result)
            {
                Console.WriteLine("Next premutation..");
                res.PrintList();
            }

            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public void Premutations2Test3()
        {
            var result = GetTestResult(new [] { 1, 1, 2 });

            foreach (var res in result)
            {
                Console.WriteLine("Next premutation..");
                res.PrintList();
            }

            Assert.AreEqual(3, result.Count);
        }

        private IList<IList<int>> GetTestResult(int[] nums)
        {
            var sut = new Premutations2();
            return sut.PermuteUnique(nums);
        }
    }
}