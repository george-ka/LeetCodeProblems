using System;

namespace LeetCodeChallenges
{
	///
	/// 153. Find Minimum in Rotated Sorted Array
	/// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
	///
    /// Suppose an array of length n sorted in ascending order is rotated between 1 and n times. For example, the array nums = [0,1,2,4,5,6,7] might become:
    /// [4,5,6,7,0,1,2] if it was rotated 4 times.
    /// [0,1,2,4,5,6,7] if it was rotated 7 times.
    /// Notice that rotating an array [a[0], a[1], a[2], ..., a[n-1]] 1 time results in the array [a[n-1], a[0], a[1], a[2], ..., a[n-2]].
    /// Given the sorted rotated array nums of unique elements, return the minimum element of this array.
    /// You must write an algorithm that runs in O(log n) time.
    public class FindMinInRotatedSortedArray
    {
        public int FindMin(int[] nums)
        {
            // reuse code from SearchInRotatedSortedArray
            if (nums == null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            if (nums.Length == 2)
            {
                return nums[0] < nums[1] ? nums[0] : nums[1];
            }

            var leftBoundary = 0;
            var rightBoundary = nums.Length - 1;
            var candidate = -1;
            var pivot = -1;

            // if the array is rotated, then last element is less than first 
            if (nums[nums.Length - 1] < nums[0])
            {
                // find pivot based on this principle
                // the left boundary should be smaller than right
                // so we need to find a place 
                // where left < right and index(left) + 1 = index(right)
                while (leftBoundary < rightBoundary)
                {
                    if (leftBoundary + 1 == rightBoundary)
                    {
                        if (nums[leftBoundary] > nums[rightBoundary])
                        {
                            pivot = rightBoundary;
                            break;
                        }
                        else
                        {
                            // this is strange and there should be some algorithm problem
                            throw new Exception("Unexpeced situation");
                        }
                    }
                    else
                    {
                        // 0 1 2 3 4 5 6
                        // 4,5,6,7,0,1,2
                        // (len - pivot + i) % len
                        // 3 4 5 6 0 1 2
                        candidate = leftBoundary + (rightBoundary - leftBoundary) / 2;
                        if (nums[leftBoundary] > nums[candidate])
                        {
                            rightBoundary = candidate;
                        }
                        else if (nums[leftBoundary] < nums[candidate])
                        {
                            leftBoundary = candidate;
                        }
                    }
                }

                Console.WriteLine($"Pivot found {pivot}");
                return nums[pivot];
            }
            else
            {
                return nums[0];
            }
        }
    }
}