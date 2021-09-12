using System;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class KLargestArrayElementsTests
    {
        [Test]
        public void SortThreeTest()
        {
            /// 2 1 0

            /// 0 1 2
            /// 0 2 1

            /// 1 2 0

            /// 1 0 2
            /// 2 0 1

            var expected = new [] { 2, 1, 0 };
            RunSortThreeTest(expected, expected);
            RunSortThreeTest(new [] { 0, 1, 2 }, expected);
            RunSortThreeTest(new [] { 0, 2, 1 }, expected);
            RunSortThreeTest(new [] { 1, 2, 0 }, expected);
            RunSortThreeTest(new [] { 1, 0, 2 }, expected);
            RunSortThreeTest(new [] { 2, 0, 1 }, expected);

            expected = new [] { 2, 2, 1 };
            RunSortThreeTest(expected, expected);
            RunSortThreeTest(new[] { 1, 2, 2 }, expected);
            RunSortThreeTest(new[] { 2, 1, 2 }, expected);

            expected = new [] {2, 2, 2};
            RunSortThreeTest(expected, expected);
        }

        [Test]
        public void TestFindKthLargest()
        {
            RunFindKthLargestTest(() => { return new int[] {13, 4, 1, 5, 6, 77, 9, 9, 12, 19, 53, 0}; });
            RunFindKthLargestTest(() => { return new int[] {3,2,3,1,2,4,5,5,6}; });
            RunFindKthLargestTest(() => { return new int[] {21, 20, 21, 20, 21, 21}; });
            RunFindKthLargestTest(() => { return new int[] {-1, 2, 0}; });
            RunFindKthLargestTest(() => { return new int[] { 5, 2, 4, 1, 3, 6, 0 }; });
        }

        private void RunFindKthLargestTest(Func<int[]> assign)
        {
            var soluton = new KLargestArrayElements();
            var sorted = assign();
            Array.Sort(sorted, new Comparison<int>((i, j) => j.CompareTo(i)));
            
            for (var k = 0; k < sorted.Length; k++)
            {
                var nums = assign();
                var result = soluton.QuickSelect(nums, k);
                nums.PrintArray();
                Console.WriteLine();
                Assert.AreEqual(sorted[k], result, $"Expected {k}th biggest to be {sorted[k]} but it is {result} ");
            }
        }

        private void RunSortThreeTest(int[] nums, int[] expected)
        {
            var sut = new KLargestArrayElements();
            sut.SortThree(nums);
            Assert.AreEqual(nums, expected, $"Sort {ArrayOfThreeToString(nums)} did not match {ArrayOfThreeToString(expected)}");
        }

        private string ArrayOfThreeToString(int[] nums)
        {
            return $"{{{nums[0]}, {nums[1]}, {nums[2]}}}";
        }
    }
}