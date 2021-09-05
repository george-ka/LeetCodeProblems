using System;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class IntegerToRomanTests
    {
        [Test]
        public static void Test1()
        {
            RunTest(555, "DLV");
        }
        
        private static void RunTest(int target, string expected)
        {
            Console.WriteLine($"Running test for {target}");
            var solution = new IntegerToRoman();
            var result = solution.IntToRoman(target);
            Console.WriteLine($"Expected: {expected}, result: {result}");
            Assert.AreEqual(expected, result);
        }
    }
}