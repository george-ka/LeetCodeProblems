using System;

namespace LeetCodeChallenges
{
	///
	/// 34. Find First and Last Position of Element in Sorted Array
	/// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
	///
    /// Given an array of integers nums sorted in increasing order, find the starting and ending position of a given target value.
    /// If target is not found in the array, return [-1, -1].
    /// You must write an algorithm with O(log n) runtime complexity.
    public class FindRangeInSortedArray
    {
        public int[] SearchRange(int[] nums, int target)
        {
            if (nums == null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            var leftBoundary = FindLeftmostTarget(nums, target);
            var rightBoundary = FindRightmostTarget(nums, target);
            return new int[] { leftBoundary, rightBoundary };
        }

        private int FindLeftmostTarget(int[] nums, int target)
        {
            return FindBoundary(nums, target, true);
        }

        private int FindRightmostTarget(int[] nums, int target)
        {
            return FindBoundary(nums, target, false);
        }

        private int FindBoundary(int[] nums, int target, bool searchForLeft)
        {
            //  0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6
            // |_|_|x|_|_|_|t|t|t|_|_|_|_|x|_|_|_|
            // i0:lb=0, rb=16, c=8
            // i1:lb=0, rb=8, c=4 
            // i2:lb=4, rb=8, c=4+2=6
            var leftBoundary = 0;
            var rightBoundary = nums.Length - 1;
            int candidate = -1;

            if (nums.Length == 0)
            {
                return -1;
            }

            if (leftBoundary == rightBoundary)
            {
                if (nums[leftBoundary] == target)
                {
                    return leftBoundary;
                }
                else
                {
                    return -1;
                }
            }
 
            do
            {   
                if (leftBoundary + 1 == rightBoundary)
                {
                    if (nums[leftBoundary] == target && nums[rightBoundary] == target)
                    {
                        return searchForLeft ? leftBoundary : rightBoundary;
                    }

                    if (nums[leftBoundary] == target)
                    {
                        candidate = leftBoundary;
                    }
                    else if (nums[rightBoundary] == target)
                    {
                        candidate = rightBoundary;
                    }
                    else if (nums[leftBoundary] != target && nums[rightBoundary] != target)
                    {
                        return -1;
                    }
                }
                else
                {
                    candidate = leftBoundary + (rightBoundary - leftBoundary) / 2;
                }

                Console.WriteLine($"left {leftBoundary}, right {rightBoundary}, c {candidate}, {searchForLeft} t{target}");
                
                if (nums[candidate] < target)
                {
                    leftBoundary = candidate;
                }
                else if (nums[candidate] > target)
                {
                    rightBoundary = candidate;
                }
                else if (nums[candidate] == target)
                {
                    if (searchForLeft)
                    {    
                        if (candidate == 0)
                        {
                            return candidate;
                        }

                        if (nums[candidate - 1] != target)
                        {
                            return candidate;
                        }
                        else
                        {
                            rightBoundary = candidate;
                        }
                    }
                    else
                    {
                        if (candidate == nums.Length - 1)
                        {
                            return candidate;
                        }

                        if (nums[candidate + 1] != target)
                        {
                            return candidate;
                        }
                        else
                        {
                            leftBoundary = candidate;
                        }
                    }
                }
            } while (leftBoundary < rightBoundary); 

            return -1;
        }
    }
}