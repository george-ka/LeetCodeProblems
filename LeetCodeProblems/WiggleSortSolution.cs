using System;

namespace LeetCodeChallenges
{
    ///
    /// 324. Wiggle Sort II
    /// https://leetcode.com/problems/wiggle-sort-ii/
    ///
    /// Given an integer array nums, reorder it such that nums[0] < nums[1] > nums[2] < nums[3]....
    /// Find O(n) time complexity solution with O(1) extra space
    /// Observation: nums[0] doesn't have to be less than nums[2]
    /// 
    /// Solution approach
    /// Find a median of an array and then partition it like in Quicksort in two equal parts
    /// Then just swap every second element in each part
    /// In total there will be two loops so O(n)
    public class WiggleSortSolution
    {
        public void WiggleSort(int[] nums) 
        {
            var partitionIndex = Partition(nums);
            Console.WriteLine($"Partition = {nums[partitionIndex]}, {partitionIndex}");
        }

        public int FindMedian(int[] nums)
        {
            var total = 0d;
            for (var i = 0; i < nums.Length; i++)
            {
                total += nums[i];
            }

            return (int)(total/nums.Length);
        }
 

        // different approach than in KthLargestElement
        public int Partition(int[] nums)
        {
            var median = FindMedian(nums);

            var j = nums.Length - 1;
            var i = 0;
            for (; i <= j; i++)
            {
                if (nums[i] > median)
                {
                    while (nums[j] > median || i < j)
                    {
                        j--;
                    }

                    Swap(nums, i, j);
                }
            }

            return i;
        }

        public static void Swap<T>(T[] arr, int i, int j)
        {
            var buffer = arr[i];
            arr[i] = arr[j];
            arr[j] = buffer;
        }
    }
}