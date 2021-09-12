using System;

namespace LeetCodeChallenges
{
    ///
    /// 215. Kth Largest Element in an Array
    /// https://leetcode.com/problems/kth-largest-element-in-an-array/
    /// 
    public class KLargestArrayElements
    {
        public int FindKthLargest(int[] nums, int k) 
        {
            return QuickSelect(nums, k - 1);
        }

        public int QuickSelect(int[] nums, int k)
        {
            // use the same aproach as quicksort
            // 1. select a median 
            // 2. Partition: put all elements grater than median to the 
            // right and all smaller elements to the left
            // 3. Resulting index P from a partition should be stable
            // if the k is less than P then search on the left side
            // if the k is greater than P, then search on the righ side 
            // (preseve the boundary from the previous iteration!)
            // if k is equal to P, then we've got an answer
            var partitionIndex = -1; 
            var leftBoundary = 0;
            var rightBoundary = nums.Length - 1;
            while (leftBoundary != rightBoundary)
            {
                nums.PrintArray();

                partitionIndex = Partition(nums, leftBoundary, rightBoundary);
                Console.WriteLine($"leftBoundary: {leftBoundary}, rightBoundary: {rightBoundary}, partitionIndex: {partitionIndex}");
           
                if (partitionIndex > rightBoundary || partitionIndex == leftBoundary)
                {
                    break;
                }
                
                if (partitionIndex <= k)
                {
                    leftBoundary = partitionIndex;
                }
                else if (partitionIndex > k)
                {
                    rightBoundary = partitionIndex - 1;
                }

            }

            return nums[k];
        }

        // partition array around the value of nums[pivotIndex]
        // return the resulting index of the position where partitioning stopped
        // this index should remain stable, because all elements greater than the element 
        // should be on the right side and all those are less should be on the left
        // Note: Remove Console call to make it faster
        public int Partition(int[] nums, int start, int end)
        {
            if (start + 1 == end)
            {
                if (nums[start] < nums[end])
                {
                    Swap(nums, start, end);
                }

                return start;
            }
            else if (start + 2 == end)
            {
                SortThree(nums, start);
                return start;
            }

            var pivot = (nums[start] + nums[end]) / 2;

            Console.WriteLine($"Pivot = {pivot}, start = {start} end = {end}");
            var i = start;
            var j = end;
            while (i < j)
            {
                if (nums[i] < pivot)
                {
                    // found indexes to swap
                    if (nums[j] >= pivot)
                    {
                        Swap(nums, i, j);
                        i++;
                    }
                    else
                    {
                        j--;
                    }
                }
                else if (nums[i] == pivot)
                {
                    if (nums[j] > pivot)
                    {
                        Swap(nums, i, j);
                        i++;
                    }
                    else
                    {
                        j--;
                    }
                }
                else
                {
                    i++;
                }
            }

            if (nums[i] >= pivot && i < end)
            {
                return i + 1;
            }

            return i;
        }

        // Dirty hack to speed up 3 elements sort
        public void SortThree(int[] nums, int start = 0)
        {
            if (nums[start] < nums[start + 1])
            {
                if (nums[start] < nums[start + 2])
                {
                    if (nums[start + 1] > nums[start + 2])
                    {
                        Swap(nums, start + 1, start + 2);
                    }

                    Swap(nums, start, start + 2);
                }
                else
                {
                    Swap(nums, start, start + 1);
                }
            }
            else if (nums[start] > nums[start + 2])
            {
                if (nums[start + 1] < nums[start + 2])
                {
                    Swap(nums, start + 1, start + 2);
                }
            }
            else 
            {
                Swap(nums, start, start + 2);
                Swap(nums, start + 1, start + 2);
            }
        }

        public static void Swap<T>(T[] arr, int i, int j)
        {
            var buffer = arr[i];
            arr[i] = arr[j];
            arr[j] = buffer;
        }
    }
}