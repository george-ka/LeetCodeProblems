using System;

namespace LeetCodeChallenges
{
	///
	/// 33. Search in Rotated Sorted Array
	/// https://leetcode.com/problems/search-in-rotated-sorted-array/
	///
    /// There is an integer array nums sorted in ascending order 
    /// (with distinct values).
    /// Prior to being passed to your function, nums is possibly rotated 
    /// at an unknown pivot index k (1 <= k < nums.length) such that the 
    /// resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] 
    /// (0-indexed). For example, [0,1,2,4,5,6,7] might be rotated at pivot 
    /// index 3 and become [4,5,6,7,0,1,2].
    /// Given the array nums after the possible rotation and an integer 
    /// target, return the index of target if it is in nums, or -1 if it 
    /// is not in nums.
    /// You must write an algorithm with O(log n) runtime complexity.
    public class SearchInRotatedSortedArray
    {
        public int Search(int[] nums, int target)
        {
            if (nums == null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            if (nums.Length == 1)
            {
                if (nums[0] == target)
                {
                    return 0;
                }
                
                return -1;
            }

            if (nums.Length == 2)
            {
                return CheckTwoValues(nums, target, 0, 1);
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
                // find target with offset
                // new-index = (len - pivot + old-index) % len
                // We should search as usual ether in the left 
                // side of array from pivot or in the right side
                if (nums[pivot] <= target && target <= nums[nums.Length - 1])
                {
                    leftBoundary = pivot;
                    rightBoundary = nums.Length - 1;
                }
                else if (nums[0] <= target && target <= nums[pivot - 1])
                {
                    leftBoundary = 0;
                    rightBoundary = pivot - 1;
                }
                else
                {
                    throw new Exception("Unexpected situation 2");
                }
            }

            if (leftBoundary == rightBoundary)
            {
                throw new Exception("Shouldn't be here too");
            }

            while (leftBoundary < rightBoundary)
            {
                candidate = leftBoundary + (rightBoundary - leftBoundary) / 2;
                if (leftBoundary + 1 == rightBoundary)
                {
                    return CheckTwoValues(nums, target, leftBoundary, rightBoundary);
                }

                if (nums[candidate] == target)
                {
                    return candidate;
                }

                if (nums[candidate] < target)
                {
                    leftBoundary = candidate;
                }
                else
                {
                    rightBoundary = candidate;
                }
            }

            return -1;
        }

        private int CheckTwoValues(int[] nums, int target, int left, int right)
        {
            if (nums[left] == target)
            {
                return 0;
            }
            
            if (nums[right] == target)
            {
                return 1;
            }

            return -1;
        }
    }
}