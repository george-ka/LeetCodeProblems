using System;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class PerfectSquaresTests
    {
        [Test]
        public void TrivialSamplesShouldWork()
        {
            AssertItWorksAsExpected(1, 1);
            AssertItWorksAsExpected(2, 2);
            AssertItWorksAsExpected(3, 3);
            AssertItWorksAsExpected(4, 1);
            AssertItWorksAsExpected(5, 2);
            AssertItWorksAsExpected(6, 3);
            AssertItWorksAsExpected(7, 4);
            AssertItWorksAsExpected(8, 2);
            AssertItWorksAsExpected(9, 1);
            AssertItWorksAsExpected(10, 2);
            AssertItWorksAsExpected(11, 3);
            AssertItWorksAsExpected(12, 3);
            AssertItWorksAsExpected(13, 2);
            AssertItWorksAsExpected(14, 3);
            AssertItWorksAsExpected(15, 4);
            AssertItWorksAsExpected(195, 3);
            AssertItWorksAsExpected(9999, 4);
        }

        private static void AssertItWorksAsExpected(int target, int expectedResult)
        {
            var solution = new PerfectSquaresSolution();
            var result = solution.FindMinimalNumberOfSqaresWhichSumUpTo(target);
            Assert.AreEqual(expectedResult, result, $"Failed for target {target}");
        }
    }
}