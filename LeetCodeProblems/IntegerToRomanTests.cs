using System;

namespace LeetCodeChallenges
{
    public class IntegerToRomanTests
    {
        public static void RunTests()
        {
            RunTest(555, "DLV");
        }
        
        private static void RunTest(int target, string expected)
        {
            Console.WriteLine($"Running test for {target}");
            var solution = new IntegerToRoman();
            var result = solution.IntToRoman(target);
            Console.WriteLine($"Expected: {expected}, result: {result}");
        }
    }
}