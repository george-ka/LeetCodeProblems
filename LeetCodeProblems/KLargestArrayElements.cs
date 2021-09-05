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
                PrintArray(nums);

                partitionIndex = Partition(nums, leftBoundary, rightBoundary);
                 Console.WriteLine($"leftBoundary: {leftBoundary}, rightBoundary: {rightBoundary}, partitionIndex: {partitionIndex}");
           
                if (partitionIndex == rightBoundary || partitionIndex == leftBoundary)
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
        // 2000 1 1 100
        // 100 1 1 2000
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

            var pivot = (nums[start] + nums[end]) / 2;
            // if (pivot == 8221)
            // {
            //     var arr = new int[end + 1 - start];
            //     Array.Copy(nums, start, arr, 0, arr.Length);
            //     PrintArray(arr);
            //     return 0;
            // }

            Console.WriteLine($"Pivot = {pivot}, start = {start} end = {end}");
            Console.ReadLine();
            var i = start;
            var j = end;
            while (i < j)
            {
                if (nums[i] <= pivot)
                {
                    // found indexes to swap
                    if (nums[j] > pivot)
                    {
                        Swap(nums, i, j);
                        i++;
                        j--;
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

            if (nums[i] > pivot)
            {
                return i + 1;
            }

            return i;
        }

        public void Swap(int[] nums, int i, int j)
        {
            var buffer = nums[i];
            nums[i] = nums[j];
            nums[j] = buffer;
        }

        static void PrintArray(int[] nums)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                Console.Write($"{nums[i]} ");
            }
            
            Console.WriteLine();
        }
    }
}