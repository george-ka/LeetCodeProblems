using System;

namespace LeetCodeChallenges
{
    ///
    /// 162. Find Peak Element
    /// https://leetcode.com/problems/find-peak-element/
    /// 
    /// A peak element is an element that is strictly greater than its neighbors.
    /// Given an integer array nums, find a peak element, and return its
    /// index. If the array contains multiple peaks, return the index to 
    /// any of the peaks.
    /// You may imagine that nums[-1] = nums[n] = -∞.
    /// You must write an algorithm that runs in O(log n) time.
    public class PeakElementFinder
    {
        ///           p1
        ///            _
        ///           / \       p2
        ///      __---   --__    _
        /// __---            \__/ \__
        public int FindPeakElement(int[] nums)
        {
            if (nums == null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            // trivial solution
            if (nums.Length == 1)
            {
                return 0;
            }

            // edge cases
            if (nums.Length > 1)
            {
                if (nums[1] < nums[0])
                {
                    return 0;
                } 

                if (nums[nums.Length - 1] > nums[nums.Length - 2])
                {
                    return nums.Length - 1;
                }
            }

            var leftBoundary = 0;
            var rightBoundary = nums.Length - 1;
            var middle = -1;

            while (rightBoundary - leftBoundary > 0)
            {
                middle = leftBoundary + (rightBoundary - leftBoundary) / 2;
                Console.WriteLine($"middle index {middle}, value {nums[middle]}, lb {leftBoundary}, rb {rightBoundary}");
                if (IsPeak(nums, middle))
                {
                    return middle;
                }
                else if (nums[middle] < nums[middle - 1])
                {
                    rightBoundary = middle;
                }
                else
                {
                    leftBoundary = middle;
                }
            }

            return middle;
        }

        /// 0 1 2 100 3 2 1 100 0
        /// .. 9 ... 5 ... 3  - peak is 9 or may be inside
        /// .. 3 ... 5 ... 10 - peak is 10 or may be inside
        /// .. 3 ... 5 ... 2 ..  - peak is inside
        /// .. 9 ... 5 ... 7 ..  - peak is outside
        private bool IsPeak(int[] nums, int index)
        {
            return 
                (index == 0 && nums.Length > 1 
                    && nums[index + 1] < nums[index])
                || (index == nums.Length - 1 && nums.Length > 1 
                    && nums[nums.Length - 2] < nums[nums.Length - 1])
                || (IsSafeIndex(nums, index - 1) 
                    && IsSafeIndex(nums, index + 1) 
                    && nums[index - 1] < nums[index]
                    && nums[index + 1] < nums[index]);
        }

        private bool IsSafeIndex(int[] nums, int index)
        {
            return index >= 0 && index < nums.Length;
        }
    }
}